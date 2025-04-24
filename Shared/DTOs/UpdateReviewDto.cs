using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record UpdateReviewDto : ReviewForManipulation
    {
        public int Id { get; set; }
    }
}
