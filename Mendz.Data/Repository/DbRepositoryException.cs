using System;
using System.Runtime.Serialization;

namespace Mendz.Data.Repository
{
    [Serializable]
    public class DbRepositoryException : Exception
    {
        public DbRepositoryException()
        {
        }

        public DbRepositoryException(string message) 
            : base(message)
        {
        }

        public DbRepositoryException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public DbRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
