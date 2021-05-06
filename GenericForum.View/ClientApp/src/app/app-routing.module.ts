import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TokenActivateBlockPages } from './app.service';
import { CreateTopicComponent } from './create-topic/create-topic.component';
import { ListTopicBriefComponent } from './list-topic-brief/list-topic-brief.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { PerfilComponent } from './perfil/perfil.component';
import { RegisterComponent } from './register/register.component';
import { SearchComponent } from './search/search.component';
import { TopicComponent } from './topic/topic.component';


const routes: Routes = [
  
  {
    path: '',
    component: ListTopicBriefComponent
  },
  {
    path: 'topic/:id',
    component: TopicComponent
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [ TokenActivateBlockPages ]
  },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [ TokenActivateBlockPages ]
  },
  {
    path: 'perfil/:id',
    component: PerfilComponent
  },
  {
    path: 'createtopic',
    component: CreateTopicComponent
  },
  {
    path: 'search',
    component: SearchComponent,
    
  },
  {
    path: '**',
    component: NotFoundComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
