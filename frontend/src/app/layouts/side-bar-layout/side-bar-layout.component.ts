import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { MenuItemComponent } from './components/menu-item/menu-item.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-side-bar-layout',
  standalone: true,
  imports: [ButtonModule, MenuItemComponent, RouterOutlet],
  templateUrl: './side-bar-layout.component.html',
  styleUrl: './side-bar-layout.component.css',
})
export class SideBarLayoutComponent {}
