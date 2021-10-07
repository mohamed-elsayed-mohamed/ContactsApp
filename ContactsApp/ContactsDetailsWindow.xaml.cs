using ContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactsDetailsWindow.xaml
    /// </summary>
    public partial class ContactsDetailsWindow : Window
    {
        Contact contact;

        public ContactsDetailsWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;
            txtName.Text = contact.Name;
            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = txtName.Text;
            contact.Email = txtEmail.Text;
            contact.Phone = txtPhone.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            this.Close();
        }
    }
}
