using System;

namespace Social_Network_Practice
{
    using Admin;
    using User;
    using Post;
    using Configure;
    using Verify;
    using Menu;
    using Notification;
    class Program
    {
        static void Main(string[] args)
        {
            User[] users;
            Post[] posts;
            Admin[] admins;
            string[] userOptions;
            string[] adminOptions;

            try
            {
                users = Configuration.GetUsers();
                posts = Configuration.GetPosts();
                admins = Configuration.GetAdmins();

                for (int i = 0; i < posts.Length; i++)
                    Admin.AddPost(posts[i]);

                userOptions = Configuration.GetUserOptions();
                adminOptions = Configuration.GetAdminOptions();

            }
            catch (InvalidOperationException caption)
            {
                Console.WriteLine(caption.Message);
                System.Threading.Thread.Sleep(1000);
                return;
            }

            const int entryMenuLength = 3;

            while (true)
            {
                Console.Clear();
                try
                {
                    Configuration.PrintNameOfSocialNetwork();
                    Console.WriteLine("1.User\n2.Admin\n3.Exit");
                    Console.Write("Enter: ");
                    string option = Console.ReadLine().Trim();
                    string usernameOrEmail;
                    string password;

                    while (Verify.IsOptionIncorrect(option, entryMenuLength))
                    {
                        Console.Write("Enter one of this choices(1, 2, 3): ");
                        option = Console.ReadLine().Trim();
                    }

                    Console.Clear();                    
                    Configuration.PrintNameOfSocialNetwork();
                    
                    if (Convert.ToChar(option) == (char)MenuOptions.User)
                    {
                        Console.Write("Enter your mail: ");
                        usernameOrEmail = Console.ReadLine().Trim();
                        Console.Write("Enter your password: ");
                        password = Console.ReadLine().GetHashCode().ToString();

                        Console.Clear();
                        Configuration.PrintNameOfSocialNetwork();

                        int index = UserHelper.UserHelper.FindUser(users, usernameOrEmail, password);

                        Console.WriteLine($"Welcome {users[index].Name} {users[index].Surname} to Post Magazine!");

                        Admin.AddNotification(new Notification($"Visits Post Magazine in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));

                        while (true)
                        {
                            OptionHelper.Option.PrintOptions(userOptions);
                            Console.WriteLine();
                            Console.Write("Enter: ");
                            option = Console.ReadLine().Trim();

                            while (Verify.IsOptionIncorrect(option, userOptions.Length))
                            {
                                Console.Write("Enter one of this choices(1, 2, 3): ");
                                option = Console.ReadLine().Trim();
                            }

                            Console.Clear();
                            Configuration.PrintNameOfSocialNetwork();

                            if (Convert.ToChar(option) != (char)UserOptions.Exit)
                                Admin.ShowHalfVersionOfPosts();

                            string selectWithId;
                            if (Convert.ToChar(option) == (char)UserOptions.LikePostWithId)
                            {
                                Admin.AddNotification(new Notification($"Selected {UserOptions.LikePostWithId} option in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));
                                Console.WriteLine();
                                Console.Write("Enter ID: ");
                                selectWithId = Console.ReadLine();

                                Console.Clear();
                                if (Verify.IsInputNotNumber(selectWithId))
                                {
                                    Console.WriteLine("Input is not number try again.");
                                    System.Threading.Thread.Sleep(1000);
                                }
                                else
                                {
                                    try
                                    {
                                        int postIndex = Admin.FindPostWithId(int.Parse(selectWithId));

                                        if (!Admin.Posts[postIndex].IsUserWantToLikeAgain(users[index].Email))
                                        {
                                            Admin.Posts[postIndex].IncrementLikeCount();
                                            Admin.Posts[postIndex].AddLikedUserMail(users[index].Email);
                                            Admin.AddNotification(new Notification($"Liked [{selectWithId}] Id Post in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));
                                        }

                                        Console.WriteLine($"{users[index].Name} {users[index].Surname}, you liked this post thanks so much.");

                                        System.Threading.Thread.Sleep(1000);
                                    }
                                    catch (InvalidOperationException caption)
                                    {
                                        Admin.AddNotification(new Notification($"Selected id didn't exist in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));

                                        Console.Clear();
                                        Console.WriteLine(caption.Message);
                                        System.Threading.Thread.Sleep(1000);
                                    }
                                }
                            }
                            else if (Convert.ToChar(option) == (char)UserOptions.ViewPostWithId)
                            {
                                Admin.AddNotification(new Notification($"Selected {UserOptions.ViewPostWithId} option in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));

                                Console.WriteLine();
                                Console.Write("Enter ID: ");
                                selectWithId = Console.ReadLine();

                                Console.Clear();
                                if (Verify.IsInputNotNumber(selectWithId))
                                {
                                    Console.WriteLine("Input is not number try again.");
                                    System.Threading.Thread.Sleep(1000);
                                }
                                else
                                {
                                    try
                                    {
                                        int postIndex = Admin.FindPostWithId(int.Parse(selectWithId));
                                       
                                        Admin.Posts[postIndex].Show();
                                        Admin.AddNotification(new Notification($"Viewed [{selectWithId}] Id Post in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));

                                        if (!Admin.Posts[postIndex].IsUserWantToViewAgain(users[index].Email))
                                        {
                                            Admin.Posts[postIndex].IncrementViewCount();
                                            Admin.Posts[postIndex].AddViewedUserMail(users[index].Email);
                                        }

                                        Console.Write("Press \"Enter\" key to continue...");
                                        Console.ReadLine();
                                        
                                    }
                                    catch (InvalidOperationException caption)
                                    {
                                        Admin.AddNotification(new Notification($"Selected id didn't exist in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));

                                        Console.Clear();
                                        Console.WriteLine(caption.Message);
                                        System.Threading.Thread.Sleep(1000);
                                    }


                                }
                            }
                            else
                            {
                                Console.WriteLine("See you soon. Goodbye");
                                Admin.AddNotification(new Notification($"Exits Post Magazine in {DateTime.Now.ToString("F")}", $"{users[index].Name} {users[index].Surname}"));
                                break;
                            }
                            Console.Clear();
                            Configuration.PrintNameOfSocialNetwork();
                        }

                    }
                    else if (Convert.ToChar(option) == (char)MenuOptions.Admin)
                    {
                        Console.Write("Enter your mail or username: ");
                        usernameOrEmail = Console.ReadLine().Trim();
                        Console.Write("Enter your password: ");
                        password = Console.ReadLine().GetHashCode().ToString();

                        Console.Clear();
                        Configuration.PrintNameOfSocialNetwork();

                        int index = AdminHelper.AdminHelper.FindAdminWithUsernameOrEmail(admins, usernameOrEmail, password);

                        Console.WriteLine($"Welcome Admin {admins[index].Username} to Post Magazine!");

                        while (true)
                        {
                            OptionHelper.Option.PrintOptions(adminOptions);
                            Console.WriteLine();
                            Console.Write("Enter: ");
                            option = Console.ReadLine().Trim();

                            while (Verify.IsOptionIncorrect(option, adminOptions.Length))
                            {
                                Console.Write("Enter one of this choices(1, 2, 3, 4, 5): ");
                                option = Console.ReadLine().Trim();
                            }

                            Console.Clear();
                            Configuration.PrintNameOfSocialNetwork();

                            if (Convert.ToChar(option) == (char)AdminOptions.Exit)
                            {
                                Console.WriteLine("Thanks for taking care of Post Magazine see you soon.");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }

                            switch (Convert.ToChar(option))
                            {
                                case (char)AdminOptions.ShowAllPosts:
                                    {
                                        Admin.ShowFullVersinOfPosts();
                                        Console.Write("Press \"Enter\" key to continue...");
                                        Console.ReadLine();
                                    }
                                    break;
                                case (char)AdminOptions.AddPost:
                                    {
                                        try
                                        {
                                            Console.Write("Enter Post content: ");
                                            Post addedPost = new Post(Console.ReadLine().Trim());
                                            Admin.AddPost(addedPost);
                                            Console.Clear();
                                            Console.WriteLine("Post Added Successfully.");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                        catch (InvalidOperationException caption)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(caption.Message);
                                            System.Threading.Thread.Sleep(1000);
                                            Console.Clear();
                                        }                                        
                                    }
                                    break;
                                case (char)AdminOptions.RemovePost:
                                    {
                                        if (Admin.Posts.Length == 0)
                                        {
                                            Console.WriteLine("There is no post.");
                                            System.Threading.Thread.Sleep(1000);
                                        }
                                        else
                                        {
                                            Admin.ShowFullVersinOfPosts();
                                            Console.WriteLine();
                                            Console.Write("Enter which Id do you want to delete: ");
                                            string selectedId = Console.ReadLine();

                                            if (Verify.IsInputNotNumber(selectedId))
                                            {
                                                Console.WriteLine("Input is not number try again.");
                                                System.Threading.Thread.Sleep(1000);
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    Post removedPost = Admin.DeletePostWithId(int.Parse(selectedId));
                                                    Console.Clear();                                                    
                                                    Console.WriteLine("Post succesfully deleted.");
                                                }
                                                catch (InvalidOperationException caption)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine(caption.Message);
                                                }

                                                System.Threading.Thread.Sleep(1000);
                                            }
                                        }
                                    }
                                    break;
                                case (char)AdminOptions.ShowAllNotifications:
                                    {
                                        Admin.ShowAllNotifications();
                                        Console.Write("Press \"Enter\" key to continue...");
                                        Console.ReadLine();
                                    }
                                    break;                                
                            }

                            Console.Clear();
                            Configuration.PrintNameOfSocialNetwork();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Configuration.PrintNameOfSocialNetwork();
                        Console.WriteLine("Thank you for visiting. See you soon!");
                        break;
                    }
                    Console.Clear();
                }
                catch (InvalidOperationException caption)
                {
                    Console.Clear();
                    Console.WriteLine(caption.Message);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
}
