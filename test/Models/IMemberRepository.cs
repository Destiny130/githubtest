using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public interface IMemberRepository
    {
        void AddMember(Member member);
        Member FetchByLoginName(string loginName);
        void SubmitChanges();
    }
}
