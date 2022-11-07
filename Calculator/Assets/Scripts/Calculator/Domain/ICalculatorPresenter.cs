using System;
using CleanArchitecturePattern;
using UniRx;

namespace Calculator.Domain
{
    public interface ICalculatorPresenter : IPresenter
    {
        IObservable<Unit> ButtonClickObservable { get; }
        IObservable<string> TextChangedObservable { get; }
        void SetText(string text);
        string GetText();
    }
}