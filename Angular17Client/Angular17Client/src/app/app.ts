import { Component, OnInit, inject, signal } from '@angular/core';
import { PlayerService } from './services/service';
import { Player } from './models/football.models';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App implements OnInit {
  private playerService = inject(PlayerService);
  
  // Zmiana 1: Zamiast zwykłej tablicy, tworzymy Signal
  players = signal<Player[]>([]);

  ngOnInit(): void {
    this.fetchPlayers();
  }

  fetchPlayers(): void {
    this.playerService.getPlayers().subscribe({
      next: (data) => {
        // Zmiana 2: Używamy .set(), aby zaktualizować dane. Angular od razu to zauważy!
        this.players.set(data);
        console.log('Udało się pobrać dane z .NET!', data);
      },
      error: (err) => {
        console.error('Błąd pobierania danych:', err);
      }
    });
  }
}