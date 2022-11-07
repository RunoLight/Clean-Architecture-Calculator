using System;
using Calculator.Domain;
using UniRx;

namespace Calculator.Presenter
{
    public class CalculatorPresenter : ICalculatorPresenter
    {
        private readonly ICalculatorView _view;

        public CalculatorPresenter(ICalculatorView view)
        {
            _view = view;
        }

        IObservable<Unit> ICalculatorPresenter.ButtonClickObservable => _view.Button.OnClickAsObservable();
        public IObservable<string> TextChangedObservable => _view.InputField.onValueChanged.AsObservable();

        void ICalculatorPresenter.SetText(string text)
        {
            _view.InputField.text = text;
        }

        public string GetText()
        {
            return _view.InputField.text;
        }
    }
}