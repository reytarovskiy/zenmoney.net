namespace Zenmoney.Exceptions
{
    [System.Serializable]
    public class UndefinedException : System.Exception 
    {
        public UndefinedException(string message = "Undefined error") : base(message) { }
    }
}