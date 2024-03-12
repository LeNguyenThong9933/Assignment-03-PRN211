using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetAll();
        public Member Get(int id);
        public void Delete(int id);
        public void Update(Member member);
        public void Insert(Member member);
    }
}
