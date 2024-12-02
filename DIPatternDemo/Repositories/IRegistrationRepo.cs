using DIPatternDemo.Models;

namespace DIPatternDemo.Repositories
{
    public interface IRegistrationRepo
    {
        public int AddUser(Registration user);
        public Registration GetUser(Registration user);


    }
}
