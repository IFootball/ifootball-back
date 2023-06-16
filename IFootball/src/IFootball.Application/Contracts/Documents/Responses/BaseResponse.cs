namespace IFootball.Application.Contracts.Documents.Responses
{
    public class BaseResponse
    {
        public ErrorResponse? Error { get; private set; }

        public BaseResponse() { }
        public BaseResponse(ErrorResponse error) 
        {
            Error = error;
        }
        public bool IsErrorStatusCode() => Error is not null;

    }

}
