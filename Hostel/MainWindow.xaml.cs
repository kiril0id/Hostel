using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hostel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Сlients.Load();
            this.DataContext = db.Сlients.Local.ToBindingList();
        }




        private void Add_Client(object sender, RoutedEventArgs e)
        {
            NewVisitorForm newVisitorForm = new NewVisitorForm(new Client());
            if (newVisitorForm.ShowDialog() == true)
            {
                Client phone = newVisitorForm.Client;
                db.Сlients.Add(phone);
                db.SaveChanges();
            }
        }

        private void Edit_Client(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (clientsList.SelectedItem == null) return;
            // получаем выделенный объект
            Client client = clientsList.SelectedItem as Client;

            NewVisitorForm newVisitorForm = new NewVisitorForm(new Client
            {
                id = client.id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Surname = client.Surname,
                Room = client.Room,
                DateStart = client.DateStart,
                DateEnd = client.DateEnd,
            });

            if (newVisitorForm.ShowDialog() == true)
            {

                client = db.Сlients.Find(newVisitorForm.Client.id);
                if (client != null)
                {
                    client.FirstName = newVisitorForm.Client.FirstName;
                    client.LastName = newVisitorForm.Client.LastName;
                    client.Surname = newVisitorForm.Client.Surname;
                    client.Room = newVisitorForm.Client.Room;
                    client.DateStart = newVisitorForm.Client.DateStart;
                    client.DateEnd = newVisitorForm.Client.DateEnd;

                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void Delete_Client(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (clientsList.SelectedItem == null) return;
            
            Client client = clientsList.SelectedItem as Client;
            db.Сlients.Remove(client);
            db.SaveChanges();
        }
    }
}
