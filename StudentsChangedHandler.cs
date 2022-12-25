using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public delegate void StudentChangedHandler<TKey>(object source, StudentChangedEventArgs<TKey> args);
}
