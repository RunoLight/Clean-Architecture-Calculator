using System.Linq;
using Calculator.ValueObjects;
using UnityEngine;

namespace Calculator.Domain.BusinessRules
{
    public class CalculatorBusinessRule
    {
        private readonly char[] _allowedCharacters =
        {
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '0',
            '+'
        };

        private const string ErrorMessage = "Error";

        public string TryCalculate(CalculatorValueObject count)
        {
            var validated = count.State.All(c => _allowedCharacters.Contains(c)) &&
                            string.IsNullOrEmpty(count.State) == false &&
                            string.IsNullOrWhiteSpace(count.State) == false &&
                            count.State.Split('+').All(numString => numString.Length != 0);
            
            if (validated)
            {
                count.Calculate();
            }
            else
            {
                count.SetMessage(ErrorMessage);
            }

            return count.State;
        }

        public string SetText(CalculatorValueObject count, string text)
        {
            count.SetMessage(text);
            return count.State;
        }
    }
}