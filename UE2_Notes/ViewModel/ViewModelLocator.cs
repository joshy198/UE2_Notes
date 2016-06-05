using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE2_Notes.View;

namespace UE2_Notes.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel MVM => new MainViewModel();
        public DetailViewModel DVM => new DetailViewModel();
        public SettingsViewModel SVM => new SettingsViewModel();
    }
}
