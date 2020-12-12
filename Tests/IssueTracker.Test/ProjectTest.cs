using IssueTracker.Application.Features.Projects.Commands;
using IssueTracker.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IssueTracker.Test
{
    public class ProjectTest
    {
        [Fact]
        public void CreateProjectCommand_Test()
        {
            //Arange
            var mediator = new Mock<IMediator>();


            mediator
                .Setup(m => m.Send(It.IsAny<CreateProjectCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Project()) //<-- return Task to allow await to continue
                .Verifiable("CreateProjectCommand was not sent.");

            //Act
            mediator.Object.Send(new CreateProjectCommand());
            //...other code removed for brevity

            //verify
            mediator.Verify(x => x.Send(It.IsAny<CreateProjectCommand>(), It.IsAny<CancellationToken>()), Times.Once());

        }
        [Fact]
        public void DeleteProjectCommand_Test()
        {
            //Arange
            var mediator = new Mock<IMediator>();

            mediator
                .Setup(m => m.Send(It.IsAny<DeleteProjectCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Unit.Task) //<-- return Task to allow await to continue
                .Verifiable("DeleteProjectCommand was not sent.");

            //Act
            mediator.Object.Send(new DeleteProjectCommand());
            //...other code removed for brevity

            //verify
            mediator.Verify(x => x.Send(It.IsAny<DeleteProjectCommand>(), It.IsAny<CancellationToken>()), Times.Once());

        }
    }
}
