import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { Player } from '../models/football.models';
import { environment } from '../../environments/environments';

@Injectable({
  providedIn: 'root'
})
export class PlayerService { //serwis do zarządzania danymi zawodników, komunikujący się z backendem poprzez HTTP
  private http = inject(HttpClient);
  
  private baseUrl = `${environment.apiUrl}/api`;

  private apiUrl = `${this.baseUrl}/Players`;

  getPlayers(clubId?: number, nationalityId?: number): Observable<Player[]> { //pobieranie listy zawodników z opcjonalnymi filtrami dla klubu i narodowości
    let params = new HttpParams();
    
    if (clubId) {
      params = params.set('clubId', clubId);
    }
    if (nationalityId) {
      params = params.set('nationalityId', nationalityId);
    }

    return this.http.get<Player[]>(this.apiUrl, { params: params });
  }

  createPlayer(player: Player): Observable<Player> { //tworzenie nowego zawodnika poprzez wysłanie danych do backendu
    return this.http.post<Player>(this.apiUrl, player);
  }

  updatePlayer(id: number, player: Player): Observable<void> { //aktualizacja danych istniejącego zawodnika poprzez wysłanie zaktualizowanych danych do backendu
    return this.http.put<void>(`${this.apiUrl}/${id}`, player);
  }
  
  deletePlayer(id: number): Observable<void> { //usuwanie zawodnika poprzez wysłanie żądania do backendu z ID zawodnika, który ma zostać usunięty
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getClubTotalValue(clubId: number): Observable<number> { //pobieranie łącznej wartości rynkowej zawodników z danego klubu poprzez wysłanie żądania do backendu z ID klubu
    return this.http.get<number>(`${this.baseUrl}/clubs/${clubId}/total-value`);
  }

  getNationalityTotalValue(nationalityId: number): Observable<number> { // pobieranie łącznej wartości rynkowej zawodników z danej narodowości poprzez wysłanie żądania do backendu z ID narodowości
    return this.http.get<number>(`${this.baseUrl}/nationalities/${nationalityId}/total-value`);
  }
  getEurExchangeRate(): Observable<number> { //pobieranie aktualnego kursu wymiany euro poprzez wysłanie żądania do backendu, który zwraca kurs euro
    return this.http.get<number>(`${this.baseUrl}/ExchangeRates/eur`);
  }
}