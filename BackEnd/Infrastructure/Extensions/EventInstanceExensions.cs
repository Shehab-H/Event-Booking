using Core.DTO_s;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class EventInstanceExensions
    {
        public static IQueryable<EventRunTimesDto> MapToDto(this IQueryable<SeatedEventInstance> source)
        {
            return source.Select(i =>
            new EventRunTimesDto
            (i.Id, i.Span)
            );
        }

        public static IQueryable<SeatedVenueNamesDto> MapToSeatedVenueDto(this IQueryable<SeatedEventInstance> source)
        {
            return source.Select(i =>
            new SeatedVenueNamesDto
            (i.Venue.Id,i.Venue.Name)
            );
        }


    }
}
