import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './footer.html', 
  styleUrl: './footer.scss'     
})
export class FooterComponent {
  // Pobieramy aktualny rok, do stopki
  currentYear: number = new Date().getFullYear();
}