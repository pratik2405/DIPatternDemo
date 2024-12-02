using DIPatternDemo.Models;
using DIPatternDemo.Repositories;
using Microsoft.EntityFrameworkCore.Internal;

namespace DIPatternDemo.Services
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly IRegistrationRepo Repo;
        public RegistrationServices(IRegistrationRepo Repo)
        {
            this.Repo = Repo;
        }

        public int AddUser(Registration user)
        {
            return Repo.AddUser(user);

        }

        public Registration GetUser(Registration user)
        {
            return Repo.GetUser(user);
        }
    }
}
