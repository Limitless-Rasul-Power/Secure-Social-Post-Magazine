using System;

namespace Notification
{
    class Notification
    {
        static private int GlobalId = default;
        public int Id { get; private set; }
        private string _text;
        private string _fromUser;
        public DateTime CreationTime { get; private set; }


        public Notification(in string text, in string fromUser)
        {
            Text = text;
            FromUser = fromUser;
            Id = ++GlobalId;
            CreationTime = DateTime.Now;
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Text must contain something.");

                _text = value;
            }
        }

        public string FromUser
        {
            get
            {
                return _fromUser;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new InvalidOperationException("Data must contain something.");

                _fromUser = value;
            }
        }

        public void Show()
        {
            Console.WriteLine($"Caption: {Text}");
            Console.WriteLine($"From User: {FromUser}");
        }

    }
}
