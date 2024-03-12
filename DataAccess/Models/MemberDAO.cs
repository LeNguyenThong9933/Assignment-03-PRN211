namespace DataAccess.Models
{
    internal class MemberDAO
    {
        private static MemberDAO instance = null;
        public static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                return instance;
            }
        }
        public IEnumerable<Member> GetAll()
        {
            IEnumerable<Member> members = new List<Member>();
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                members = context.Members;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }
        public Member Get(int id)
        {
            Member member;
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                member= context.Members.Where(x=> x.MemberId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public void Delete(int id)
        {
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                Member member = Get(id);
                if (member == null) throw new Exception("member id not exist!!!");
                context.Members.Remove(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Member member)
        {
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                context.Members.Update(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(Member member)
        {
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                context.Members.Add(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
