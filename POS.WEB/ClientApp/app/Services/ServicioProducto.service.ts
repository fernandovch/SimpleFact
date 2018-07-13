import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { resetFakeAsyncZone } from '@angular/core/testing';
@Injectable()
export class ServicioProducto {
    myAppUrl: string = "";
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }
    getProductos() {
        
        return this._http.get(this.myAppUrl + 'Producto/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }
    getproductoId(id: number) {
        return this._http.get(this.myAppUrl + "Producto/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)

    } 
    saveProducto(producto) {
        return this._http.post(this.myAppUrl + 'Producto/Create', producto)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }
    updateProducto(producto) {
        return this._http.put(this.myAppUrl + 'Producto/Edit/', producto)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }
   
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}