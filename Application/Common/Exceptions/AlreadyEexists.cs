namespace Application.Common.Exceptions
{
    public class AlreadyExists : BaseException
    {
        public AlreadyExists(string message) : base(message) { }

    }
}
