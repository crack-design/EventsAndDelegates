namespace EventsAndDelegates
{
    public interface IListCollectionObserver<T>
    {
        void Add(T item);
        void Change(T item);
        void Remove(T item);
    }
}