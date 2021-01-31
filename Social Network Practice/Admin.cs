using System;
using System.Text.RegularExpressions;

namespace Admin
{
    using Post;
    using Notification;
    using DataBase;

    class Admin
    {
        static private int GlobalId = default;
        public static Post[] Posts { get; private set; }
        static private int PostCount = default;
        public static Notification[] Notifications { get; private set; }
        static private int NotificationCount = default;
        public int Id { get; private set; }
        private string _username;
        private string _email;
        private string _hashedPassword;


        public Admin(in string username, in string email, in string password)
        {
            Username = username;
            Email = email;
            HashedPassword = password;
            Id = ++GlobalId;
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if ((!Regex.IsMatch(value, @"^[\p{L}]+$")) || value == null)
                    throw new InvalidOperationException("User name must contain letters.");

                DataBase.AddAdminUsername(value);
                _username = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                if (!Verify.MailHelper.IsValidEmail(value))
                    throw new InvalidOperationException("Mail is not true format");

                DataBase.AddMail(value);
                _email = value;
            }
        }
        public string HashedPassword
        {
            get
            {
                return _hashedPassword;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value?.Length < 8)
                    throw new InvalidOperationException("Password must be more than 8 characters.");

                _hashedPassword = value.GetHashCode().ToString();
            }
        }

        public static void AddPost(Post addedPost)
        {
            if (addedPost != null)
            {
                Post[] temp = new Post[++PostCount];

                if (Posts != null)
                {
                    Posts.CopyTo(temp, 0);
                }
                temp[PostCount - 1] = addedPost;
                Posts = temp;
            }
        }

        public static int FindPostWithId(in int id)
        {
            if (id >= 0 && PostCount > 0)
            {
                for (int i = 0; i < PostCount; i++)
                {
                    if (Posts[i].Id == id)
                        return i;
                }
            }
            throw new InvalidOperationException($"ID [{id}] didn't exist or there is no Post.");
        }

        private static void Remove(in int index)
        {
            if (index >= 0 && PostCount > 0 && index < PostCount)
            {
                Post[] temp = new Post[--PostCount];

                if (index > 0)
                    Array.Copy(Posts, 0, temp, 0, index);

                if (index < PostCount + 1)
                    Array.Copy(Posts, index + 1, temp, index, PostCount - index);

                Posts = temp;
            }
            else
                throw new InvalidOperationException("Index must be more or equal to 0 and PostCoutn must be more than 0 and index must be smaller than PostCount");
        }
        public static Post DeletePostWithId(in int id)
        {
            int index = FindPostWithId(id);
            Post removedPost = Posts[index];
            Remove(index);
            return removedPost;
        }

        public static void AddNotification(Notification addedNote)
        {
            if (addedNote != null)
            {
                Notification[] temp = new Notification[++NotificationCount];

                if (Notifications != null)
                {
                    Notifications.CopyTo(temp, 0);
                }
                temp[NotificationCount - 1] = addedNote;
                Notifications = temp;
            }
        }

        public static void ShowHalfVersionOfPosts()
        {
            if (Posts == null || Posts?.Length == 0)
            {
                Console.WriteLine("There is no post.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < Posts.Length; i++)
            {
                Console.WriteLine(Posts[i].GetHalfVersion());
            }
            Console.ResetColor();
        }

        public static void ShowFullVersinOfPosts()
        {
            if (Posts == null || Posts?.Length == 0)
            {
                Console.WriteLine("There is no post.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < Posts.Length; i++)
            {
                Posts[i].Show();
                Console.WriteLine();
                Console.WriteLine("================================================");
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public static void ShowAllNotifications()
        {
            if (Notifications == null || Notifications?.Length == 0)
            {
                Console.WriteLine("There is no notification.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Notifications.Length; i++)
            {
                Notifications[i].Show();
                Console.WriteLine();
                Console.WriteLine("================================================");
                Console.WriteLine();
            }
            Console.ResetColor();

        }

    }
}
