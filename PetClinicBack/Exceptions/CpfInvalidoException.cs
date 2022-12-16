using System;

namespace PetDoor.Exceptions
{
    [Serializable]
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException() { }
        public CpfInvalidoException(string message) : base(message) { }

    }
}
