using Calculator_gRPC.Models;
using System;

namespace Calculator_gRPC.BL.Classes
{
    public class CalculatorOperation 
    {
        public static Result Execute(int typeOfOperation, Parameters[] values)
        {
            var result = new Result();
            if (IsTypeOfOperationCorrect(typeOfOperation))
            {
                try
                {
                    result.Type = typeOfOperation;
                    foreach (var currentValue in values)
                    {
                        if (IsValueFirst(result))
                        {
                            result.Description = currentValue.Name;
                            result.CalculateResut = currentValue.Value;
                        }
                        else
                        {
                            result.Description = AddValueNameInString(typeOfOperation, result.Description, currentValue.Name);
                            result.CalculateResut = CalculateValuesAndRoundResult(typeOfOperation, result.CalculateResut, currentValue.Value, 4);
                        }
                    }
                } catch
                {
                    throw;
                }
            } else
            {
                throw new Exception("Invalid type of Operation");
            }
            return result;
        }

        private static bool IsValueFirst(Result value)
            => value.Description == "";
        
        private static bool IsTypeOfOperationCorrect(int typeOfOperation)
            => typeOfOperation >= 0 && (typeOfOperation < 4);

        private static string AddValueNameInString(int typeOfOperation, string baseString, string addedString)
            => BasicOperations.ConcatStringsForValues(typeOfOperation, baseString, addedString);

        private static decimal CalculateValuesAndRoundResult(int typeOfOperation, decimal baseValue, decimal addedValue, int numberOfDigitsAfterPoint)
            => Math.Round(BasicOperations.CalculateValues(typeOfOperation, baseValue, addedValue), numberOfDigitsAfterPoint);
    }
}
