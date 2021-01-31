namespace Configure
{
    using User;
    using Admin;
    using Post;

    class Configuration
    {
        public static User[] GetUsers()
        {
            User u1 = new User("Theodor", "Roosevelt", 22, "theoroos@mail.ru", "12345678");
            User u2 = new User("Rocky", "Balboa", 23, "rocky@mail.ru", "12345678");
            User u3 = new User("Blonde", "Anuar", 20, "mike@mail.ru", "12345678");
            User u4 = new User("Monica", "Belluci", 25, "monilove@mail.ru", "12345678");

            User[] users = new User[] { u1, u2, u3, u4 };
            return users;
        }


        public static Post[] GetPosts()
        {
            Post p1 = new Post("I love you baby");
            Post p2 = new Post("I hate you");
            Post p3 = new Post("I am the best. all i need is within me NOW.!.!.!");

            Post[] posts = new Post[] { p1, p2, p3 };
            return posts;
        }


        public static string[] GetUserOptions()
        {
            string[] options = new string[] { "View Post with ID", "Like Post with ID", "Exit" };
            return options;
        }

        public static string[] GetAdminOptions()
        {
            string[] options = new string[] { "Show All Post", "Add Post", "Remove Post", "Show All Notifications", "Exit" };
            return options;
        }

        public static Admin[] GetAdmins()
        {
            Admin a1 = new Admin("Angelo", "angel@devil.com", "angelo123");
            Admin a2 = new Admin("Jessy", "jes.v@mine.com", "i don't know");
            Admin a3 = new Admin("Elvis", "elli@gmail.com", "987654321");
            Admin a4 = new Admin("Leo", "leo@lio.link", "leooel11");

            Admin[] admins = new Admin[] { a1, a2, a3, a4 };
            return admins;
        }

        public static void PrintNameOfSocialNetwork()
        {
            System.Console.ForegroundColor = System.ConsoleColor.Blue;
            string nameOfSocialNetwork = "Post Magazine";
            System.Console.Write(new string(' ', (System.Console.WindowWidth - nameOfSocialNetwork.Length) / 2));
            System.Console.WriteLine(nameOfSocialNetwork);
            System.Console.Write(new string('=', System.Console.WindowWidth));
            System.Console.WriteLine();
            System.Console.ResetColor();
        }

    }
}
