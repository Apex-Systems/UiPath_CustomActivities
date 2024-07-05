using System.Activities;
using System.Diagnostics;

namespace UiPath.Activities.Calculadora
{
    public class Calculadora : CodeActivity<int> // Esta clase calculadora regresara un argumento de tipo entero
    {
        //en esta seccion del codigo se configuran los argumentos que esta actividad tendram en este caso, seran 3 argumentos de entrada
        [RequiredArgument]
        public InArgument<int> FirstNumber { get; set; } //InArgument allows a varriable to be set from the workflow

        [RequiredArgument]
        public InArgument<int> SecondNumber { get; set; }

        [RequiredArgument]
        public Operation SelectedOperation { get; set; } = Operation.Multiply; // default value is optional
        
        
        
        
        
        protected override int Execute(CodeActivityContext context)
        {
            // aqui obtenemos los valores entrantes desde el workflow de uipath y los seteamos a una variable interna en nuestro codigo.
            var firstNumber = FirstNumber.Get(context); 
            var secondNumber = SecondNumber.Get(context);

            // Agregamos una validacion basica antes de entrar a la logica de la actividad.
            if (secondNumber == 0 && SelectedOperation == Operation.Divide)
            {
                throw new DivideByZeroException("Second number should not be zero when the selected operation is divide");
            }

            //Ejecutamos la funcion donde se ejecutara la logica de nuestra actividad, mandandole como parametros las dos variables internas
            //que previamente venian del workflow de uipath en ejecucion.
            return ExecuteInternal(firstNumber, secondNumber);
        }

        public int ExecuteInternal(int firstNumber, int secondNumber)
        {
            // Esta linea vincula el proceso de debug de uipath para poder ser debuggeado con visual studio,
            // Asi que donde esta linea se encuentre, visual studio se ejecutara para continuar el debug.
            Debugger.Launch();

            return SelectedOperation switch
            {
                Operation.Add => firstNumber + secondNumber,
                Operation.Subtract => firstNumber - secondNumber,
                Operation.Multiply => firstNumber * secondNumber,
                Operation.Divide => firstNumber / secondNumber,
                _ => throw new NotSupportedException("Operation not supported"),
            };
        }

        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
    }
}
