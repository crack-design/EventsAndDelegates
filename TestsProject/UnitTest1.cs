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
            var consoleMock = new Mock<IConsoleWrapper>();
            var collectionMock = new ListCollectionObserver<DummyModel>(consoleMock.Object);
            collectionMock.Add(new DummyModel(1, "SMith", Grade.Bronze));
            var text = "Item with id: 1, Name: SMith and Grade: Bronze was added into collection";
            consoleMock.Verify(a => a.WriteLine(text), Times.Once);
        }
    }
}
