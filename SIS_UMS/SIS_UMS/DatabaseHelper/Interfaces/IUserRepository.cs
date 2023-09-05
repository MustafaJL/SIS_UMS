using System;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IUserRepository
    {
        bool Check_Username(int username);

        bool ValidatePassword( int username , string user_password);
    }

}
