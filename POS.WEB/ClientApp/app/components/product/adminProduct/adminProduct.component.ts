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
    public productoCategoriaList: ProductoCategoria[];
    public Listproveedores: ProveedorData[];
    public ListunidadMedida: UnidadMedidaData[];
    public ListImpuesto: ImpuestoData[];

    defaultDD: string = 'None';

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _productoService: ServiceProduct, private _router: Router) {
        
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }
        this._productoService.getCategoriaProducto().subscribe(
            data => this.productoCategoriaList = data
        )
        this._productoService.getGetTipoUnidadMedida().subscribe(
            data => this.ListunidadMedida = data
        )
        this._productoService.getProveedores().subscribe(
            data => this.Listproveedores = data
        )
        this._productoService.getTipoImpuestos().subscribe(
            data => this.ListImpuesto = data
        )
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
            activo: [true],
            categoria: new FormControl(null), 
            proveedor: new FormControl(null),
            unidadMedida: new FormControl(null),
            impuesto: new FormControl(null)           
        })        
        this.productoForm.controls['categoria'].setValue(this.defaultDD, { onlySelf: true });
        this.productoForm.controls['proveedor'].setValue(this.defaultDD, { onlySelf: true });
        this.productoForm.controls['unidadMedida'].setValue(this.defaultDD, { onlySelf: true });
        this.productoForm.controls['impuesto'].setValue(this.defaultDD, { onlySelf: true });

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

interface ProductoCategoria {
    Id: number;
    NombreCategoria: string;
    Descripcion: string;
    Activo: string;
}

interface ProveedorData {
    Id: number;
    IdIdentificacion: number;
    IdUbicacion: number;
    IdTipoFigura: number;
    Identificacion: string;
    Nombre: string;
    NombreComercial: string;
    CorreoElectronico: string;
    FechaNacimiento: Date;
    Tel_CodigoPais: Date;
    Tel_Numero: string;
    Fax_CodigoPais: string;
    Fax_Numero: string;
    Direccion_OtrasSenas: string;
    EsCorreoValido: boolean;
    Activo: boolean;
}
interface UnidadMedidaData {
    Id: number;
    Descripcion: string;
    Codigo: string;
    Activo: boolean;
}

interface ImpuestoData {
    Id: number;
    Descripcion: string;
    Codigo: string;
    Excepcion: boolean;
}