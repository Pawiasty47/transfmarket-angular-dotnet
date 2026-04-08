import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './footer.html', // lub footer.component.html
  styleUrl: './footer.scss'     // lub footer.component.scss
})
export class FooterComponent {
  // Pobieramy aktualny rok, żeby stopka zawsze była na czasie!
  currentYear: number = new Date().getFullYear();
}