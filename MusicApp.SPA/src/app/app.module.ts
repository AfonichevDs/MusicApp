import { SearchResolver } from './_resolvers/search.resolver';
import { AlbumsService } from './_services/albums.service';
import { ArtistResolver } from './_resolvers/artist.resolver';
import { PlayerService } from './_services/player.service';
import { PlaylistResolver } from './_resolvers/playlist.resolver';
import { AuthModule } from './auth/auth.module';
import { SongComponent } from './song-list/song/song.component';
import { LoggedInGuard, AuthGuard } from './_guards/auth.guard';
import { AlertifyService } from './_services/alertify.service';
import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HeaderComponent } from './header/header.component';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { CollapseModule, BsDatepickerModule, BsDropdownModule } from 'ngx-bootstrap';
import { SongListComponent } from './song-list/song-list.component';
import { PlaylistsService } from './_services/playlists.service';
import { MainPlayerComponent } from './main-player/main-player.component';
import { ArtistDetailComponent } from './artist-detail/artist-detail.component';
import { ArtistsService } from './_services/artists.service';
import { AlbumDetailComponent } from './album-detail/album-detail.component';
import { AlbumResolver } from './_resolvers/album.resolver';
import { SearchService } from './_services/search.service';
import { SearchComponent } from './search/search.component';
import { ArtistCardComponent } from './artist-card/artist-card.component';
import { SlicedotsPipe } from './_pipes/slicedots.pipe';
import { AlbumCardComponent } from './album-card/album-card.component';
import { PlaylistCardComponent } from './playlist-card/playlist-card.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    ControlPanelComponent,
    SongListComponent,
    SongComponent,
    MainPlayerComponent,
    ArtistDetailComponent,
    AlbumDetailComponent,
    SearchComponent,
    ArtistCardComponent,
    SlicedotsPipe,
    AlbumCardComponent,
    PlaylistCardComponent
],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    CollapseModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    AuthModule
  ],
  providers: [
    AuthService,
    AlertifyService,
    ArtistsService,
    PlaylistsService,
    LoggedInGuard,
    AuthGuard,
    PlaylistResolver,
    ArtistResolver,
    PlayerService,
    AlbumsService,
    AlbumResolver,
    SearchService,
    SearchResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
