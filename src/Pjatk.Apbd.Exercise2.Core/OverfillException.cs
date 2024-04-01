using System.Runtime.Serialization;

namespace Pjatk.Apbd.Exercise2.Core;

internal class OverfillException : Exception
{
    public OverfillException() { }

    public OverfillException(string? message)
        : base(message) { }

    public OverfillException(string? message, Exception? innerException)
        : base(message, innerException) { }
}
