import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatToolbarModule, MatIconModule],
  template: `
    <mat-toolbar color="primary" style="box-shadow: 0 2px 5px rgba(0,0,0,0.1); position: relative; z-index: 10;">
      <mat-icon style="margin-right: 10px;">sports_soccer</mat-icon>
      <span>Football Manager App</span>
    </mat-toolbar>
  `
})
export class HeaderComponent {} // <--- To jest ta nazwa, której szukał Angular!