using Bussiness;
using Data;
using Entity;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InvoiceDataAccess dataAccess = new InvoiceDataAccess();
            InvoiceService service = new InvoiceService(dataAccess);
            InvoiceListViewModel viewModel = new InvoiceListViewModel(service);

            // Asignamos el ViewModel al DataContext
            DataContext = viewModel;
        }

        public class InvoiceListViewModel : INotifyPropertyChanged
        {
            private readonly InvoiceService invoiceService;
            private List<Invoice> invoices;

            public List<Invoice> Invoices
            {
                get { return invoices; }
                set
                {
                    invoices = value;
                    OnPropertyChanged(nameof(Invoices));
                }
            }

            public InvoiceListViewModel(InvoiceService service)
            {
                this.invoiceService = service;
                LoadInvoices();
            }

            public void LoadInvoices()
            {
                Invoices = invoiceService.ListInvoices();
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}