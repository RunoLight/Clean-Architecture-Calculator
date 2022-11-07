﻿using Calculator.Domain.BusinessRules;
using Calculator.ValueObjects;
using CleanArchitecturePattern;
using UniRx;

namespace Calculator.Domain.UseCase
{
    public sealed class CountUseCase : IUseCase {
        private readonly ICalculatorPresenter     _presenter;
        private readonly ICalculatorRepository    _repository;
        private readonly CompositeDisposable _disposables;
        private readonly CalculatorBusinessRule           _calculator;

        public CountUseCase(ICalculatorPresenter presenter, ICalculatorRepository repository) {
            _presenter = presenter;
            _repository = repository;
            _disposables = new CompositeDisposable();
            _calculator = new CalculatorBusinessRule();
        }

        async void IUseCase.Begin() {
            var init = await _repository.GetStateAsync();
            _presenter.SetText($"{init}");
            var valueObject = new CalculatorValueObject(init);
            _presenter
                .ButtonClickObservable
                .Subscribe(async _ => {
                    var oldState = valueObject.State;
                    var newState = _calculator.TryCalculate(valueObject);
                    if (oldState != newState) {
                        _presenter.SetText($"{newState}");
                        await _repository.SetStateAsync(newState);
                    }
                })
                .AddTo(_disposables);
            _presenter
                .TextChangedObservable
                .Subscribe(async _ =>
                {
                    var oldState = valueObject.State; 
                    var newState = _calculator.SetText(valueObject, _presenter.GetText());
                    if (oldState != newState) {
                        await _repository.SetStateAsync(newState);
                    }
                })
                .AddTo(_disposables);
        }

        void IUseCase.Finish() {
            _disposables.Dispose();
        }
    }

}