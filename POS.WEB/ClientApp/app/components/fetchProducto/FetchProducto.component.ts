import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductService } from '../../Services/Product.Service';
@Component({
    selector: 'fetchProducto',
    templateUrl: './FetchProducto.component.html'
})
export class FetchProductoComponent {
    public productList:ProductoData[];

    constructor(public http: Http, private _router: Router, private _productService: ProductService) {
        this.getProductos();
    }
    getProductos() {
        this._productService.getProductos().subscribe(
            data => this.productList = data
        )
       
    }
    /*delete(employeeID) {
        var ans = confirm("Do you want to delete customer with Id: " + employeeID);
        if (ans) {
            this._productService.deleteEmployee(employeeID).subscribe((data) => {
                this.getProductos();
            }, error => console.error(error))
        }
    }*/
}
interface ProductoData {
    Id: number;
    IdCategoria: number;
    IdProveedor: number;
    IdUnidadMedida: number;
    IdImpuesto: number;
    IdExoneracion: number;
    Nombre: string;
    Detalle: string;
    CantidadDisponible: number;
    PrecioUnitario: number;
    CostoUnitario: number;
    Codigo: string;
    FechaCreacion: Date;
    FechaModificacion: Date;
    Gravado: string;
    Activo: boolean     
       
}