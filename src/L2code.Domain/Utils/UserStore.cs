using L2code.Domain.Models;

namespace L2code.Utils
{
    public static class UserStore
    {
        public static List<User> Users = new List<User>
        {
            new User { Username = "l2code", Password = "l2code" }
        };
    }
}