using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Responses
{
    public abstract class ApiBadRequestResponse : ApiBaseResponse
    {
        public string Message { get; set; }
        public ApiBadRequestResponse(string message)
        : base(false)
        {
            Message = message;
        }
    }
}
