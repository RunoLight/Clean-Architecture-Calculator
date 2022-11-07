using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Calculator.Repository.DataStore
{
    public class PlayerPrefsCalculatorDataStore : ICalculatorDataStore {
        public const string Key = "CalculatorState";

        UniTask<string> ICalculatorDataStore.LoadState() {
            return UniTask.FromResult(PlayerPrefs.GetString(Key, ""));
        }

        UniTask ICalculatorDataStore.SaveState(string state) {
            PlayerPrefs.SetString(Key, state);
            return UniTask.CompletedTask;
        }
    }
}