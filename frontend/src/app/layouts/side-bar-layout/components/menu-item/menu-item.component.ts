import { NgClass } from '@angular/common';
import { Component, input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { RippleModule } from 'primeng/ripple';

@Component({
  selector: 'app-menu-item',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgClass, RippleModule],
  templateUrl: './menu-item.component.html',
  styleUrl: './menu-item.component.css',
})
export class MenuItemComponent {
  public readonly icon = input<string>();
  public readonly href = input.required<string>();
  public readonly exact = input<boolean>(false);
}
