using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Develop._1._1.Wallet
{
    public class Wallet
    {
        private readonly List<ReactiveVariable<CurrencyType, int>> _account;

        public Wallet(List<ReactiveVariable<CurrencyType, int>> currencies)
        {
            _account = new List<ReactiveVariable<CurrencyType, int>>(currencies);
        }

        public IEnumerable<ReactiveVariable<CurrencyType, int>> Account => _account;

        public void AddCurrency(CurrencyType currency, int amount)
        {
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Currency amount cannot be negative");

            ReactiveVariable<CurrencyType, int> found =
                _account.First(accountCurrency => accountCurrency.Key == currency);

            if(found.Key == currency)
            {
                found.Value += amount;
                PrintWalletOperation(currency, amount);
                return;
            }

            throw new ArgumentException("Currency not found", nameof(currency));
        }

        public bool TrySpendCurrency(CurrencyType currency, int amount)
        {
            if(amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Currency amount cannot be negative");

            ReactiveVariable<CurrencyType, int> found =
                _account.First(accountCurrency => accountCurrency.Key == currency);

            if(found.Key == currency)
            {
                if(found.Value - amount < 0)
                    return false;

                found.Value -= amount;

                PrintWalletOperation(currency, amount);
                return true;
            }

            throw new ArgumentException("Currency not found", nameof(currency));
        }

        private void PrintWalletOperation(CurrencyType currency, int amount) 
            => Debug.Log($"Added {amount} to {currency}.");
    }
}
