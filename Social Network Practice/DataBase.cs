using System;

namespace DataBase
{
    class DataBase
    {

        public static string[] AllMails { get; private set; }
        private static int MailCount = default;
        public static string[] AllAdminUsernames { get; private set; }
        private static int AdminUsernameCount = default;

        private static bool IsMailExist(in string addedMail)
        {
            if (Verify.MailHelper.IsValidEmail(addedMail) && MailCount > 0)
            {
                foreach (var mail in AllMails)
                {
                    if (mail == addedMail)
                        return true;
                }
            }
            return false;
        }

        private static bool IsAdminUsernameExist(in string addedUsername)
        {
            if ((!String.IsNullOrWhiteSpace(addedUsername)) && AdminUsernameCount > 0)
            {
                foreach (var username in AllAdminUsernames)
                {
                    if (username == addedUsername)
                        return true;
                }
            }
            return false;
        }
        public static void AddMail(in string addedMail)
        {
            if(Verify.MailHelper.IsValidEmail(addedMail) && !IsMailExist(addedMail))
            {
                string[] temp = new string[++MailCount];

                if(AllMails != null)
                {
                    AllMails.CopyTo(temp, 0);
                }
                temp[MailCount - 1] = addedMail;
                AllMails = temp;
            }
            else
            throw new InvalidOperationException("This mail exists in the Database enter different mail.");
        }

        public static void AddAdminUsername(in string addedUsername)
        {
            if((!String.IsNullOrWhiteSpace(addedUsername)) && !IsAdminUsernameExist(addedUsername))
            {
                string[] temp = new string[++AdminUsernameCount];

                if(AllAdminUsernames != null)
                {
                    AllAdminUsernames.CopyTo(temp, 0);
                }
                temp[AdminUsernameCount - 1] = addedUsername;
                AllAdminUsernames = temp;
            }
            else
            throw new InvalidOperationException("This username exists in the Database enter different username.");
        }

    }
}
