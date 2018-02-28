using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactModel.POCOClasses
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? AddedTimestamp { get; set; }
        public DateTime? UpdatedTimestamp { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
