using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.API.DataLayer.Models
{
    public class Relationship
    {
        public string ParentTableName { get; set; }
        public string PrimaryColumnName { get; set; }
    }
}
