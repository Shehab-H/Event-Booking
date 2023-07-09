using Core.DTO_s;
using Core.Interfaces;
using MediatR;

namespace Application.Queries
{
    internal class GetVenuesHandler : IRequestHandler<GetVenuesQuery, ICollection<SeatedVenueNamesDto>>
    {
        private readonly IEventRepository _repository;
        public GetVenuesHandler(IEventRepository repository)
        {
            _repository = repository;        
        }
        public Task<ICollection<SeatedVenueNamesDto>> Handle(GetVenuesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetVenueNames(request.eventId));   
        }
    }
}
