import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { TopicModule } from './topic/topic.module';
import { ListTopicBriefModule } from './list-topic-brief/list-topic-brief.module';
import { RegisterModule } from './register/register.module';
import { LoginModule } from './login/login.module';
import { PerfilModule } from './perfil/perfil.module';
import { CreateTopicModule } from './create-topic/create-topic.module';
import { HeaderModule } from './core/header/header.module';
import { SearchComponent } from './search/search.component';


@NgModule({
  declarations: [
    AppComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HeaderModule,
    CoreModule,
    ListTopicBriefModule,
    TopicModule,
    RegisterModule,
    LoginModule,
    PerfilModule,
    CreateTopicModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
