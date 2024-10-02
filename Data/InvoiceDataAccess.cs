using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InvoiceDataAccess
    {
        public static string cadena = "Server=LAB1507-17\\SQLEXPRESS03; Database=VilcaDB; Integrated Security=True";

        // Método para listar facturas
        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                SqlCommand command = new SqlCommand("GetInvoices", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Invoice invoice = new Invoice
                    {
                        InvoiceId = Convert.ToInt32(reader["InvoiceId"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Total = Convert.ToDecimal(reader["Total"]),
                        Active = Convert.ToBoolean(reader["Active"])
                    };
                    invoices.Add(invoice);
                }
            }

            return invoices;
        }
    }
}
