namespace CommunicationSystem.Repository
{
    public interface IMessage { }
    public class MessageRepository:IMessage
    {
        private readonly AppDBContext context;

        public MessageRepository(AppDBContext context)
        {
            this.context = context;
        }
    }
}
