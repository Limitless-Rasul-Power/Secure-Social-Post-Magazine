using System;

namespace AdminHelper
{
    using Admin;

    class AdminHelper
    {
        public static int FindAdminWithUsernameOrEmail(Admin[] admins, in string usernameOrEmail, in string password)
        {
            if((!String.IsNullOrWhiteSpace(usernameOrEmail)) && admins != null &&
                (!String.IsNullOrWhiteSpace(password)) && password?.Length > 7)
            {
                for (int i = 0; i < admins.Length; i++)
                {
                    if ((admins[i].Username == usernameOrEmail || admins[i].Email == usernameOrEmail) && admins[i].HashedPassword == password)
                        return i;
                }
            }            
            throw new InvalidOperationException("Wrong username or email or password.");
        }
    }

}
