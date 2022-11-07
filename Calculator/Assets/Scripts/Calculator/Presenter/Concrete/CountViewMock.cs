using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.Presenter.Concrete
{
    public class CountViewMock : ICalculatorView
    {
        private readonly GameObject _gameObject = new();

        public Button Button =>
            _gameObject.GetComponent<Button>() ?? _gameObject.AddComponent<Button>();

        public TMP_InputField InputField =>
            _gameObject.GetComponent<TMP_InputField>() ?? _gameObject.AddComponent<TMP_InputField>();
    }
}