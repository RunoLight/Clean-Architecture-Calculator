using CleanArchitecturePattern;
using Cysharp.Threading.Tasks;

namespace Calculator.Repository.DataStore
{
    public interface ICalculatorDataStore : IDataStore
    {
        UniTask<string> LoadState();
        UniTask SaveState(string state);
    }
}