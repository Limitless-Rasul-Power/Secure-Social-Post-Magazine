using System;

namespace Menu
{
    enum MenuOptions
    {
        User = '1', Admin = '2', Exit = '3'
    }

    enum UserOptions
    {
        ViewPostWithId = '1', LikePostWithId = '2', Exit = '3'
    }

    enum AdminOptions
    {
        ShowAllPosts = '1', AddPost = '2', RemovePost = '3', ShowAllNotifications = '4', Exit = '5'
    }
}
