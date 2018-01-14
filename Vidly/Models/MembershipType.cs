using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Vidly.Models
{
    public class MembershipType
    {
        //1:  pay as you go
        //2: monthly
        //3:quarterly
        //4: annual
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        
        [StringLength(255)]
        [DefaultValue("None")]
        public string Name { get; set; }
    }
}