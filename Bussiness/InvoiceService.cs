using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class InvoiceService
    {
        private readonly InvoiceDataAccess invoiceDataAccess;

        public InvoiceService(InvoiceDataAccess dataAccess)
        {
            this.invoiceDataAccess = dataAccess;
        }

        public List<Invoice> ListInvoices()
        {
            return invoiceDataAccess.GetInvoices();
        }
    }
}
