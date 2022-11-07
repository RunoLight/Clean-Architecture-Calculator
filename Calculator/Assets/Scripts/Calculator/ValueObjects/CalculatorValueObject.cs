using System;
using System.Linq;

namespace Calculator.ValueObjects
{
    public class CalculatorValueObject
    {
        public string State { private set; get; }

        public CalculatorValueObject(string state)
        {
            State = state;
        }

        /// <summary>
        /// Business rules makes sure there's only 0-9 digit numbers divided by '+' char
        /// </summary>
        public void Calculate()
        {
            if (State.Contains('+'))
            {
                State = State.Split('+').Select(s => Convert.ToInt32(s)).Sum().ToString();
            }
        }

        public void SetMessage(string message)
        {
            State = message;
        }
    }
}