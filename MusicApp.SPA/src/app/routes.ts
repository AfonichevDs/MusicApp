import { PlaylistResolver } from './_resolvers/playlist.resolver';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import { LoggedInGuard, AuthGuard } from './_guards/auth.guard';
import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { SongListComponent } from './song-list/song-list.component';
import { ArtistDetailComponent } from './artist-detail/artist-detail.component';
import { ArtistResolver } from './_resolvers/artist.resolver';
import { AlbumDetailComponent } from './album-detail/album-detail.component';
import { AlbumResolver } from './_resolvers/album.resolver';
import { SearchComponent } from './search/search.component';
import { SearchResolver } from './_resolvers/search.resolver';

export const appRoutes: Routes = [
    { path: '', redirectTo: 'songs', pathMatch: 'full'},
    { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
    { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
    { path: 'songs', component: SongListComponent, resolve: { mainPlaylist: PlaylistResolver },  canActivate: [LoggedInGuard] },
    { path: 'artist/:id', component: ArtistDetailComponent, resolve: { artist: ArtistResolver },  canActivate: [LoggedInGuard] },
    { path: 'album/:id', component: AlbumDetailComponent, resolve: { album: AlbumResolver },  canActivate: [LoggedInGuard] },
    { path: 'search/:term', component: SearchComponent, resolve: { searchResult: SearchResolver },  canActivate: [LoggedInGuard] },
    { path: '**', redirectTo: 'songs', pathMatch: 'full' }
]