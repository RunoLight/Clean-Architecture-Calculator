using Calculator.Domain;
using Calculator.Domain.UseCase;
using UnityEngine;
using Zenject;

namespace Calculator.EntryPoint
{
    public sealed class Main : MonoBehaviour, IMain
    {
        private CalculatorUseCase _useCase;

        [Inject]
        private void ConstructUseCases(ICalculatorPresenter presenter, ICalculatorRepository repository)
        {
            _useCase = new CalculatorUseCase(presenter, repository);
        }

        private void Awake()
        {
            _useCase.Begin();
        }

        private void OnDestroy()
        {
            _useCase.Finish();
        }
    }
}