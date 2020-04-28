using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.API.DataLayer.Models
{
    public class Table
    {
        public string Name { get; set; }
        public DataFields[] Fields { get; set; }
    }
}
