using CleanArchitecturePattern;
using Cysharp.Threading.Tasks;

namespace Calculator.Domain
{
    public interface ICalculatorRepository : IRepository {
        UniTask SetStateAsync(string state);
        UniTask<string> GetStateAsync();
    }
}