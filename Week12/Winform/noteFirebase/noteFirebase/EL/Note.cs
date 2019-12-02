using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noteFirebase.EL
{
    class Note
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Date { get; set; }
        public String Creator { get; set; }
        public String Content { get; set; }
        public String IsSharable { get; set; }
    }
}
