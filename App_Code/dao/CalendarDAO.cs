using System;
using System.Collections;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using rpcwc.vo;


/// <summary>
/// Summary description for CalendarDAO
/// </summary>
namespace rpcwc.dao
{
    public interface CalendarDAO
    {
        IList findEventsByDateRange(DateTime startDate, DateTime endDate);

        Event findEventDetails(int itemId);

        IList findSpecialEventsFuture();
    }
}