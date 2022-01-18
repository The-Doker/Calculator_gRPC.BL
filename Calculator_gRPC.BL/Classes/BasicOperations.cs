using System;

namespace Calculator_gRPC.BL.Classes
{
    public class BasicOperations
    {
        public static decimal CalculateValues(int typeOfOperation, decimal firstValue, decimal secondValue)
        {
            switch (typeOfOperation)
            {
                //Add
                case 0: return firstValue + secondValue;
                //Sub
                case 1: return firstValue - secondValue;
                //Mul
                case 2: return firstValue * secondValue;
                //Div
                case 3:
                    if (secondValue == 0) throw new Exception("Divine by zero");
                    return firstValue / secondValue;
                default: return 0;
            }
        }

        public static string ConcatStringsForValues(int typeOfOperation, string firstValue, string secondValue)
        {
            switch (typeOfOperation)
            {
                case 0: return firstValue + " + " + secondValue;
                case 1: return firstValue + " - " + secondValue;
                case 2: return firstValue + " * " + secondValue;
                case 3: return firstValue + " / " + secondValue;
                default: return "Unhandled";
            }
        }
    }
}
