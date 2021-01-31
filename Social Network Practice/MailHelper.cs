using System;

namespace Verify
{
    class MailHelper
    {
        public static bool IsValidEmail(in string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }                
        }

        public static void AddMail(ref string[] collectionOfMails, in string addedMail)
        {
            if (IsValidEmail(addedMail))
            {
                int length = (collectionOfMails == null) ? 1 : collectionOfMails.Length + 1;

                string[] temp = new string[length];
                if (collectionOfMails != null)
                {
                    collectionOfMails.CopyTo(temp, 0);
                }
                temp[length - 1] = addedMail;
                collectionOfMails = temp;
            }
            else
            throw new InvalidOperationException("Collection of mail is null or added mail is not correct format.");
        }

        public static bool IsMailExistInCollectionOfMails(string[] collectionOfMails, in string searchedMail)
        {
            if (IsValidEmail(searchedMail) && collectionOfMails != null)
            {
                foreach (var mail in collectionOfMails)
                {
                    if (mail == searchedMail)
                        return true;
                }
            }
            return false;
        }


    }
}
