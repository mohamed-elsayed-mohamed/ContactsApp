using ContactsApp.Classes;
using SQLite;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadContacts();
        }

        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            this.Hide();
            newContactWindow.ShowDialog();
            this.Show();
            ReadContacts();
        }

        private void ReadContacts()
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }

            lvContacts.ItemsSource = contacts;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = ((TextBox)sender).Text;
            List<Contact> filterList = contacts.Where(contact => contact.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
            // Filter using LINQ and return the IDs
            List<int> filterIDs = (from contact in contacts
                                   where contact.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                   orderby contact.Name
                                   select contact.ID).ToList();
            lvContacts.ItemsSource = filterList;
        }

        private void lvContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact seletecdContact = (Contact)lvContacts.SelectedItem;

            if(seletecdContact != null)
            {
                ContactsDetailsWindow detailsWindow = new ContactsDetailsWindow(seletecdContact);
                this.Hide();
                detailsWindow.ShowDialog();
                this.Show();
                ReadContacts();
            }
        }
    }
}
