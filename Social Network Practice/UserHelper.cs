using System;

namespace UserHelper
{
    using User;

    class UserHelper
    {
        public static int FindUser(in User[] users, in string email, in string password)
        {
            if(users != null && Verify.MailHelper.IsValidEmail(email) && password?.Length > 7 && (!String.IsNullOrWhiteSpace(password)))
            {
                for (int i = 0; i < users.Length; i++)
                {
                    if (email == users[i].Email && password == users[i].HashedPassword)
                        return i;
                }
            }            
            throw new InvalidOperationException("Wrong email or password.");
        }
    }
}
