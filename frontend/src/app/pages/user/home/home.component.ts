import { Component } from '@angular/core';
import { SideBarLayoutComponent } from '../../../layouts/side-bar-layout/side-bar-layout.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [SideBarLayoutComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {}
