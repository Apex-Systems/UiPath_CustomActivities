using System.Activities.DesignViewModels;
using System.Reflection;
using static UiPath.Activities.Calculadora.Calculadora;

namespace UiPath.Activities.Calculadora.ViewModels
{
    public class CalculadoraViewModel : DesignPropertiesViewModel
    {
        /*
         * Aqui se vuelven a setear los argumentos para el dise;o de la activadad
         * 
         * Algo muy importante, los nombres de las propiedades deben ser nombradas 
         * igual en esta clase y en la clase que contiene la logica de la actividad
         */

        //Argumentos de entrada.
        public DesignInArgument<int> FirstNumber { get; set; }
        public DesignInArgument<int> SecondNumber { get; set; }
        public DesignProperty<Operation> SelectedOperation { get; set; }

        //Argumento de salida que viene desde la activadad con la logica.
        //Por default, esta propiedad siempre se llama "Result"
        public DesignOutArgument<int> Result { get; set; }

        public CalculadoraViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            /*
             * The base call will initialize the properties of the view model with the values from the xaml or with the default values from the activity
             */
            base.InitializeModel();

            PersistValuesChangedDuringInit(); // mandatory call only when you change the values of properties during initialization

            var orderIndex = 0;


            //Aqui se modifica la lista de propiedades para los argumentos.
            //Propiedades como si es obligatorio, el orden, el nombre, el tooltip

            //Lista de propiedades para el argumento FirstNumber
            FirstNumber.DisplayName = Resources.Calculator_FirstNumber_DisplayName;
            FirstNumber.Tooltip = Resources.Calculator_FirstNumber_Tooltip;
            /*
             * Required fields will automatically raise validation errors when empty.
             * Unless you do custom validation, required activity properties should be marked as such both in the view model and in the activity:
             *   -> in the view model use the IsRequired property
             *   -> in the activity use the [RequiredArgument] attribute.
             */
            FirstNumber.IsRequired = true;

            FirstNumber.IsPrincipal = true; // specifies if it belongs to the main category (which cannot be collapsed)
            FirstNumber.OrderIndex = orderIndex++; // indicates the order in which the fields appear in the designer (i.e. the line number);




            SecondNumber.DisplayName = Resources.Calculator_SecondNumber_DisplayName;
            SecondNumber.Tooltip = Resources.Calculator_SecondNumber_Tooltip;
            SecondNumber.IsRequired = true;
            SecondNumber.IsPrincipal = true;
            SecondNumber.OrderIndex = orderIndex++;

            SelectedOperation.DisplayName = Resources.Calculator_SelectedOperation_DisplayName;
            SelectedOperation.Tooltip = Resources.Calculator_SelectedOperation_Tooltip;
            SelectedOperation.IsRequired = true;
            SelectedOperation.IsPrincipal = true;
            SelectedOperation.OrderIndex = orderIndex++;


            /*
             * Output properties are never mandatory.
             * By convention, they are not principal and they are placed at the end of the activity.
             */

            Result.DisplayName = Resources.Calculator_Result_DisplayName;
            Result.Tooltip = Resources.Calculator_Result_Tooltip;
            Result.OrderIndex = orderIndex;
        }
    }
}
