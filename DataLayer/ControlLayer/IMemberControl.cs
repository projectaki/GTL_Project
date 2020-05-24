using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.ControlLayer
{
    public interface IMemberControl
    {
        int CreateMember(int Ssn, string FirstName, string LastName, string EmailAddress, string PhoneNumber, string Campus, string MemberType);
        List<Member> LoadMemberInfo(int id);
        List<Member> LoadMembersWhere(string search);
    }
}