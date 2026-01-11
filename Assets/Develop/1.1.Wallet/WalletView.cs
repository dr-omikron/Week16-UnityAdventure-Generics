using System.Collections.Generic;
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

            foreach (ReactiveVariable<CurrencyType, int> currency in _wallet.Account)
                currency.Changed += OnCurrencyChanged;

            foreach (CurrencyView view in _views)
            {
                view.transform.SetParent(_currencyContainerTransform, false);
                view.OnAddButtonClicked += OnAddCurrencyButtonClick;
                view.OnSpendButtonClicked += OnSpendCurrencyButtonClick;
            }
        }

        private void OnDestroy()
        {
            foreach (ReactiveVariable<CurrencyType, int> currency in _wallet.Account)
                currency.Changed -= OnCurrencyChanged;

            foreach (CurrencyView currency in _views)
            {
                currency.OnAddButtonClicked -= OnAddCurrencyButtonClick;
                currency.OnSpendButtonClicked -= OnSpendCurrencyButtonClick;
            }
        }

        private void OnAddCurrencyButtonClick(CurrencyType currencyType, int amount) => _wallet.AddCurrency(currencyType, amount);
        private void OnSpendCurrencyButtonClick(CurrencyType currencyType, int amount) => _wallet.TrySpendCurrency(currencyType, amount);

        private void OnCurrencyChanged(CurrencyType currencyType, int amount)
        {
            foreach (CurrencyView currency in _views)
            {
                if(currency.CurrencyType == currencyType)
                    currency.SetCurrencyText(amount.ToString());
            }
        }

    }
}
