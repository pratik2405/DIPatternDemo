using DIPatternDemo.Data;
using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly ApplicationDbContext db;
        public RegistrationRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddUser(Registration user)
        {
            int result = 0;
            db.Register?.Add(user);
            result=db.SaveChanges();
            return result;       
        }

        public Registration GetUser(Registration user)
        {
            return db.Register?.Where(x=>x.Email==user.Email & x.Password==user.Password).FirstOrDefault();
        }
    }
}
