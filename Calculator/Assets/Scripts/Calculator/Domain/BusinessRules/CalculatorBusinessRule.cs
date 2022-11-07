using System.Linq;
using Calculator.ValueObjects;

namespace Calculator.Domain.BusinessRules
{
    public class CalculatorBusinessRule
    {
        private readonly char[] _allowedCharacters =
        {
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+'
        };

        private const string ErrorMessage = "Error";

        /// <summary>
        /// Validates current state, then calculates if validated, send error message otherwise
        /// </summary>
        /// <returns> New current state of value object </returns>
        public string TryCalculate(CalculatorValueObject vo)
        {
            var validated = vo.State.All(c => _allowedCharacters.Contains(c)) &&
                            string.IsNullOrEmpty(vo.State) == false &&
                            string.IsNullOrWhiteSpace(vo.State) == false &&
                            vo.State.Split('+').All(numString => numString.Length != 0);

            if (validated)
            {
                vo.Calculate();
            }
            else
            {
                vo.SetMessage(ErrorMessage);
            }

            return vo.State;
        }

        public string SetText(CalculatorValueObject count, string text)
        {
            count.SetMessage(text);
            return count.State;
        }
    }
}