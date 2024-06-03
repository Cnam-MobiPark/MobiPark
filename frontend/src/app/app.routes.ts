import { Routes } from '@angular/router';
import { guestGuard } from './guards/guest.guard';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: 'login',
    canActivate: [guestGuard],
    loadComponent: () =>
      import('./pages/login/login.component').then((c) => c.LoginComponent),
  },
  {
    path: '',
    //canActivate: [authGuard],
    loadComponent: () =>
      import('./layouts/side-bar-layout/side-bar-layout.component').then(
        (c) => c.SideBarLayoutComponent,
      ),
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./pages/user/home/home.component').then(
            (c) => c.HomeComponent,
          ),
      },
      {
        path: 'my-reservations',
        loadComponent: () =>
          import('./pages/user/my-reservations/my-reservations.component').then(
            (c) => c.MyReservationsComponent,
          ),
      },
      {
        path: 'my-vehicles',
        loadComponent: () =>
          import('./pages/user/my-vehicle/my-vehicle.component').then(
            (c) => c.MyVehicleComponent,
          ),
      },
    ],
  },
];
