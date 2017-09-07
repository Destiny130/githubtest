using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class MembersRepository : IMemberRepository
    {
        public void AddMember(Member member)
        { }

        public Member FetchByLoginName(string loginName)
        {
            return null;
        }

        public void SubmitChanges()
        { }
    }
}