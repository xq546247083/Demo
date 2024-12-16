using EFDemo.DB.TypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.DB.Model
{
    [EntityTypeConfiguration(typeof(BookTypeConfiguration))]
    public class Book
    {
        public int ID
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public List<Label> Labels
        {
            get; set;
        }
    }
}