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
import { FetchProductoComponent } from './components/fetchProducto/FetchProducto.component';
import { createproducto } from './components/AgregarProducto/AgregarProducto.component';
import { ProductService } from './Services/Product.Service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchProductoComponent,
        createproducto,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-producto', component: FetchProductoComponent },
            { path: 'register-producto', component: createproducto },
            { path: 'producto/edit/:id', component: createproducto },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ProductService]
})
export class AppModuleShared {
}
