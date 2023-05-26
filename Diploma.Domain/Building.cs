using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Domain
{
    public class Building
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string Preview { get; set; }
        public string Desciption { get; set; }
        public string Square { get; set; }
        public GroupType GroupType { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Size { get; set; }
        public int Floors { get; set; }
    }
}
