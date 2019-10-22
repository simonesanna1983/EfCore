using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Enum
{
    public enum StatusInspection
    {
        None = 0,
        Planned = 1,
        Pending = 2,
        Received = 3,
        Approved = 4,
        Rejected = 5,
        Published = 7,
        ToBeAnnounced = 8,
        Cancelled = 9
    }
}
