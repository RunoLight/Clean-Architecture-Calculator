using Calculator.Domain;
using Calculator.Domain.UseCase;
using Calculator.Repository.DataStore;
using CleanArchitecturePattern;
using UnityEngine;
using Zenject;

namespace Calculator.EntryPoint
{
    public sealed class ExampleMain : MonoBehaviour, IMain
    {
        IUseCase usecase;

        [Inject]
        void ConstructUseCases(ICalculatorPresenter presenter, ICalculatorRepository repository)
        {
            usecase = new CountUseCase(presenter, repository);
        }

        void Awake()
        {
            usecase.Begin();
        }

        void OnDestroy()
        {
            usecase.Finish();
        }
    }
}