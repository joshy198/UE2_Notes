using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE2_Notes.Model;
using UE2_Notes.Navigation;
using UE2_Notes.Repository;

namespace UE2_Notes.ViewModel
{
    public class DetailViewModel:ViewModelBase
    {
        public LocalNavigation navigation;
        public string Header { get; set; }
        public string MyNote {get;set; }
        public void SaveToRepo()
        {
            navigation = new LocalNavigation();
            Note n = new Note();
            n.Name = Header;
            n.Notes = MyNote;
            NoteData.Notes.Add(n);
            Header = string.Empty;
            MyNote = string.Empty;
        }
    }
}
