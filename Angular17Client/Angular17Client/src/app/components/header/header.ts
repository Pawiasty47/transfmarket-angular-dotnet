import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-header',
  standalone: true, // <--- To naprawia pierwszy błąd (NG2012)
  imports: [MatToolbarModule, MatIconModule],
  templateUrl: './header.html', // <--- To naprawia drugi błąd (NG2008)
  styleUrl: './header.scss' // Jeśli masz plik CSS zamiast SCSS, zmień na './header.css'
})
export class HeaderComponent {}