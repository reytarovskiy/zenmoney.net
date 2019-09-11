namespace Zenmoney.Exceptions
{
    [System.Serializable]
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException(string message = "Authorization failed, check your token") : base(message) { }
        public UnauthorizedException(string message, System.Exception inner) : base(message, inner) { }
        protected UnauthorizedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}