using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record GetReviewsDto
    {
        public ICollection<CreateReviewDto>? Reviews { get; init; }

        public double? AvgRating { get; set; }

       
    }
}
