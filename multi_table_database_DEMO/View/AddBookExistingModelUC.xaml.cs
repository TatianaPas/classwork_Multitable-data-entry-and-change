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
    /// Interaction logic for AddBookExistingModelUC.xaml
    /// </summary>
    public partial class AddBookExistingModelUC : UserControl
    {
        public AddBookExistingModelUC()
        {
            InitializeComponent();
            bookIdCombobox.ItemsSource= DAO.getBookTitles();
            bookIdCombobox.DisplayMemberPath = "BookTitleId";

            //linked value to the combobox
            bookIdCombobox.SelectedValuePath = "BookTitleId";
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(bookIdCombobox.Text);
            string copyNumber = copyNumberTextBox.Text;
            string edition = editionTextBox.Text;
            string isbn=isbnTextBox.Text;
            string status = statusComboBox.Text;
            int publicationY= int.Parse(publicationYearTextBox.Text);

            BookCopy bc = new BookCopy();
            bc.BookStatus = status;
            bc.Edition = edition;
            bc.CopyNumber= copyNumber;
            bc.Isbn= isbn;
            bc.PublicationYear = publicationY;

            //link to book title
            bc.BookTitleId = id;

            
            try
            {
                DAO.addBookExistingTitle(bc);
                MessageBox.Show("Book added sucessfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
