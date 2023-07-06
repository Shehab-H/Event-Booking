using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IbookingService
    {
        public void Book(int eventInstanceId, ICollection<int> seatIds);
        public void  Book(int eventInstanceID, string ticketType , uint quantity);

        //public CaptureOrderResponse ConfirmReservation(Guid reservationSerial);
    }
}
