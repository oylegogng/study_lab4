using System.Text;

namespace lab1
{
    public class StudentChangedEventArgs<TKey>: EventArgs
    {
        public string CollectionName { get; set; }
        public Action What { get; set; }
        public string PropertyName { get; set; }

        public TKey ChangedElemKey { get; set; }

        public StudentChangedEventArgs(string collectionName, Action what, string propertyName,
            TKey changedElemKey)
        {
            CollectionName = collectionName;
            What = what;
            PropertyName = propertyName;
            ChangedElemKey = changedElemKey;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Changes in collection: {CollectionName}\n");
            sb.Append($"Changes type: {What}");
            sb.Append($"Changes in property {PropertyName}");
            sb.Append($"Changed elem with key {ChangedElemKey}");
            return sb.ToString();
        }
    }
}