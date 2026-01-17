using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Develop._1._2.Timer;
using Develop._1._2.Timer.Develop.Example2;

namespace Develop._1._1.Wallet
{
    public class Wallet
    {
        private readonly Dictionary<CurrencyType, ReactiveVariable<int>> _account;

        public Wallet(Dictionary<CurrencyType, ReactiveVariable<int>> currencies)
        {
            _account = new Dictionary<CurrencyType, ReactiveVariable<int>>(currencies);
        }

        public IReadOnlyDictionary<CurrencyType, IReadOnlyVariable<int>> Account 
            => _account.ToDictionary(pair => pair.Key, pair => (IReadOnlyVariable<int>)pair.Value);

        public void AddCurrency(CurrencyType currency, int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Currency amount cannot be negative");

            if(_account.TryGetValue(currency, out ReactiveVariable<int> variable))
            {
                variable.Value += amount;
                PrintWalletOperation(currency, amount);
                return;
            }

            throw new ArgumentException("Currency not found", nameof(currency));
        }

        public bool TrySpendCurrency(CurrencyType currency, int amount)
        {
            if(amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Currency amount cannot be negative");

            if(_account.TryGetValue(currency, out ReactiveVariable<int> variable))
            {
                if(variable.Value - amount < 0)
                    return false;

                variable.Value -= amount;

                PrintWalletOperation(currency, amount);
                return true;
            }

            throw new ArgumentException("Currency not found", nameof(currency));
        }

        private void PrintWalletOperation(CurrencyType currency, int amount) 
            => Debug.Log($"Added {amount} to {currency}.");
    }
}
