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
    public class CoinsPageViewModel : ViewModelBase
    {
        #region Fields
        private List<Coin> _coins;
        private readonly IGetAll<JdsMultiResponse<Coin>> _getAllCoinsService;
        private List<Coin> _dummyCoinsData => new List<Coin>()
        {
            new Coin()
            {
                Name = "dummy"
            },
            new Coin()
            {
                Name = "dummy"
            },
            new Coin()
            {
                Name = "dummy"
            },
            new Coin()
            {
                Name = "dummy"
            },
            new Coin()
            {
                Name = "dummy"
            },
            new Coin()
            {
                Name = "dummy"
            },
        };
        private List<Coin> _coinsForFilter;
        private string _searchKey;
        private bool _isDataStillLoading;
        private bool _isEmpty;
        private bool _isRefreshing;
        private Coin _selectedCoin;
        private bool _isSearchBoxEnable;
        #endregion

        #region Methods
        private async Task getAllCoinsExecute()
        {
            IsDataStillLoading = true;
            Coins = _dummyCoinsData;
            var coinRequest = await _getAllCoinsService.GetAll();
            if (coinRequest.IsFailed)
            {
                Coins = null;
                IsEmpty = true;
            }
            else
            {
                _coinsForFilter = coinRequest.Data;
                Coins = coinRequest.Data;
                IsSearchBoxEnable = true;
            }
            IsDataStillLoading = false;
        }
        private void filterCoins(string keyword)
        {
            if (_coins != null)
            {
                var coinsSearchResult = new List<Coin>();
                foreach (var coin in _coinsForFilter)
                {
                    var searchMatch = coin.Name.ToLower().Contains(keyword);
                    if (searchMatch)
                        coinsSearchResult.Add(coin);
                }
                Coins = coinsSearchResult;
                IsEmpty = Coins.Count == 0;
            }
        }
        #endregion

        #region Commands
        public DelegateCommand ReloadCommand => new DelegateCommand(() =>
        {
            IsRefreshing = true;
            if (IsEmpty)
                IsEmpty = false;
            Task.Run(async () => await getAllCoinsExecute());
            IsRefreshing = false;
        });
        public DelegateCommand CoinSelectionChangeCommand => new DelegateCommand(async () =>
        {
            try
            {
                await Shell.Current.GoToAsync($"/CoinDetailPage?Id={_selectedCoin.Id}&CoinName={_selectedCoin.Name}");
                _selectedCoin = null;
            }
            catch (Exception ex)
            {
            }
        });
        #endregion

        #region Properties
        public string EmptyText => string.IsNullOrEmpty(SearchKey) ? "No Coin Loaded or Something Went Wrong" : $"No Result found '{SearchKey}'";
        public bool IsSearchBoxEnable 
        {
            get => _isSearchBoxEnable;
            set { SetProperty(ref _isSearchBoxEnable, value); }
        }
        public Coin SelectedCoin
        {
            get => _selectedCoin;
            set { SetProperty(ref _selectedCoin, value); }
        }
        public List<Coin> Coins 
        {
            get => _coins;
            set
            { 
                SetProperty(ref _coins, value);
            }
        }
        public string SearchKey 
        {
            get => _searchKey;
            set 
            { 
                SetProperty(ref _searchKey,value);
                filterCoins(value);
                RaisePropertyChanged(nameof(EmptyText));
            }
        }
        public bool IsDataStillLoading 
        {
            get => _isDataStillLoading; 
            set { SetProperty(ref _isDataStillLoading, value);}
        }
        public bool IsEmpty 
        {
            get => _isEmpty;
            set { SetProperty(ref _isEmpty, value); } 
        }
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { SetProperty(ref _isRefreshing, value);}
        }
        #endregion

        #region Constructor
        public CoinsPageViewModel(INavigationService navigationService,IGetAll<JdsMultiResponse<Coin>> getAllCoinsService):base(navigationService)
        {
            this._getAllCoinsService = getAllCoinsService;
            Title = "Coins";
            Task.Run(async () => await getAllCoinsExecute());
        }
        #endregion
    }
}
