namespace GeekShopping.MessageBus
{
    public abstract class BaseMessage
    {
        public int Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}