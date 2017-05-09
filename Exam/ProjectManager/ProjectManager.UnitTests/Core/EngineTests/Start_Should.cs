using Moq;
using NUnit.Framework;
using ProjectManager.Common;
using ProjectManager.Common.Providers.Contracts;

namespace ProjectManager.UnitTests.Core.EngineTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void CallReaderToReadCommand_WhenInvoked()
        {
            // Arrange
            var loggerStub = new Mock<IFileLogger>();
            var commandProcessorStub = new Mock<ICommandProcessor>();
            var writerStub = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();

            readerMock.Setup(r => r.ReadLine()).Returns("exit");

            var engine = new Engine(loggerStub.Object, commandProcessorStub.Object, readerMock.Object, writerStub.Object);

            // Act
            engine.Start();

            // Assert
            readerMock.Verify(r => r.ReadLine(), Times.Once);
        }

        [Test]
        public void CallWriterToWriteSomething_WhenPassedCommandIsExit()
        {
            // Arrange
            var loggerStub = new Mock<IFileLogger>();
            var commandProcessorStub = new Mock<ICommandProcessor>();
            var writerMock = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();

            readerStub.Setup(r => r.ReadLine()).Returns("exit");

            var engine = new Engine(loggerStub.Object, commandProcessorStub.Object, readerStub.Object, writerMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(w => w.WriteLine(It.IsAny<string>()));
        }

        [Test]
        public void CallLoggerWithExceptionMessage_WhenGenericExceptionOccurs()
        {
            // Arrange
            var loggerMock = new Mock<IFileLogger>();
            var commandProcessorStub = new Mock<ICommandProcessor>();
            var writerStub = new Mock<IWriter>();
            var readerStub = new Mock<IReader>();

            readerStub.Setup(r => r.ReadLine()).Returns("exit");

            var engine = new Engine(loggerMock.Object, commandProcessorStub.Object, readerStub.Object, writerStub.Object);

            // Act
            engine.Start();

            // Assert
            loggerMock.Verify(l => l.Error(It.IsAny<string>()));
        }
    }
}
