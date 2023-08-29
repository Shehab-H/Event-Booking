USE [Booking]
GO

/****** Object:  StoredProcedure [dbo].[GetTrendingEvents]    Script Date: 29/08/2023 07:24:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--select the events that has the most seats reserved in the last week and has 
--at least one upcoming event instance in the future ===> the trending events
CREATE proc [dbo].[GetTrendingEvents]
as
Begin
select
  top 10 e.Id , e.Name , e.Type , E.BackGroundUrl , e.ThumbnailUrl , e.DescriptionTitle , e.Description
FROM (
    --select the reservations that was created in the last week
    SELECT Reservations.Id,DateCreated,SeatedEventInstanceId
    FROM Reservations 
    INNER JOIN SeatedReservations  ON Reservations.Id = SeatedReservations.Id
    WHERE DateCreated < GETDATE() AND DateCreated >= DATEADD(day, -7, GETDATE())
) r
INNER JOIN EventsInstances si ON si.Id = r.SeatedEventInstanceId
Inner JOIN SeatSeatedReservation as ssr
on ssr.SeatedReservationId = r.Id
inner join Events e
on e.Id = EventId

--filter only the events that has eventinstances in the future 
where e.Id in (   select EventId 
                  from EventsInstances EI inner join Events E
                  on EI.EventId = E.Id
                  where EI.Span_Start>GETDATE())

Group by EventId , e.Id , e.BackGroundUrl , e.Description , e.DescriptionTitle
, e.Name , e.ThumbnailUrl , e.Type
order by  COUNT(ssr.BookedSeatsId)  desc
End
GO


