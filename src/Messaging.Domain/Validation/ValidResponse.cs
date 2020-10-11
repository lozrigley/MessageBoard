namespace Messaging.Domain.Validation
{
    public class ValidResponse
    {
        public ValidatorResponseCode Code { get; set; }

        public bool IsValid => this.Code == ValidatorResponseCode.Passed;
    }
}