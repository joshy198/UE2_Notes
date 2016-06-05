using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE2_Notes.View;
using UE2_Notes.ViewModel;

namespace UE2_Notes.Navigation
{
    public class LocalNavigation
    {
        private static readonly NavigationService navigationService;
        static LocalNavigation()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            navigationService = new NavigationService();
            navigationService.Configure("Details", typeof(DetailView));
            navigationService.Configure("Settings", typeof(SettingsView));
        }
        public void NavigateToSettings()
        {
            navigationService.NavigateTo("Settings");
        }
        public void NavigateBack()
        {
            navigationService.GoBack();
        }
        public void NavigateToDetails()
        {
            navigationService.NavigateTo("Details");
        }
    }
}
