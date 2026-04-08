import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PlayerService } from './services/player.service';
import { Player } from './models/football.models';
import { HeaderComponent } from './components/header/header';
import { FooterComponent } from './components/footer/footer';

// Importy Angular Material
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    FormsModule, 
    MatTableModule, 
    MatButtonModule, 
    MatInputModule, 
    MatSelectModule, 
    MatFormFieldModule, 
    MatIconModule,
    MatCardModule,
    HeaderComponent,
    FooterComponent,
    MatExpansionModule
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App implements OnInit {
  private playerService = inject(PlayerService);
  
  // ZMIANA: Zamiast sygnału, tworzymy dedykowane źródło danych dla tabeli Material
  dataSource = new MatTableDataSource<Player>([]);

  // Sztuczne dane do widgetu "Najczęściej wyświetlani"
  topPlayers = [
    { name: 'M. Olise', value: '140,00 mln €', club: 'FC Bayern' },
    { name: 'L. Yamal', value: '120,00 mln €', club: 'FC Barcelona' },
    { name: 'J. Bellingham', value: '180,00 mln €', club: 'Real Madryt' },
    { name: 'R. Lewandowski', value: '15,00 mln €', club: 'FC Barcelona' }
  ];

  filterClubId: number = 0;
  filterNationalityId: number = 0;
  editingPlayerId: number | null = null; 

  totalValue: number = 0;
  totalValueLabel: string = 'Łączna wartość całej bazy:';

  displayedColumns: string[] = ['id', 'name', 'age', 'position', 'price', 'club', 'nationality', 'actions'];

  newPlayer: any = {
    firstName: '', lastName: '', age: 18, weight: 70, price: 0, position: 'Napastnik', clubId: 1, nationalityId: 1
  };

  ngOnInit(): void {
    this.fetchPlayers();
  }

  fetchPlayers(): void {
    const cId = this.filterClubId !== 0 ? this.filterClubId : undefined;
    const nId = this.filterNationalityId !== 0 ? this.filterNationalityId : undefined;

    this.playerService.getPlayers(cId, nId).subscribe({
      next: (data) => {
        // Logika biznesowa: Ogień dostają tylko zawodnicy warci 100 mln lub więcej!
        const playersWithFire = data.map(player => ({
          ...player,
          isHot: player.price >= 100 
        }));

        this.dataSource.data = playersWithFire; 
        this.fetchTotalValue(); 
      },
      error: (err) => console.error('Błąd pobierania:', err)
    });
  }

fetchTotalValue(): void {
    const hasClub = this.filterClubId && this.filterClubId !== 0;
    const hasNationality = this.filterNationalityId && this.filterNationalityId !== 0;

    // 1. ZAZNACZONE OBA FILTRY (np. FC Barcelona + Polska)
    if (hasClub && hasNationality) {
      this.totalValue = this.dataSource.data.reduce((sum, player) => sum + player.price, 0);
      this.totalValueLabel = 'Wartość zawodników (Wybrany Klub i Kraj):';
    } 
    // 2. ZAZNACZONY TYLKO KLUB
    else if (hasClub) {
      this.playerService.getClubTotalValue(this.filterClubId).subscribe({
        next: (val) => {
          this.totalValue = val;
          this.totalValueLabel = 'Wartość rynkowa wybranego klubu:';
        }
      });
    } 
    // 3. ZAZNACZONY TYLKO KRAJ
    else if (hasNationality) {
      this.playerService.getNationalityTotalValue(this.filterNationalityId).subscribe({
        next: (val) => {
          this.totalValue = val;
          this.totalValueLabel = 'Wartość rynkowa reprezentacji:';
        }
      });
    } 
    // 4. BRAK FILTRÓW
    else {
      this.totalValue = this.dataSource.data.reduce((sum, player) => sum + player.price, 0);
      this.totalValueLabel = 'Łączna wartość całej bazy:';
    }
  }

  editPlayer(player: Player): void {
    this.editingPlayerId = player.id;
    this.newPlayer = { 
      id: player.id, firstName: player.firstName, lastName: player.lastName, 
      age: player.age, weight: player.weight, price: player.price, 
      position: player.position, clubId: player.clubId, nationalityId: player.nationalityId 
    };
  }

  savePlayer(): void {
    if (this.editingPlayerId) {
      this.playerService.updatePlayer(this.editingPlayerId, this.newPlayer).subscribe({
        next: () => { this.fetchPlayers(); this.resetForm(); },
        error: (err) => console.error('Błąd edycji:', err)
      });
    } else {
      this.playerService.createPlayer(this.newPlayer).subscribe({
        next: () => { this.fetchPlayers(); this.resetForm(); },
        error: (err) => console.error('Błąd dodawania:', err)
      });
    }
  }

  resetForm(): void {
    this.editingPlayerId = null;
    this.newPlayer = { firstName: '', lastName: '', age: 18, weight: 70, price: 0, position: 'Napastnik', clubId: 1, nationalityId: 1 };
  }

  deletePlayer(id: number): void {
    if(confirm('Na pewno chcesz usunąć tego zawodnika?')) {
      this.playerService.deletePlayer(id).subscribe({
        // ZMIANA: Po usunięciu po prostu odpalamy fetchPlayers, żeby pobrać nową listę z backendu
        next: () => this.fetchPlayers(),
        error: (err) => console.error('Błąd usuwania:', err)
      });
    }
  }
}