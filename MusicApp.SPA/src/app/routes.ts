import { PlaylistResolver } from './_resolvers/playlist.resolver';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import { LoggedInGuard, AuthGuard } from './_guards/auth.guard';
import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SongListComponent } from './song-list/song-list.component';
import { ArtistDetailComponent } from './artist-detail/artist-detail.component';
import { ArtistResolver } from './_resolvers/artist.resolver';

export const appRoutes: Routes = [
    {path: 'login', component: LoginComponent, canActivate: [AuthGuard]},
    {path: 'register', component: RegisterComponent, canActivate: [AuthGuard]},
    {
        path:'',
        runGuardsAndResolvers:'always',
        canActivate: [LoggedInGuard],
        children: [
            {path: 'songs', component: SongListComponent,resolve: { mainPlaylist: PlaylistResolver}},
            {path: 'artist/:id', component: ArtistDetailComponent, resolve: {artist: ArtistResolver}},
        ]
    },
    {path: '**', redirectTo: 'songs', pathMatch: 'full'}
]