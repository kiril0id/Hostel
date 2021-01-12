using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hostel
{
    /// <summary>
    /// Логика взаимодействия для NewVisitorForm.xaml
    /// </summary>
    public partial class NewVisitorForm : Window
    { 
        public Client Client { get; private set; }

        public NewVisitorForm(Client client)
        {
            InitializeComponent();
            Client = client;
            this.DataContext = Client;
        }

        private void SaveDate(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
