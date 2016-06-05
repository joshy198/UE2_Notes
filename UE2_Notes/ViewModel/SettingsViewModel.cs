using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE2_Notes.Repository;

namespace UE2_Notes.ViewModel
{
    public class SettingsViewModel:ViewModelBase
    {
        public int MaxNotes { set; get; }
        public SettingsViewModel()
        {
            MaxNotes = NoteData.Max_Notes;
        }
        public void SaveSettings()
        {
            NoteData.Max_Notes = MaxNotes;
        }
    }
}
