using System.Collections.Generic;
using Develop._1._2.Timer.Develop.Example2;
using UnityEngine;

namespace Develop._1._1.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private RectTransform _currencyContainerTransform;

        private Wallet _wallet;
        private List<CurrencyView> _views;

        public void Initialize(Wallet wallet, List<CurrencyView> views) 
        {
            _wallet = wallet;
            _views = new List<CurrencyView>(views);

            foreach (KeyValuePair<CurrencyType, IReadOnlyVariable<int>> currency in _wallet.Account)
            {
                currency.Value.Changed += (oldValue, newValue) =>
                    OnCurrencyChanged(currency.Key, oldValue, newValue);
            }

            foreach (CurrencyView view in _views)
            {
                view.transform.SetParent(_currencyContainerTransform, false);
                view.OnAddButtonClicked += OnAddCurrencyButtonClick;
                view.OnSpendButtonClicked += OnSpendCurrencyButtonClick;
            }
        }

        private void OnDestroy()
        {
            foreach (KeyValuePair<CurrencyType, IReadOnlyVariable<int>> currency in _wallet.Account)
            {
                currency.Value.Changed -= (oldValue, newValue) =>
                    OnCurrencyChanged(currency.Key, oldValue, newValue);
            }

            foreach (CurrencyView currency in _views)
            {
                currency.OnAddButtonClicked -= OnAddCurrencyButtonClick;
                currency.OnSpendButtonClicked -= OnSpendCurrencyButtonClick;
            }
        }

        private void OnAddCurrencyButtonClick(CurrencyType currencyType, int amount) => _wallet.AddCurrency(currencyType, amount);
        private void OnSpendCurrencyButtonClick(CurrencyType currencyType, int amount) => _wallet.TrySpendCurrency(currencyType, amount);

        private void OnCurrencyChanged(CurrencyType currency, int oldValue, int newValue)
        {
            foreach (CurrencyView view in _views)
            {
                if(view.CurrencyType == currency)
                    view.SetCurrencyText(newValue.ToString());
            }
        }

    }
}
