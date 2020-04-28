using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jexoy.API.DataLayer.Models
{
    public class DataFields
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public Relationship ForiegnKey { get; set; }
    }
}
