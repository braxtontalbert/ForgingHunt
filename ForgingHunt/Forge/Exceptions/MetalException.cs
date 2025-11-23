namespace ForgingHunt.Forge.Exceptions
{
    public class MetalException : System.Exception
    {
        public MetalException(string message) : base(message) { }

        // Constructor that takes a message and an inner exception
        public MetalException(string message, System.Exception inner) : base(message, inner) { }

        // You can add custom properties or methods here if needed
        public int ErrorCode { get; set; }
    }
}