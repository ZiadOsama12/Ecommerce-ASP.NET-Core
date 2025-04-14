using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record TokenDto
    {

        [property: JsonProperty("access_token")]
        public string? AccessToken { get; init; }

        [property: JsonProperty("refresh_token")] 
        public string? RefreshToken { get; init; }
    }
    ;

}
