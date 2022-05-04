using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multi_table_database_DEMO.DB
{
    internal class DAO
    {
        public static List <BookTitle> getBookTitles()
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                return ctx.BookTitles.ToList();

            }
        }
        public static void addBook(BookCopy bc)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {               
                ctx.BookCopies.Add(bc);
                ctx.SaveChanges();
            }
        }
        public static void addBookExistingTitle(BookCopy bc)
        {
            using (DAD_TatianaContext ctx = new DAD_TatianaContext())
            {
                ctx.BookCopies.Add(bc);
               // ctx.Entry(bc.BookTitle).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }
    }
}
