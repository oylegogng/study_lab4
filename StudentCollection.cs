using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    delegate TKey KeySelector<TKey>(StudentVol2 st);
    class StudentCollection<TKey>
    {
        private Dictionary<TKey, StudentVol2> collection = new Dictionary<TKey, StudentVol2>();
        private KeySelector<TKey> ks;
        public StudentCollection(KeySelector<TKey> _ks)
        {
            ks = _ks;
        }

        public string CollectionName { get; set; }

        public bool Remove(StudentVol2 st)
        {
            foreach (KeyValuePair<TKey, StudentVol2> kvp in collection)
            {
                if(kvp.Value == st)
                {
                    collection.Remove(kvp.Key);
                    StudentPropertyChanged(Action.Remove, "None", kvp.Key);
                    st.PropertyChanged += HandleEvent;
                    break;
                }
            }

            return false;
        }

        private void HandleEvent(object subject, EventArgs e)
        {
            var it = (PropertyChangedEventArgs)e;
            var mg = (StudentVol2)subject;
            var key = ks(mg);
            StudentPropertyChanged(Action.Property, it.PropertyName, key);
        }

        public void AddStudent(StudentVol2 st)
        {
            var key = ks(st);
            collection.Add(key, st);
            StudentPropertyChanged(Action.Add, "None", key);
            st.PropertyChanged += HandleEvent;
        }

        public StudentChangedHandler<TKey> StudentChanged;

        private void StudentPropertyChanged(Action update, string name, TKey key)
        {
            StudentChanged?.Invoke(this, new StudentChangedEventArgs<TKey>(CollectionName, update, name, key));
        }
    }
}
