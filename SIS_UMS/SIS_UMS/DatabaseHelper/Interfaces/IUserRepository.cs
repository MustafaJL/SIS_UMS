using System;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    /// <summary>
    /// Defines an interface for interacting with user-related data in the database.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Checks if a username exists in the database.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>True if the username exists; otherwise, false.</returns>
        bool Check_Username(int username);

        /// <summary>
        /// Validates a user's password against the stored password hash.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="user_password">The user's password to validate.</param>
        /// <returns>True if the password is valid; otherwise, false.</returns>
        bool ValidatePassword(int username, string user_password);
    }
}
