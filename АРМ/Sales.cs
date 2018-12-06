using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АРМ
{
    class Sales
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime SaleData { get; set; }
        public int Amout { get; set; }
    }
}
