import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
// Zmieniony import:
import { provideHttpClient, withFetch } from '@angular/common/http'; 

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    // Zmieniona linijka:
    provideHttpClient(withFetch()) 
  ]
};