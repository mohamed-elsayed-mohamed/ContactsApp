using ContactsApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact(), ChangedContact));

        private static void ChangedContact(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl contactControl = d as ContactControl;
            Contact contact = e.NewValue as Contact;

            contactControl.lblName.Text = contact.Name;
            contactControl.lblEmail.Text = contact.Email;
            contactControl.lblPhone.Text = contact.Phone;
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
