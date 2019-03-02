using System;
using System.Collections.Generic;
using System.Text;
using RESTing.BusinessEntities.Base;

namespace RESTing.BusinessEntities
{
    /// <summary>
    /// A Reservation could be for a Lounge, an Auditorium, or multiple, or both
    /// Each Reservation is unique, and must be created by a registered user
    /// </summary>
    public class Reservation : BusinessEntity
    {
        public Guid ReservationUID { get; set; }
        public DateTime CreatedTime { get; set; }
        public int RegisteredUserID { get; set; }
        public virtual RegisteredUser CreatedBy { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public List<int> RoomNumbers { get; set; }
        public virtual List<Auditorium> Auditoria { get; set; }
        public virtual List<Lounge> Lounges { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}
