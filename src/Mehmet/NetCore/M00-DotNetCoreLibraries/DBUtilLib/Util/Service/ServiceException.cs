using System;
using Microsoft.EntityFrameworkCore;

namespace CSD.Util.Service
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string msg) : base(msg)
        {
        }

        public ServiceException(string msg, Exception innerException) : base(msg, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerText = InnerException != null ? "Service Layer: " + InnerException.Message : "";

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