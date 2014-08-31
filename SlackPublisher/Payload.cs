namespace SlackPublisher
{
    public class Payload
    {
        private readonly string _text;

        public Payload(string text)
        {
            _text = text;
        }

        public string ToJson()
        {
            return "payload={\"text\": \"" + _text + "\"}";
        }
    }
}
