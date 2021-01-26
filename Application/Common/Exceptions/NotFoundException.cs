namespace Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) is not found") { }



    }
}
