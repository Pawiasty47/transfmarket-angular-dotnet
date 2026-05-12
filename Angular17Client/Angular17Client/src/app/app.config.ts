import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

import { provideHttpClient, withFetch } from '@angular/common/http'; 

export const appConfig: ApplicationConfig = { //główna konfiguracja aplikacji, definiująca podstawowe ustawienia i dostawców usług
  providers: [
    provideRouter(routes),
    
    provideHttpClient(withFetch()) 
  ]
};