using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hostel
{  
     public class Client : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string surname;
        private int room;
        private string dateStart;
        private string dateEnd;

        public Client() { }

        public int id { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public int Room
        {
            get { return room; }
            set
            {
                room = value;
                OnPropertyChanged("Room");
            }
        }
        public string DateStart
        {
            get { return dateStart; }
            set
            {
                dateStart = value;
                OnPropertyChanged("DateStart");
            }
        }
        public string DateEnd
        {
            get { return dateEnd; }
            set
            {
                dateEnd = value;
                OnPropertyChanged("DateEnd");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
