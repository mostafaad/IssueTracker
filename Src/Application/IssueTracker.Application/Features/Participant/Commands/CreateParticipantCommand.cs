using AutoMapper;
using IssueTracker.Application.Common.Interfaces;
using IssueTracker.Application.Features.Issues.ViewModels;
using IssueTracker.Application.Features.Participant.ViewModels;
using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Repository.RepositoryWrapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Issues.Commands
{
    public class CreateParticipantCommand : IRequest<Participants>
    {
        public string UserId  { get; set; }
        public string ProjectKey { get; set; }
    }

    public class CreateParticipantCommandHandler : IRequestHandler<CreateParticipantCommand, Participants>
    {
        private readonly IRepositoryWrapper _wrapper;

        public CreateParticipantCommandHandler(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<Participants> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            var ProjectData = _wrapper.Project.FindByCondition(c => c.Key == request.ProjectKey).FirstOrDefault();

            var ParticipantObj = new Participants() { ProjectId = ProjectData.Id, ParticipantUser = request.UserId };
            _wrapper.Participant.Create(ParticipantObj);

            await _wrapper.SaveChangesAsync(cancellationToken);

            return ParticipantObj;
        }
    }
}
