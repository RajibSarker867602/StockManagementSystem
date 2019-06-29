using StockManagementSystem.Repository;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Manager
{
    public class UserManager
    {
        UserRepository _userRepository= new UserRepository();
        public int IsExistUser(User user)
        {
            int count = _userRepository.IsExistUser(user);
            if (count > 0)
            {
                return count;
            }
            return count;
        }
        public int GetUserId(string userName,string password)
        {
            int userId = _userRepository.GetUserId(userName, password);
            if (userId > 0)
            {
                return userId;
            }
            return userId;
        }
    }
}
