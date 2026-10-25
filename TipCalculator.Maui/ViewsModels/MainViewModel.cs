using TipCalculator.Maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.Input;

namespace TipCalculator.Maui.ViewsModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _importeDelConsumo;
        [ObservableProperty]
        private string _numeroDePersonas;
        [ObservableProperty]
        private string _porcentajeDePropina;

        //Variable de instancia para resulltados de la UI
        [ObservableProperty]
        public string _importeDelConsumoDuplicado;
        [ObservableProperty]
        public string _importeDelConsumoPorPersona;
        [ObservableProperty]
        public string _importeDelaPropina;
        [ObservableProperty]
        public string _importeDelaPropinaPorPersona;
        [ObservableProperty]
        public string _importeTotalConPropina;
        [ObservableProperty]
        public string _importeTotalConPropinaPorPersona;

        public MainViewModel()
        {
            Limpiar(); 
        }

        [RelayCommand]
        public void CalcularPropina() 
        {
            decimal importeDelConsumo;
            int numeroDePersonas;
            decimal porcentajeDePropina;

            bool importeDelConsumoEsValido
                = decimal.TryParse(ImporteDelConsumo, out importeDelConsumo);
            bool numeroDePersonasEsValido
                = int.TryParse(NumeroDePersonas, out numeroDePersonas);
            bool porcentajeDePropinaEsValido
                = decimal.TryParse(PorcentajeDePropina,out porcentajeDePropina);

            if (importeDelConsumoEsValido 
                && numeroDePersonasEsValido
                && porcentajeDePropinaEsValido)
            {
                var consumo =
                    new ConsumoCompartido(
                        importeDelConsumo,
                        numeroDePersonas,
                        porcentajeDePropina);

                ImporteDelConsumoDuplicado =
                    consumo.ImporteDelConsumo.ToString("C2");
                ImporteDelConsumoPorPersona = 
                    consumo.ImporteDelConsumoPorPersona.ToString("C2");
                ImporteDelaPropina =
                    consumo.ImporteDelaPropina.ToString("C2");
                ImporteDelaPropinaPorPersona =
                    consumo.ImporteDelaPropinaPorPersona.ToString("C2");
                ImporteTotalConPropina =
                    consumo.ImporteTotalConPropina.ToString("C2");
                ImporteTotalConPropinaPorPersona =
                    consumo.ImporteTotalConPropinaPorPersona.ToString("C2");
            }
        }

        [RelayCommand]
        public void Limpiar()
        {
            ImporteDelConsumoDuplicado = string.Empty;
            ImporteDelConsumo = string.Empty;
            NumeroDePersonas = "1";
            PorcentajeDePropina = "10";
            ImporteDelConsumoPorPersona = string.Empty;
            ImporteDelaPropina = string.Empty;
            ImporteDelaPropinaPorPersona = string.Empty;
            ImporteTotalConPropina = string.Empty;
            ImporteTotalConPropinaPorPersona = string.Empty;
        }

        [RelayCommand]
        public void ActualizarPorcentajeDePropina(string nuevoPorcentaje)
        {
            PorcentajeDePropina = nuevoPorcentaje;
        }

    }
}
