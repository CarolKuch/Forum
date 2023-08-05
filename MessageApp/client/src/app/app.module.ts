import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageComponent } from './messages/message/message.component';
import { NavigationComponent } from './navigation/navigation.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CategoryComponent } from './categories/category/category.component';
import { CategoriesComponent } from './categories/categories.component';
import { TopicComponent } from './topics/topic/topic.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { TopicsComponent } from './topics/topics.component';
import { MessagesComponent } from './messages/messages.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    MessageComponent,
    NavigationComponent,
    CategoryComponent,
    CategoriesComponent,
    TopicComponent,
    PageNotFoundComponent,
    TopicsComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
