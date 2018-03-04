using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventsAndDelegates;
using Moq;

namespace TestsProject
{
    [TestClass]
    public class DelegatesTests
    {
        [TestMethod]
        public void AddMethodShouldTriggerAddMessage()
        {

            var collectionMock = new Mock<ListCollectionObserver<DummyModel>>();
            collectionMock.Object.Add(new DummyModel(1, "SMith", Grade.Bronze));
        }
    }
}
