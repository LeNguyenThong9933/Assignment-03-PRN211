using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Delete(int id) => MemberDAO.Instance.Delete(id);
        public Member Get(int id) => MemberDAO.Instance.Get(id);

        public IEnumerable<Member> GetAll() => MemberDAO.Instance.GetAll();

        public void Insert(Member member) => MemberDAO.Instance.Insert(member);

        public void Update(Member member) => MemberDAO.Instance.Update(member);
    }
}
