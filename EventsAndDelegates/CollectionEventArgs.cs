using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class CollectionEventArgs : EventArgs
    {
        public readonly string msg;
        public CollectionEventArgs(string message)
        {
            msg = message;
        }
    }
}
