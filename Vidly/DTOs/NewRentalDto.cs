using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vidly.DTOs
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}
