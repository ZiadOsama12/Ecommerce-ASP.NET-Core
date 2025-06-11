using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Domain
{
    public class ErrorDetails
    {
        public int StatusCode { set; get; }
        public string? Message { set; get; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
