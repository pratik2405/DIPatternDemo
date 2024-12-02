using DIPatternDemo.Models;

namespace DIPatternDemo.Services
{
    public interface IRegistrationServices
    {
        public int AddUser(Registration user);

        public Registration GetUser(Registration user);
    }
}
