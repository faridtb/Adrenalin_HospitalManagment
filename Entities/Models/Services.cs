using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Services:IProfession
    {
        public string Name { get; set; }
        public int profID { get; set; }

    }
}
