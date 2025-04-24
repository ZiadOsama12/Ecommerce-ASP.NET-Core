using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public abstract record class ReviewForManipulation
    {
        public int ProductId { get; init; }
        public string? Comment { get; init; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")] // Test it
        public int Rating { get; init; }
    }
}
