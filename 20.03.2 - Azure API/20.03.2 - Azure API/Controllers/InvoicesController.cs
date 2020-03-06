using BrianmmAzureApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrianmmAzureApi.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoices()
        {
            var invoices = new List<Invoice>();
            invoices.Add(new Invoice()
            {
                Id = 1,
                InvoiceDate = DateTime.Now,
                AmountDue = 123.45,
                Items = new List<LineItem>()
                {
                    new LineItem()
                    {
                        ItemName = "Black Cherry",
                        Amount = 1.00,
                        Quantity = 5
                    },
                    new LineItem()
                    {
                        ItemName = "Lime",
                        Amount = 1.00,
                        Quantity = 5
                    }
                }
            });
            invoices.Add(new Invoice()
            {
                Id = 2,
                InvoiceDate = DateTime.Now.AddDays(-2),
                AmountDue = 10.00,
                Items = new List<LineItem>()
                {
                    new LineItem()
                    {
                        ItemName = "Black Cherry",
                        Amount = 1.00,
                        Quantity = 5
                    },
                    new LineItem()
                    {
                        ItemName = "Lime",
                        Amount = 1.00,
                        Quantity = 5
                    }
                }
            });
            return Ok(invoices);
        }
    }
}
