using EasyTwoJuetengApp.Helpers.JdsClientTool;
using Plugin.Toast;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RealTairOnlineExam.Interface;
using RealTairOnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealTairOnlineExam.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    [QueryProperty(nameof(CoinName), nameof(CoinName))]
    public class CoinDetailPageViewModel : ViewModelBase
    {
        #region Fields
        private string _id = "";
        private string _coinName;
        private bool _isDataStillLoading;
        private bool _isNotFound;
        private Coin _coin;
        private readonly IGet<JdsSingleResponse<Coin>> _getCoinService;
        #endregion

        #region Properties
        public string Id
        {
            get => _id;
            set
            {
                SetProperty(ref _id, Uri.UnescapeDataString(value??string.Empty));
                Task.Run(async () => { await GetCoinExecute(_id);});
            }
        }
        public string CoinName
        {
            get => _coinName;
            set
            { 
                SetProperty(ref _coinName, Uri.UnescapeDataString(value ?? string.Empty));
                Title = value;
            }
        }
        public bool IsDataStillLoading 
        {
            get => _isDataStillLoading;
            set { SetProperty(ref _isDataStillLoading, value); } 
        }
        public bool IsNotFound 
        {
            get => _isNotFound;
            set { SetProperty(ref _isNotFound, value); }
        }
        public Coin Coin 
        {
            get => _coin;
            set { SetProperty(ref _coin, value); } 
        }
        #endregion
        #region Constructor
        public CoinDetailPageViewModel(INavigationService navigationService,
            IGet<JdsSingleResponse<Coin>> getCoinService)
            :base(navigationService)
        {
            this._getCoinService = getCoinService;
        }
        #endregion

        #region Methods
        public async Task GetCoinExecute(string _id)
        {
            IsDataStillLoading = true;
            var getCoinRequest = await _getCoinService.Get(_id);
            if (getCoinRequest.IsFailed)
                IsNotFound = true;
            else
                Coin = getCoinRequest.Data;
            IsDataStillLoading = false;
           
        }
        #endregion
    }
}
