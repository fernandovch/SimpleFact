import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchProductoComponent } from '../fetchProducto/FetchProducto.component';
import { ProductService } from '../../Services/Product.Service';
@Component({
    selector: 'createproducto',
    templateUrl: './AgregarProducto.component.html'
})
export class createproducto implements OnInit {
    productoForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _productoService: ProductService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }
        this.productoForm = this._fb.group({
            id: 0,
            idcategoria: 0,
            IdProveedor: 0,
            IdUnidadMedida: 0,
            IdImpuesto: 0,
            IdExoneracion: 0,
            // Nombre: ['', [Validators.required]],
            Nombre: [''],
            Detalle: [''],
            CantidadDisponible: 0,
            PrecioUnitario: 0,
            CostoUnitario: 0,
            Codigo: [''],
            FechaCreacion: [Date],
            FechaModificacion: [Date],
            Gravado: [''],
            Activo: [true]          
        })
    }
    ngOnInit() {
        if (this.id != null) {
            this.title = "Edit";
            this._productoService.getproductoId(this.id)
                .subscribe(resp => this.productoForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }
    save() {
        if (!this.productoForm.valid) {
            return;
        }
        if (this.title == "Create") {
            this._productoService.saveProducto(this.productoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-producto']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._productoService.updateProducto(this.productoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-producto']);
                }, error => this.errorMessage = error)
        }
    }
    cancel() {
        this._router.navigate(['/fetch-producto']);
    }
    get nombre() { return this.productoForm.get('nombre'); }
    get codigo() { return this.productoForm.get('codigo'); }   
    get idcategoria() { return this.productoForm.get('idcategoria'); }
    get idProveedor() { return this.productoForm.get('idproveedor'); }
    get idunidadmedida() { return this.productoForm.get('idunidadmedida'); }
    get idimpuesto() { return this.productoForm.get('idimpuesto'); }
    get idexoneracion() { return this.productoForm.get('idexoneracion'); }
    get cantidaddisponible() { return this.productoForm.get('cantidaddisponible'); }
    get preciounitario() { return this.productoForm.get('preciounitario'); }
    get costounitario() { return this.productoForm.get('costounitario'); }
    get fechacreacion() { return this.productoForm.get('fechacreacion'); }
    get fechamodificacion() { return this.productoForm.get('fechamodificacion'); }
    get gravado() { return this.productoForm.get('gravado'); }
    
}