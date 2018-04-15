import { ControlPanelComponent } from './control-panel/control-panel.component';
import { LoggedInGuard, AuthGuard } from './_guards/auth.guard';
import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SongListComponent } from './song-list/song-list.component';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent, canActivate: [AuthGuard]},
    {path: 'register', component: RegisterComponent, canActivate: [AuthGuard]},
    {path: 'main', component: SongListComponent, canActivate: [LoggedInGuard]},
    {path: '**', redirectTo: 'login', pathMatch: 'full'}
]