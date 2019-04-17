using Prism;
using Prism.Ioc;
using Hustle.ViewModels;
using Hustle.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hustle.Views.Navigation;
using Hustle.Views.Overview;
using Hustle.ViewModels.Navigation;
using Hustle.ViewModels.Overview;
using Hustle.Views.Accounts;
using Hustle.ViewModels.Accounts;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Hustle
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TabbedNavPage, TabbedNavPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterDetailNavPage, MasterDetailNavPageViewModel>();
            containerRegistry.RegisterForNavigation<OverviewPage, OverviewPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPage, CreateAccountPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewAccountPage, ViewAccountPageViewModel>();
        }
    }
}
