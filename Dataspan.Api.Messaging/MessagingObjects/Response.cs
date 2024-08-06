namespace Dataspan.Api.Messaging.MessagingObjects
{
    public class Response
    {
        public int ErrorCode { get; set; } = 0;
        public int Status { get; set; } = 0;
        public string AdditionalMessage { get; set; } = "Successful";
    }
}
