import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowAllComponent } from './show-all/show-all.component';
import { ShowOneComponent } from './show-one/show-one.component';

@NgModule({
	declarations: [
		AppComponent,
		ShowAllComponent,
		ShowOneComponent
	],
	imports: [
		BrowserModule,
		AppRoutingModule
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }
