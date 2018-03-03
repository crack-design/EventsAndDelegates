using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadLine();
        }
    }
}
