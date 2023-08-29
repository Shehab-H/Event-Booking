using Core.Interfaces;
using MediatR;

namespace Application.Commands
{
    internal class AddEventHandler : IRequestHandler<AddEventCommand>
    {
        private IEventCrudRepository _eventCrudRepository;

        public AddEventHandler(IEventCrudRepository eventCrudRepository)
        {
            _eventCrudRepository = eventCrudRepository;
        }
        public async Task Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            await _eventCrudRepository.AddEventAsync(request.@event);
            await _eventCrudRepository.SaveChangesAsync();
        }
    }
}
