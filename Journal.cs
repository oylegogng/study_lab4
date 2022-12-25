using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Journal
    {
        private List<JournalEntry> changes = new List<JournalEntry>();

        public void NewEntryForCollection(object subject, EventArgs e)
        {
            var it = e as StudentChangedEventArgs<string>;
            changes.Add(new JournalEntry(it.CollectionName, it.What, it.PropertyName, it.ChangedElemKey));
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var change in changes)
            {
                str.Append(change + "\n");
            }

            return str.ToString();
        }
    }
}
