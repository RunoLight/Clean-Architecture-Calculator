using Cysharp.Threading.Tasks;

namespace Calculator.Repository.DataStore
{
    public class CalculatorDataStoreMock : ICalculatorDataStore
    {
        private string _state = "";

        public UniTask<string> LoadState()
        {
            return UniTask.FromResult(_state);
        }

        public UniTask SaveState(string state)
        {
            _state = state;
            return UniTask.CompletedTask;
        }
    }
}