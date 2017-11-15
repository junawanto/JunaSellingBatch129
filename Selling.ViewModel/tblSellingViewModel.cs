using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selling.ViewModel
{
    public class tblSellingViewModel
    {
        public int tblSellingID { get; set; }
        public string Invoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Item { get; set; }
        public decimal Total { get; set; }
        public decimal Paid { get; set; }
        public decimal Return { get; set; }
        public string OfficerCode { get; set; }
    }
}
