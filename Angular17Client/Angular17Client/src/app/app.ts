import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms'; // DODANE: Moduł formularzy
import { PlayerService } from './services/service';
import { Player } from './models/football.models';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule], // DODANE: Rejestracja modułu w komponencie
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App implements OnInit {
  private playerService = inject(PlayerService);
  
  players = signal<Player[]>([]);
  filterClubId: number = 0;
  filterNationalityId: number = 0;

  // Obiekt do przetrzymywania danych z formularza
  newPlayer: any = {
    firstName: '',
    lastName: '',
    age: 18,
    weight: 70,
    price: 0,        // DODANE
    position: 'Napastnik', // DODANE
    clubId: 1,
    nationalityId: 1
  };

  ngOnInit(): void {
    this.fetchPlayers();
  }

  fetchPlayers(): void {
    const cId = this.filterClubId !== 0 ? this.filterClubId : undefined;
    const nId = this.filterNationalityId !== 0 ? this.filterNationalityId : undefined;

    this.playerService.getPlayers(cId, nId).subscribe({
      next: (data) => this.players.set(data),
      error: (err) => console.error('Błąd pobierania:', err)
    });
  }

  // Funkcja DODAWANIA
  addPlayer(): void {
    this.playerService.createPlayer(this.newPlayer).subscribe({
      next: () => {
        console.log('Dodano gracza!');
        this.fetchPlayers(); // Odświeżamy listę, żeby zaciągnąć relacje (nazwę klubu itp.)
        // Resetujemy formularz
        this.newPlayer.firstName = '';
        this.newPlayer.lastName = '';
      },
      error: (err) => console.error('Błąd dodawania:', err)
    });
  }

  // Funkcja USUWANIA
  deletePlayer(id: number): void {
    if(confirm('Na pewno chcesz usunąć tego zawodnika?')) {
      this.playerService.deletePlayer(id).subscribe({
        next: () => {
          console.log('Usunięto gracza!');
          // Aktualizujemy sygnał, usuwając gracza z listy bez przeładowania strony
          this.players.update(currentPlayers => currentPlayers.filter(p => p.id !== id));
        },
        error: (err) => console.error('Błąd usuwania:', err)
      });
    }
  }
}