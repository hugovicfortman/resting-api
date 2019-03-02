using System;
using System.Collections.Generic;
using System.Text;
using RESTing.Common.Enums;

namespace RESTing.BusinessEntities.Base
{
    public abstract class Room : BusinessEntity
    {
        public string RoomNumber { get; set; }
        public DateTime RoomAvailableTime { get; set; }
        public RoomState RoomState { get; set; }
    }
}
