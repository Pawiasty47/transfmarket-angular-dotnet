import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  template: `
    <footer style="background-color: #f5f5f5; padding: 20px; text-align: center; border-top: 1px solid #ddd; margin-top: auto;">
      <p style="margin: 0; color: #666; font-family: Roboto, sans-serif;">
        &copy; 2026 Projekt Rekrutacyjny. Wszystkie prawa zastrzeżone.
      </p>
    </footer>
  `
})
export class FooterComponent {} // <--- I tej też szukał!