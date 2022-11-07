using Calculator.Domain;
using Calculator.Repository.DataStore;
using Cysharp.Threading.Tasks;

namespace Calculator.Repository
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly ICalculatorDataStore _dataStore;

        public CalculatorRepository(ICalculatorDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        UniTask<string> ICalculatorRepository.GetStateAsync()
        {
            return _dataStore.LoadState();
        }

        UniTask ICalculatorRepository.SetStateAsync(string state)
        {
            return _dataStore.SaveState(state);
        }
    }
}