using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.Common.Enums
{
    /// <summary>
    /// The Current State of the Room
    /// </summary>
    public enum RoomState
    {
        Available,
        InCleaning,
        InRenovation,
        Occupied,
        Reserved
    }

    /// <summary>
    /// Type of User Account interacting with the API
    /// </summary>
    public enum UserType
    {
        Agent,
        Government,
        Private
    }
}
