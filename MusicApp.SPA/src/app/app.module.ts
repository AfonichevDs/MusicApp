import { LoggedInGuard, AuthGuard } from './_guards/auth.guard';
import { AlertifyService } from './_services/alertify.service';
import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HeaderComponent } from './header/header.component';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { CollapseModule } from 'ngx-bootstrap';
import { SongListComponent } from './song-list/song-list.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    ControlPanelComponent,
    SongListComponent
],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    CollapseModule.forRoot()
  ],
  providers: [
    AuthService,
    AlertifyService,
    LoggedInGuard,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
