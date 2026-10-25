using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalculator.Maui.Models
{
    public class ConsumoCompartido
    {
        //Propiedades necesarias para realizar los calculos
        public decimal ImporteDelConsumo {  get; set; }

        public int NumeroDePersonas {  get; set; }

        public decimal PorcentajeDePropina {  get; set; }



        //Propiedades que guardan los calculos resultantes
        public decimal ImporteDelConsumoPorPersona 
            => ImporteDelConsumo / NumeroDePersonas;

        public decimal ImporteDelaPropina
            => ImporteDelConsumo * PorcentajeDePropina / 100.0m;

        public decimal ImporteDelaPropinaPorPersona
            => ImporteDelaPropina / NumeroDePersonas;

        public decimal ImporteTotalConPropina
            => ImporteDelConsumo + ImporteDelaPropina;

        public decimal ImporteTotalConPropinaPorPersona
            => ImporteTotalConPropina / NumeroDePersonas;

        public ConsumoCompartido(
            decimal importeDelConsumo,
            int numeroDePersonas,
            decimal porcentajeDePropina)
        {
            ImporteDelConsumo = importeDelConsumo;
            NumeroDePersonas = numeroDePersonas;
            PorcentajeDePropina = porcentajeDePropina;
        }
    }
}
