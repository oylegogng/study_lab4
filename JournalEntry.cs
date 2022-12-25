using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public Action EventType { get; set; }
        public string ChangedPropertyName { get; set; }
        public string TextedElementKey { get; set; }

        public JournalEntry(string collectionName, Action eventType, string changedPropertyName, string textedElementKey)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedPropertyName = changedPropertyName;
            TextedElementKey = textedElementKey;
        }

        public override string ToString()
        {
            return $"Collection name: {CollectionName}\n" +
                   $"Event type: {EventType}\n" +
                   $"Property caused elements changing: {ChangedPropertyName}\n" +
                   $"Changed element key: {TextedElementKey}\n";
        }
    }
}
