using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jexoy.API.BusinessLayer.Models
{
    public class Link
    {
        public string FromOperator { get; set; }
        public string FromConnector { get; set; }
        public string ToOperator { get; set; }
        public string ToConnector { get; set; }
        public string Color { get; set; }
        public int LinkWidth { get; set; }
    }
}
