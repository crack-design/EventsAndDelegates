using System;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {


            var firstItem = new DummyModel(1, "Larry", Grade.Gold);
            var secondItem = new DummyModel(2, "Scott", Grade.Silver);
            var thirdItem = new DummyModel(3, "Robert", Grade.Bronze);
           

            var collection = new ListCollectionObserver<DummyModel>();
            collection.Add(firstItem);
            collection.Add(secondItem);
            collection.Add(thirdItem);
            collection.Change(new DummyModel(1, "Alpha", Grade.Bronze));
            collection.Change(new DummyModel(4, "Murphy", Grade.Silver));
            collection.Remove(firstItem);
            collection.Remove(secondItem);
            collection.Remove(thirdItem);

            //Stuff with events
            Console.WriteLine("_________________________________\nEvent stuff here \n_________________________________");

            var eventsCollection = new ListCollectionObserverWithEvents<DummyModel>();
            eventsCollection.Added += ListCollectionObserverWithEvents<DummyModel>.ElementWasAddedIntoCollection;
            eventsCollection.Removed += ListCollectionObserverWithEvents<DummyModel>.ElementWasRemovedFromCollection;

            var item = new DummyModel(1, "Jonas", Grade.Bronze);
            eventsCollection.Add(item);
            eventsCollection.Add(new DummyModel(2, "Misteria", Grade.Silver));
            eventsCollection.Remove(item);
            Console.ReadLine();
        }
    }
}
