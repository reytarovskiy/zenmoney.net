namespace Zenmoney.Exceptions
{
    [System.Serializable]
    public class UndefinedException : System.Exception
    {
        public UndefinedException() { }
        public UndefinedException(string message = "Undefined error") : base(message) { }
        public UndefinedException(string message, System.Exception inner) : base(message, inner) { }
        protected UndefinedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}