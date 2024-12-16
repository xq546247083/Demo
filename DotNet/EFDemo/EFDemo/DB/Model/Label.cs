using EFDemo.DB.TypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.DB.Model
{
    [EntityTypeConfiguration(typeof(LabelTypeConfiguration))]
    public class Label
    {
        public int ID
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }

        public int BookID
        {
            get; set;
        }
    }
}
