namespace Payments.Domain.Messages
{
    public class ValidationMessages
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ValidationMessages(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
