using Xamarin.Forms;

namespace RealTairOnlineExam.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("CoinDetailPage", typeof(CoinDetailPage));
        }
    }
}
