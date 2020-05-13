namespace Zenmoney.Exceptions
{
    public class UndefinedException : System.Exception 
    {
        public UndefinedException(string message = "Undefined error") : base(message) { }

        public UndefinedException()
        {
        }

        public UndefinedException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}