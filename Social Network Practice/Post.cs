using System;
using System.Text;

namespace Post
{
    class Post
    {
        private string[] LikedUserMails = default;
        private static int LikedUserMailsCount = default;

        private string[] ViewedUserMails = default;
        private int ViewedUserMailsCount = default;

        private static int GlobalId = default;
        public int Id { get; private set; }
        private string _content;
        public DateTime CreationTime { get; private set; }
        public int LikeCount { get; private set; } = default;
        public int ViewCount { get; private set; } = default;

        public Post(in string content)
        {
            Content = content;
            Id = ++GlobalId;
            CreationTime = DateTime.Now;
        }

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Content must contain something.");

                _content = value;
            }
        }

        public void IncrementLikeCount() => ++LikeCount;
        public void IncrementViewCount() => ++ViewCount;
        
        public void AddLikedUserMail(in string mail)
        {
            try
            {
                Verify.MailHelper.AddMail(ref LikedUserMails, mail);
                ++LikedUserMailsCount;
            }
            catch (InvalidOperationException caption)
            {
                Console.WriteLine(caption.Message);
                System.Threading.Thread.Sleep(1000);
            }

        }
        public void AddViewedUserMail(in string mail)
        {
            try
            {
                Verify.MailHelper.AddMail(ref ViewedUserMails, mail);
                ++ViewedUserMailsCount;
            }
            catch (InvalidOperationException caption)
            {
                Console.WriteLine(caption.Message);
                System.Threading.Thread.Sleep(1000);
            }
            
        }

        public bool IsUserWantToLikeAgain(in string email)
        {
            return Verify.MailHelper.IsMailExistInCollectionOfMails(LikedUserMails, email);
        }

        public bool IsUserWantToViewAgain(in string email)
        {
            return Verify.MailHelper.IsMailExistInCollectionOfMails(ViewedUserMails, email);
        }
        public StringBuilder GetHalfVersion()
        {
            const int limit = 30;
            StringBuilder halfVersion = new StringBuilder();
            halfVersion.Append
                ($"ID: {Id}, Content: {Content} | Like: {LikeCount} | View: {ViewCount} | Creation Time:  {CreationTime.ToString("F")} |"
                .Substring(0, limit))
                .Append("....");

            return halfVersion;
        }
        public void Show()
        {
            Console.WriteLine($"ID: {Id}, Content: {Content} | Like: {LikeCount} | View: {ViewCount} | Creation Time:  {CreationTime.ToString("F")} |");
        }

    }

}
