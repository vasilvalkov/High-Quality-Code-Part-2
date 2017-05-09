using Moq;
using NUnit.Framework;
using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Factories;
using ProjectManager.Data;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.UnitTests.Commands.CreateTaskCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowUserValidationException_WhenInvalidParametersCountArePassed()
        {
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var invalidParameters = new List<string>() { "0 0 BuildTheStar" };
            var createTaskCommand = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            Assert.Throws<UserValidationException>(() => createTaskCommand.Execute(invalidParameters));
        }

        [Test]
        public void ThrowUserValidationException_WhenEmptyParametersArePassed()
        {
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var invalidParameters = new List<string>() { "" };
            var createTaskCommand = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            Assert.Throws<UserValidationException>(() => createTaskCommand.Execute(invalidParameters));
        }

        [Test]
        public void CallsProjectsPropertyIndexer_WhenInvokedWithValidParameters()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var projectStub = new Mock<IProject>();
            var ownerStub = new Mock<IUser>();
            var taskStub = new Mock<ITask>();
            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };
            var createTaskCommand = new CreateTaskCommand(databaseMock.Object, factoryStub.Object);

            databaseMock.Setup(db => db.Projects).Returns(new List<IProject> { projectStub.Object});
            databaseMock.SetupGet(db => db.Projects[It.IsAny<int>()]);

            projectStub.Setup(p => p.Users).Returns(new List<IUser> { ownerStub.Object });
            projectStub.Setup(p => p.Tasks).Returns(new List<ITask> { taskStub.Object });

            // Act
            createTaskCommand.Execute(validParameters);

            // Assert
            databaseMock.Verify(db => db.Projects[It.IsAny<int>()], Times.Once);
        }

        [Test]
        public void CreateATaskWithExactlyThoseParameters_WhenInvokedWithValidParameters()
        {
            // Arrange
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var ownerStub = new Mock<IUser>();
            var taskMock = new Mock<ITask>();
            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };
            var createTaskCommand = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            databaseStub.Setup(db => db.Projects).Returns(new List<IProject> { projectMock.Object });

            projectMock.Setup(p => p.Users).Returns(new List<IUser> { ownerStub.Object });
            projectMock.Setup(p => p.Tasks).Returns(new List<ITask>());

            // Act
            createTaskCommand.Execute(validParameters);

            // Assert
            Assert.AreEqual("Pending", projectMock.Object.Tasks[0].State);
            Assert.AreEqual("BuildTheStar", projectMock.Object.Tasks[0].Name);
            Assert.AreEqual(ownerStub.Object, projectMock.Object.Tasks[0].Owner);
        }

        [Test]
        public void AddTheCreatedTaskToTheProject_WhenInvokedWithValidParameters()
        {
            // Arrange
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var ownerStub = new Mock<IUser>();
            var taskStub = new Mock<ITask>();
            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };
            var createTaskCommand = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            databaseStub.Setup(db => db.Projects).Returns(new List<IProject> { projectMock.Object });
            
            projectMock.Setup(p => p.Users).Returns(new List<IUser> { ownerStub.Object });
            projectMock.Setup(p => p.Tasks).Returns(new List<ITask>());

            // Act
            createTaskCommand.Execute(validParameters);

            // Assert
            Assert.AreEqual(1, projectMock.Object.Tasks.Count);
        }

        [Test]
        public void ReturnMessegeContainingSuccessfullyCreated_WhenInvokedWithValidParameters()
        {
            // Arrange
            var databaseStub = new Mock<IDatabase>();
            var factoryStub = new Mock<IModelsFactory>();
            var projectMock = new Mock<IProject>();
            var ownerStub = new Mock<IUser>();
            var taskStub = new Mock<ITask>();
            var validParameters = new List<string>() { "0", "0", "BuildTheStar", "Pending" };
            var createTaskCommand = new CreateTaskCommand(databaseStub.Object, factoryStub.Object);

            databaseStub.Setup(db => db.Projects).Returns(new List<IProject> { projectMock.Object });

            projectMock.Setup(p => p.Users).Returns(new List<IUser> { ownerStub.Object });
            projectMock.Setup(p => p.Tasks).Returns(new List<ITask>());

            // Act
            string result = createTaskCommand.Execute(validParameters);

            // Assert
            StringAssert.Contains("Successfully created", result);
        }
    }
}
