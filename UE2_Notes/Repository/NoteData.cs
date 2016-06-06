using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE2_Notes.Model;

namespace UE2_Notes.Repository
{
    public class NoteData
    {
        public static Note SelectedNote { get; set; }
        private static ObservableCollection<Note> notes;
        public static ObservableCollection<Note> Notes
        {
            get
            {
                if (notes == null)
                    notes = new ObservableCollection<Note>();
                return notes;
            }
        }
        public static int Max_Notes {get;set;}
        public static bool RemoveNote(Note n)
        {
            foreach (Note nt in Notes)
            {
                if (nt.Date == n.Date && nt.Notes == n.Notes && n.Name == nt.Name)
                {
                    notes.Remove(n);
                    return true;
                }
            }
            return false;
        }
    }
}
