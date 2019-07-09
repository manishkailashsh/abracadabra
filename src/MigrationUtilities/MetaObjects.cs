using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationUtilities
{
    public class DbObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Type { get; set; }
    }
}
