using EasyTwoJuetengApp.Helpers.JdsClientTool;
using Prism;
using Prism.Ioc;
using RealTairOnlineExam.Helpers;
using RealTairOnlineExam.ViewModels;
using RealTairOnlineExam.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace RealTairOnlineExam
{
    public partial class App
    {
        private string _apiBaseUrl = "https://api.coingecko.com/api/v3/";
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            JdsClient.BaseAddress = _apiBaseUrl;
            await NavigationService.NavigateAsync("MainPage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CoinsPage, CoinsPageViewModel>();
            containerRegistry.AutoRegisterByInterFaceName("IGet");
            containerRegistry.AutoRegisterByInterFaceName("IGetAll");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CoinDetailPage, CoinDetailPageViewModel>();
        }
    }
}
