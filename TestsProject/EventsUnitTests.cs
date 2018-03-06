using EventsAndDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    [TestClass]
    public class EventsUnitTests
    {
        [TestMethod]
        public void AddMethodShouldTriggerAddEvent()
        {
            var collectionMock = new Mock<ListCollectionObserverWithEvents<DummyModel>>();
            collectionMock.Object.Added += ListCollectionObserverWithEvents<DummyModel>.OnAdd;
            collectionMock.Object.Removed += ListCollectionObserverWithEvents<DummyModel>.OnRemove;
            collectionMock.Raise(a => a.Added += null, new CollectionEventArgs("Stuff was added"));
            collectionMock.Raise(a => a.Removed += null, new CollectionEventArgs("Stuff was deleted"));
            collectionMock.VerifyAll();
        }
    }
}
