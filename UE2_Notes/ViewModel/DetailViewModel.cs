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
        public DetailViewModel()
        {
            navigation = new LocalNavigation();
            if (NoteData.SelectedNote != null)
            {
                isEdit = true;
                Header = NoteData.SelectedNote.Name;
                MyNote = NoteData.SelectedNote.Notes;
            }
        }
        private bool isEdit;
        public LocalNavigation navigation;
        public string Header { get; set; }
        public string MyNote {get;set; }
        public void SaveToRepo()
        {
            if (!isEdit)
            {
                Note n = new Note();
                n.Name = Header;
                n.Notes = MyNote;
                n.Date = DateTime.Now;
                NoteData.Notes.Add(n);
                
            }
            else
            {
                NoteData.SelectedNote.Name = Header;
                NoteData.SelectedNote.Notes = MyNote;
                NoteData.SelectedNote.Date = DateTime.Now;
                NoteData.SelectedNote = null;
            }
            Header = string.Empty;
            MyNote = string.Empty;
            navigation.NavigateBack();
        }
    }
}
