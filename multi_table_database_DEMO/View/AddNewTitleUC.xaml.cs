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
using multi_table_database_DEMO.DB;

namespace multi_table_database_DEMO.View
{
    /// <summary>
    /// Interaction logic for AddNewTitleUC.xaml
    /// </summary>
    public partial class AddNewTitleUC : UserControl
    {
        public AddNewTitleUC()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            string author = authorTextBox.Text;
            string publisher = publisherTextBox.Text;
            string copyNumber = copyNumberTextBox.Text;
            string edition = editionTextBox.Text;
            int pyear=int.Parse(publicationYearTextBox.Text);
            string isbn = isbnTextBox.Text;
            string status = statusCombobox.Text;

            BookTitle title = new BookTitle();
            title.Author = author;
            title.Publisher = publisher;
            BookCopy copy = new BookCopy();
            copy.Isbn = isbn;
            copy.Edition = edition;
            copy.CopyNumber=copyNumber;
            copy.PublicationYear = pyear;
            copy.BookStatus= status;

            copy.BookTitle = title;
           
            try
            {
                DAO.addBook(copy);
                MessageBox.Show("Book added sucessfully");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
