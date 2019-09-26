using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLayers.DTO
{
    class Note
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Creator { get; set; }
        public String Content { get; set; }
        public String Date { get; set; }
        public bool IsSharable { get; set; }
    }
}
