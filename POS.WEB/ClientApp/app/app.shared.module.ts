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
import { CrearProducto } from './components/RegistrarProducto/RegistrarProducto.component';
import { ServicioProducto } from './Services/ServicioProducto.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchProductoComponent,
        CrearProducto,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'Productos', component: FetchProductoComponent },
            { path: 'register-producto', component: CrearProducto },
            { path: 'producto/edit/:id', component: CrearProducto },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ServicioProducto]
})
export class AppModuleShared {
}
