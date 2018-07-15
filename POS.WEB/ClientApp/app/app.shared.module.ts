import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ProductComponent } from './components/product/mainProduct/mainProduct.component';
import { CreateProduct } from './components/product/adminProduct/adminProduct.component';
import { ServiceProduct } from './Services/ServiceProduct.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ProductComponent,
        CreateProduct,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'Productos', component: ProductComponent },
            { path: 'register-producto', component: CreateProduct },
            { path: 'producto/edit/:id', component: CreateProduct },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ServiceProduct]
})
export class AppModuleShared {
}
