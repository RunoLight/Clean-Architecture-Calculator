using CleanArchitecturePattern;
using TMPro;
using UnityEngine.UI;

namespace Calculator.Presenter
{
    public interface ICalculatorView : IView
    {
        Button Button { get; }
        TMP_InputField InputField { get; }
    }
}