using POS.Data.DataAccess;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Mantenimiento
{
    public class MantenimientoPersona
    {
        private IGenericRepository<Persona> Interface_persona;
        private IGenericRepository<Ubicacion> Interface_ubicacion;
        private IGenericRepository<TipoFigura> Interface_tipoFigura;
        private IGenericRepository<LogErrores> Interface_logErrores;
        private IGenericRepository<TipoCedula> Interface_tipoCedula;

        public MantenimientoPersona(IGenericRepository<Persona> _persona, IGenericRepository<Ubicacion> _ubicacion, 
                IGenericRepository<TipoFigura> _tipoFigura, IGenericRepository<LogErrores> _logErrores, IGenericRepository<TipoCedula> _tipoCedula)
        {
            Interface_persona = _persona;
            Interface_ubicacion = _ubicacion;
            Interface_tipoFigura = _tipoFigura;
            Interface_logErrores = _logErrores;
            Interface_tipoCedula = _tipoCedula;
        }

        /// <summary>
        /// Buscar persona por # de cédula.
        /// </summary>
        /// <param name="_cedula"></param>
        /// <returns></returns>
        public List<Persona> BuscarPersonaPorCedula(string _cedula)
        {
            List<Persona> Result;           
            try
            {
                Result = Interface_persona.FindBy(x => x.Identificacion == _cedula);
                return Result;
            }
            catch (Exception _ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Seleccionar todos los Tipos de figuras que estén activos.
        /// </summary>
        /// <returns></returns>
        public List<TipoFigura> SeleccionarTipoFigura()
        {
            List<TipoFigura> ListTipoFigura;            
            try
            {
                ListTipoFigura = Interface_tipoFigura.FindBy(x => x.Activo == true);
                return ListTipoFigura;
            }
            catch (Exception _ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Agregar una entidad persona nueva.
        /// </summary>
        /// <param name="_idIdentificacion"></param>
        /// <param name="_idUbicacion"></param>
        /// <param name="_idTipoFigura"></param>
        /// <param name="_identificacion"></param>
        /// <param name="_nombre"></param>
        /// <param name="_nombreComercial"></param>
        /// <param name="_correoElectronico"></param>
        /// <param name="_fechaNacimiento"></param>
        /// <param name="_telCodïgoPais"></param>
        /// <param name="_TelNumero"></param>
        /// <param name="_faxCodigoPais"></param>
        /// <param name="_faxNumero"></param>
        /// <param name="_direccionOtrasSenas"></param>
        /// <param name="_esCorreoValido"></param>
        /// <param name="_activo"></param>
        /// <returns></returns>
        public Persona AgregarPersona(int _idIdentificacion, int _idUbicacion, int _idTipoFigura, string _identificacion, string _nombre,
            string _nombreComercial, string _correoElectronico, DateTime _fechaNacimiento, string _telCodïgoPais, string _TelNumero, 
            string _faxCodigoPais, string _faxNumero, string _direccionOtrasSenas, bool _esCorreoValido, bool _activo)
        {
            Persona p;
            try
            {
                p = new Persona();
                p.IdIdentificacion = _idIdentificacion;
                p.IdUbicacion = _idUbicacion;
                p.IdTipoFigura = _idTipoFigura;
                p.Identificacion = _identificacion;
                p.Nombre = _nombre;
                p.NombreComercial = _nombreComercial;
                p.CorreoElectronico = _correoElectronico;
                p.FechaNacimiento = _fechaNacimiento;
                p.TelCodïgoPais = _telCodïgoPais;
                p.TelNumero = _TelNumero;
                p.FaxCodïgoPais = _faxCodigoPais;
                p.FaxNumero = _faxNumero;
                p.DireccionOtrasSenas = _direccionOtrasSenas;
                p.EsCorreoValido = _esCorreoValido;
                p.Activo = _activo;
                return Interface_persona.Add(p);

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Actualizar informacion de la entidad persona.
        /// </summary>
        /// <param name="_idIdentificacion"></param>
        /// <param name="_idUbicacion"></param>
        /// <param name="_idTipoFigura"></param>
        /// <param name="_identificacion"></param>
        /// <param name="_nombre"></param>
        /// <param name="_nombreComercial"></param>
        /// <param name="_correoElectronico"></param>
        /// <param name="_fechaNacimiento"></param>
        /// <param name="_telCodïgoPais"></param>
        /// <param name="_TelNumero"></param>
        /// <param name="_faxCodigoPais"></param>
        /// <param name="_faxNumero"></param>
        /// <param name="_direccionOtrasSenas"></param>
        /// <param name="_esCorreoValido"></param>
        /// <param name="_activo"></param>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Persona ModificarPersona(int? _idIdentificacion, int? _idUbicacion, int _idTipoFigura, string _identificacion, string _nombre,
          string _nombreComercial, string _correoElectronico, DateTime _fechaNacimiento, string _telCodïgoPais, string _TelNumero,
          string _faxCodigoPais, string _faxNumero, string _direccionOtrasSenas, bool _esCorreoValido, bool _activo, int _id)
        {
            Persona p;
            try
            {
                p = new Persona();
                p.IdIdentificacion = _idIdentificacion;
                p.IdUbicacion = _idUbicacion;
                p.IdTipoFigura = _idTipoFigura;
                p.Identificacion = _identificacion;
                p.Nombre = _nombre;
                p.NombreComercial = _nombreComercial;
                p.CorreoElectronico = _correoElectronico;
                p.FechaNacimiento = _fechaNacimiento;
                p.TelCodïgoPais = _telCodïgoPais;
                p.TelNumero = _TelNumero;
                p.FaxCodïgoPais = _faxCodigoPais;
                p.FaxNumero = _faxNumero;
                p.DireccionOtrasSenas = _direccionOtrasSenas;
                p.EsCorreoValido = _esCorreoValido;
                p.Activo = _activo;
                return Interface_persona.Update(p, _id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
