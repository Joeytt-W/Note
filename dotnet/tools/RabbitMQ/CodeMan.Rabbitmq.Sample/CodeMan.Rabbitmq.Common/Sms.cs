namespace CodeMan.Rabbitmq.Common
{
    public class Sms
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Content { get; set; }

        public Sms()
        {

        }

        public Sms(string name, string mobile, string content)
        {
            Name = name;
            Mobile = mobile;
            Content = content;
        }
    }
}