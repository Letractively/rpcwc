using rpcwc.vo.Directory;
using System.Collections.Generic;
using System;
using System.Collections;

/// <summary>
/// Summary description for IGuestRegistrationDAO
/// </summary>
namespace rpcwc.dao
{
    public interface IGuestRegistrationDAO
    {
        void SaveGuestRegistration(GuestRegistration guestRegistration);
        IList<GuestRegistration> GetReport(string reportName);
        void TagGuest(GuestRegistration guestRegistration, String tagCode);
    }
}