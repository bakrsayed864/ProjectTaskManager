namespace Application.Core.Responses
{
    public class ValidationErrorResponse 
    {
        public IEnumerable<string> Errors { get; set; }
        public Error Error { get; set; }

        public ValidationErrorResponse()
        {
            Errors = [];
            Error = Error.Validation();
        }
    }
}
