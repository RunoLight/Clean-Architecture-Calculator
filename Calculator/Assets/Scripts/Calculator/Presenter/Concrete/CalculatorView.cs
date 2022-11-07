using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Presenter.Concrete
{
    public class CalculatorView : MonoBehaviour, ICalculatorView {
        [SerializeField] private TMP_InputField   inputField = default;
        [SerializeField] private Button   button = default;

        Button ICalculatorView.Button => button;
        TMP_InputField ICalculatorView.InputField => inputField;
    }
}