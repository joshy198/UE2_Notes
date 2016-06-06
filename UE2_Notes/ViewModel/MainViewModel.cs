using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UE2_Notes.Model;
using UE2_Notes.Navigation;
using UE2_Notes.Repository;
using UE2_Notes.View;

namespace UE2_Notes.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private ObservableCollection<Note> notes;
        public LocalNavigation navigation;
        private Note selectedNote;
        public Note SelectedNote
        {
            set
            {
                if (selectedNote == value)
                    selectedNote = null;
                else
                    selectedNote = value;
            }
            get { return selectedNote; }
        }
        public bool ItemSelected { get { return SelectedNote != null; } }
        public ObservableCollection<Note> Notes
        {
            get
            {
                notes.Clear();
                foreach (var nt in NoteData.Notes.Where(x => x.Name.ToUpper().StartsWith(SearchString.ToUpper())).ToList())
                    notes.Add(nt);
                return notes;
            }
        }
        private string searchString="";
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
            }
        }
        public MainViewModel()
        {
            navigation = new LocalNavigation();
            NoteData.Max_Notes = 100;
            notes = new ObservableCollection<Note>();
            SearchString = "";
            /*this.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SearchFor") RaisePropertyChanged(nameof(notes));
            };*/
            /*var n = new Note();
            n.Name = "Einkaufsliste";
            n.Notes = "Eier, Milch, Gemüse";
            n.Date = DateTime.Now;
            NoteData.Notes.Add(n);
            n = new Note();
            n.Name = "Wichtiges";
            n.Notes = "Klaus abholen, Tanken fahren, Klaus abholen, Tanken fahren, Klaus abholen, Tanken fahren, Klaus abholen, Tanken fahren";
            n.Date = DateTime.Now;
            NoteData.Notes.Add(n);*/
        }
        public void Search()
        {
            RaisePropertyChanged(nameof(NoteData.Notes));
        }
        public void EditNote()
        {
            NoteData.SelectedNote = SelectedNote;
        }
        public void RemoveNote()
        {
            NoteData.Notes.Remove(SelectedNote);
        }
    }
}
