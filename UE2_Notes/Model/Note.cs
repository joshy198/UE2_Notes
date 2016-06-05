using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE2_Notes.Model
{
    public class Note: ObservableObject
    {
        private static int MAX_ID;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }

        public Note()
        {
            Id = MAX_ID;
            MAX_ID++;
        }

        public string Disp_Notes {
            get {
                if (Notes.Length > 50)
                    return Notes.Replace('\n', ' ').Remove(60)+"...";
                else
                    return Notes.Replace('\n', ' ');
            }
        }
    }
}
