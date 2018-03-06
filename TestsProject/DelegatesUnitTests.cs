using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventsAndDelegates;
using Moq;
using AutoMoq;

namespace TestsProject
{
    [TestClass]
    public class DelegatesTests
    {
        private Mock<IConsoleWrapper> consoleWrapperMock;
        private AutoMoqer Mocker { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.Mocker = new AutoMoqer();
            this.consoleWrapperMock = new Mock<IConsoleWrapper>();
        }

        [TestMethod]
        public void AddMethodShouldTriggerAddMessage()
        {
            var collectionMock = new ListCollectionObserver<DummyModel>(consoleWrapperMock.Object);
            collectionMock.Add(new DummyModel(1, "SMith", Grade.Bronze));
            var text = "Item with id: 1, Name: SMith and Grade: Bronze was added into collection";
            consoleWrapperMock.Verify(a => a.WriteLine(text), Times.Once);
        }

        [TestMethod]
        public void RemoveMethodShouldTriggerRemoveMessage()
        {
            var collectionMock = new ListCollectionObserver<DummyModel>(consoleWrapperMock.Object);
            var item = new DummyModel(1, "SMith", Grade.Bronze);
            collectionMock.Add(item);
            collectionMock.Remove(item);
            var text = "Item with id: 1 was removed from collection";
            consoleWrapperMock.Verify(a => a.WriteLine(text), Times.Once);
        }

        [TestMethod]
        public void ChangeMethodShouldTriggerRemoveMessage()
        {
            var collectionMock = new ListCollectionObserver<DummyModel>(consoleWrapperMock.Object);
            var item = new DummyModel(1, "John", Grade.Gold);
            collectionMock.Add(item);
            collectionMock.Change(new DummyModel(1, "Mike", Grade.Silver));
            var text = "Name was changed from John to Mike \n" +
                        $"Grade was changed from Gold to Silver";
            consoleWrapperMock.Verify(a => a.WriteLine(text), Times.Once);
        }
    }
}
