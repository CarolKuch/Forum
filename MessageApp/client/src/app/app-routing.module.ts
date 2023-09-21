import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TopicComponent } from './topics/topic/topic.component';
import { CategoriesComponent } from './categories/categories.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { TopicsComponent } from './topics/topics.component';
import { MessageComponent } from './messages/message/message.component';
import { MessagesComponent } from './messages/messages.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'categories', component: CategoriesComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'topics/:categoryId', component: TopicsComponent },
  { path: 'Topic/:topisId/messages', component: MessagesComponent },
  { path: '', redirectTo: '/categories', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
