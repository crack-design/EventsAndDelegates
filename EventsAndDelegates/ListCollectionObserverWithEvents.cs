using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class ListCollectionObserverWithEvents<T> : List<T>
    {
        public delegate void CollectionChangedEventHandler(object sender, CollectionEventArgs e);
        public event CollectionChangedEventHandler Added;
        public event CollectionChangedEventHandler Removed;
        public static void OnAdd(object sender, CollectionEventArgs e)
        {
            Console.WriteLine(e.msg);
        }

        public static void OnRemove(object sender, CollectionEventArgs e)
        {
            Console.WriteLine(e.msg);
        }

        public new void Add(T item)
        {
            var castedItem = item as DummyModel;
            base.Add(item);
            Added?.Invoke(this, new CollectionEventArgs($"Item with name {castedItem.Name} has been added into collection"));
        }

        public new void Remove(T item)
        {
            var castedItem = item as DummyModel;
            base.Add(item);
            Removed?.Invoke(this, new CollectionEventArgs($"Item with name {castedItem.Name} has been removed from collection"));
        }
    }
}
