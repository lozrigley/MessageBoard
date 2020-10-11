namespace Messaging.Application.Command.DAL
{
    public class SaveMessageRequest
    {
        public string Text { get; set; }

        public string Sender { get; set; }
    }
}