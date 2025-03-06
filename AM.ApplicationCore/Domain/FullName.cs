using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [MaxLength(25, ErrorMessage = "max length: 25")]
        [MinLength(3, ErrorMessage = "min length: 3")]
        public string? FirstName { get; set; }

        [MaxLength(25, ErrorMessage = "max length: 25")]
        [MinLength(3, ErrorMessage = "min length: 3")]
        public string? LastName { get; set; }

        public override string ToString()
        {
            return ("FirstName : " + this.FirstName + " LastName " + this.LastName + " \n");
        }
    }
}
