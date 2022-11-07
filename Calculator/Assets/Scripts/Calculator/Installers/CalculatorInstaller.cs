using Calculator.Domain;
using Calculator.Presenter;
using Calculator.Presenter.Concrete;
using Calculator.Repository;
using Calculator.Repository.DataStore;
using UnityEngine;
using Zenject;

namespace Calculator.Installers
{
    public class CalculatorInstaller : MonoInstaller, IInstaller
    {
        [SerializeField] private CalculatorView view = default;

        public override void InstallBindings()
        {
            Container
                .Bind<ICalculatorPresenter>()
                .FromInstance(new CalculatorPresenter(view))
                .AsCached();
            Container
                .Bind<ICalculatorRepository>()
                .FromInstance(new CalculatorRepository(new PlayerPrefsCalculatorDataStore()))
                .AsCached();
        }

        [ContextMenu("Reset data")]
        private void ClearPersistentSessionData()
        {
            PlayerPrefs.DeleteKey(PlayerPrefsCalculatorDataStore.Key);
        }
    }
}