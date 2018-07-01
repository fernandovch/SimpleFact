using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.BLogic.Interfaces
{
    public interface IMantemientoPersona
    {
        List<Persona> BuscarPersonaPorCedula(string _cedula);

        List<TipoFigura> SeleccionarTipoFigura();

        Persona AgregarPersona(Persona _persona);

        Persona ModificarPersona(Persona _persona);

        List<TipoCedula> SeleccionarTipoCedula();
    }
}
