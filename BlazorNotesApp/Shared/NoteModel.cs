using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNotesApp.Shared
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Heading { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsChecked { get; set; }

    }
}
