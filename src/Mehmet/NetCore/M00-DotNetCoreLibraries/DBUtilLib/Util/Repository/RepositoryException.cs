using System;
using Microsoft.EntityFrameworkCore;

namespace CSD.Util.Repository
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
        {
        }

        public RepositoryException(string msg) : base(msg)
        {
        }

        public RepositoryException(string msg, Exception innerException) : base(msg, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerText = InnerException != null ? "Repository Layer: " + InnerException.Message : "";

                if (InnerException is DbUpdateException)
                    innerText += " Process failed while saving to the database.";

                if (InnerException is DbUpdateConcurrencyException)
                    innerText += " A concurrency violation is encountered while saving to the database.";

                innerText += InnerException.InnerException != null
                    ? "Details:" + InnerException.InnerException.Message
                    : "";

                return $"Error Message from: {base.Message} {innerText}";
            }
        }
    }
}