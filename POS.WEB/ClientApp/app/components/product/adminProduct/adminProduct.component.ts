import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductComponent } from '../mainProduct/mainProduct.component';
import { ServiceProduct } from '../../../Services/ServiceProduct.service';
@Component({
    selector: 'CreateProduct',
    templateUrl: './adminProduct.component.html'
})
export class CreateProduct implements OnInit {
    productoForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _productoService: ServiceProduct, private _router: Router) {

        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }
        this.productoForm = this._fb.group({
            id: 0,
            idCategoria: 0,
            idProveedor: 0,
            idUnidadMedida: 0,
            idImpuesto: 0,
            idExoneracion: 0,
            //Nombre: ['', [Validators.required]],
            nombre: '',
            detalle: '',
            cantidadDisponible: 0,
            precioUnitario: 0,
            costoUnitario: 0,
            codigo: '',
            fechaCreacion: '',
            fechaModificacion: '',
            gravado: [''],
            activo: [true]          
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
                    this._router.navigate(['/Productos']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._productoService.updateProducto(this.productoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Productos']);
                }, error => this.errorMessage = error)
        }
    }
    cancel() {
        this._router.navigate(['/Productos']);
    }
    get nombre() { return this.productoForm.get('nombre'); }
    get codigo() { return this.productoForm.get('codigo'); }   
    get idcategoria() { return this.productoForm.get('idCategoria'); }
    get detalle() { return this.productoForm.get('detalle');}
    get idProveedor() { return this.productoForm.get('idProveedor'); }
    get idunidadmedida() { return this.productoForm.get('idUnidadMedida'); }
    get idimpuesto() { return this.productoForm.get('idImpuesto'); }
    get idexoneracion() { return this.productoForm.get('idExoneracion'); }
    get cantidaddisponible() { return this.productoForm.get('cantidadDisponible'); }
    get preciounitario() { return this.productoForm.get('precioUnitario'); }
    get costounitario() { return this.productoForm.get('costoUnitario'); }
    get fechacreacion() { return this.productoForm.get('fechaCreacion'); }
    get fechamodificacion() { return this.productoForm.get('fechaModificacion'); }
    get gravado() { return this.productoForm.get('gravado'); }
    
}