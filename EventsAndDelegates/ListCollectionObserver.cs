using System;
using System.Collections.Generic;

namespace EventsAndDelegates
{
    public class ListCollectionObserver<T> : List<T>, IListCollectionObserver<T>
    {
        public delegate void CollectionChangeHandler(string msgForCaller);

        private CollectionChangeHandler listOfHandlers;
        private readonly IConsoleWrapper _console;
        public ListCollectionObserver(IConsoleWrapper console)
        {
            _console = console;
            listOfHandlers += PowerHandlerMethod;
        }

        public new void Add(T item)
        {
            base.Add(item);
            var castedItem = item as DummyModel;
            listOfHandlers?.Invoke($"Item with id: {castedItem.Id}, Name: {castedItem.Name} and Grade: {castedItem.Grade} was added into collection");
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            var castedItem = item as DummyModel;
            listOfHandlers?.Invoke($"Item with id: {castedItem.Id} was removed from collection");
            if (base.Count == 0)
            {
                listOfHandlers?.Invoke("Collection has been cleared");
            }
        }

        public void Change(T item)
        {
            dynamic result;
            var castedInput = item as DummyModel;
            if (castedInput != null)
            {
                result = base.Find(
                    delegate (T dm)
                    {
                        return (dm as DummyModel).Id == (castedInput).Id;
                    }
                    );
                var castedResult = result as DummyModel;
                if (result != null)
                {
                    listOfHandlers?.Invoke($"Name was changed from {castedResult.Name} to {(castedInput).Name} \n" +
                        $"Grade was changed from {castedResult.Grade} to {(castedInput).Grade}");
                    castedResult.Grade = castedInput.Grade;
                    castedResult.Name = castedInput.Name;
                }
                else
                {
                    listOfHandlers?.Invoke($"Item with id {castedInput.Id} was not found");
                }
            }
            else
            {
                listOfHandlers?.Invoke("Item is not of type __DummyModel__");
            }
        }
        private void PowerHandlerMethod(string message)
        {
            _console.WriteLine(message);
        }
        
    }
}
