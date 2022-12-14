import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowAllComponent } from './show-all/show-all.component';
import { ShowOneComponent } from './show-one/show-one.component';

const routes: Routes = [
	{ path: '', component: ShowAllComponent },
	{ path: ':id', component: ShowOneComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
