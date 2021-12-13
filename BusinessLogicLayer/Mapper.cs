using Model.WebModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    static class Mapper
    {
        public static UserPublic User(User input)
        {
            UserPublic respont = new UserPublic
            {
                UserID = input.UserID,
                UserName = input.UserName,
                ProfileText = input.ProfileText
            };

            return respont;
        }
    }
}
