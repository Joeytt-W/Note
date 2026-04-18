namespace Mediator
{
    //public abstract class ChatRoom
    // {
    //     public abstract class Register(TeamMembers treamMenber);

    //     public abstract void Send(string from, string managed);
    // }


    public interface IChatRoom {
        void Register(TeamMember teamMember);

        void Send(string from, string message);

        void Send(string from, string to,string message);

        void SendTo<T>(string from, string message) where T : TeamMember;
    }

    public abstract class TeamMember
    {
        private IChatRoom? _chatRoom;

        public string Name { get; set; }

        public TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public void Send(string message)
        {
            _chatRoom?.Send(Name,message);
        }

        public void Send(string to, string message)
        {
            _chatRoom?.Send(Name, to, message);
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            _chatRoom?.SendTo<T>(Name, message);
        }

        public virtual void Receive(string from ,string message)
        {
            Console.WriteLine($"Message {from} to {Name}:{message}");
        }
    }


    public class Lawyer : TeamMember
    {
        public Lawyer(string name):base(name)
        {

        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(Lawyer)}  {Name}  Received");
            base.Receive(from, message);
        }
    }

    public class AccountManager : TeamMember
    {
        public AccountManager(string name) : base(name)
        {

        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine($"{nameof(AccountManager)}  {Name}  Received");
            base.Receive(from, message);
        }
    }


    public class TeamChatRoom : IChatRoom
    {
        private readonly Dictionary<string, TeamMember> teamMembers = new();

        public void Register(TeamMember teamMember)
        {
            teamMember.SetChatRoom(this);
            if (!teamMembers.ContainsKey(teamMember.Name))
            {
                teamMembers.Add(teamMember.Name, teamMember);
            }
        }

        public void Send(string from, string message)
        {
            foreach (var teamMember in teamMembers.Values)
            {
                teamMember.Receive(from, message);
            }
        }

        public void Send(string from, string to, string message)
        {
            var teamMember = teamMembers[to];
            teamMember?.Receive(from, message);
        }

        public void SendTo<T>(string from, string message) where T : TeamMember
        {
            foreach (var teamMember in teamMembers.Values.OfType<T>())
            {
                teamMember.Receive(from, message);
            }
        }
    }
}
