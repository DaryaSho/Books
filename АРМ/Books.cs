using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ
{
    class Books
    {
        public int Id { get; set; }
        public string BookName { get; set; }

        public string BookAvtor { get; set; }
        public string BookPhoto { get; set; }
        public string BookDescrip { get; set; }
        public int PublicationId { get; set; }
        public int StyleId { get; set; }
        public int CategorId { get; set; }       
        public int BookPrice { get; set; }
        public int PublicatiomYear { get; set; }

    }
}
