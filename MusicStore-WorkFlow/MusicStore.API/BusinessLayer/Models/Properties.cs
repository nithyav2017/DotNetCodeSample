using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jexoy.API.BusinessLayer.Models
{
    public class Properties
    {
        public string Title { get; set; }
        public bool UnContained { get; set; }
        public Input[] Inputs { get; set; }
        public Output[] Outputs { get; set; }
    }
}
