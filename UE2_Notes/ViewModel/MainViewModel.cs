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
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Note> notes;
        public LocalNavigation navigation;
        public Note SelectedNote { get; set; }
        public bool ItemSelected { get { return SelectedNote != null; } }
        public ObservableCollection<Note> Notes
        {
            get
            {
                notes.Clear();
                foreach (var nt in NoteData.Notes.Where(x => x.Name.ToUpper().StartsWith(SearchString.ToUpper())).OrderByDescending(x=>x.Date).Take(NoteData.Max_Notes).ToList())
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
               // RaisePropertyChanged(nameof(Notes));
            }
        }
        public MainViewModel()
        {
            if(navigation==null)
            navigation = new LocalNavigation();
            if(notes==null)
            notes = new ObservableCollection<Note>();
            if(searchString==null)
            SearchString = "";
        }
        public void NewNote()
        {
            NoteData.SelectedNote = null;
            navigation.NavigateToDetails();
        }
        public void Search()
        {
            RaisePropertyChanged(nameof(NoteData.Notes));
        }
        public void EditNote()
        {
            NoteData.SelectedNote = SelectedNote;
            navigation.NavigateToDetails();
            SelectedNote = null;

        }
        public void RemoveNote()
        {
            NoteData.RemoveNote(SelectedNote);
            SelectedNote = null;
            RaisePropertyChanged(nameof(Notes));
        }
    }
}
