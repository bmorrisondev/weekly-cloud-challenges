using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrianmmAzureApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? AmountDue { get; set; }
        public List<LineItem> Items { get; set; }
    }
}
