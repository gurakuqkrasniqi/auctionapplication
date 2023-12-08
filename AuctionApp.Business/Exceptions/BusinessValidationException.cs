using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Business.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException()
        {
            Messages = new List<string>();
        }

        public BusinessValidationException(string? message)
            : base(message)
        {
            Messages = new List<string>
            {
                message,
            };
        }

        public BusinessValidationException(IEnumerable<string> messages)
            : base(string.Join(",", messages))
        {
            Messages = new List<string>(messages);
        }

        public BusinessValidationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
            Messages = new List<string>
            {
                message,
            };
        }

        protected BusinessValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public IReadOnlyList<string> Messages { get; }
    }
}
