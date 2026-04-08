import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { Player } from '../models/football.models';
import { environment } from '../../environments/environments';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private http = inject(HttpClient);
  
  // 1. Definiujemy BAZOWY ADRES za pomocą Twojego environment (np. https://localhost:7152/api)
  private baseUrl = `${environment.apiUrl}/api`;

  // 2. Adres dla samych piłkarzy budujemy na podstawie bazy
  private apiUrl = `${this.baseUrl}/Players`;

  getPlayers(clubId?: number, nationalityId?: number): Observable<Player[]> {
    let params = new HttpParams();
    
    if (clubId) {
      params = params.set('clubId', clubId);
    }
    if (nationalityId) {
      params = params.set('nationalityId', nationalityId);
    }

    return this.http.get<Player[]>(this.apiUrl, { params: params });
  }

  createPlayer(player: Player): Observable<Player> {
    return this.http.post<Player>(this.apiUrl, player);
  }

  updatePlayer(id: number, player: Player): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, player);
  }
  
  deletePlayer(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  // 3. Teraz total-value korzystają z poprawnego baseUrl:
  getClubTotalValue(clubId: number): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/clubs/${clubId}/total-value`);
  }

  getNationalityTotalValue(nationalityId: number): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/nationalities/${nationalityId}/total-value`);
  }
}