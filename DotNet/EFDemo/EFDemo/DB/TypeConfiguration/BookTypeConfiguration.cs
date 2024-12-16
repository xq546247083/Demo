using EFDemo.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.DB.TypeConfiguration
{
    public class BookTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(r=>r.ID);
            builder.HasIndex(r=>r.Title);
            builder.HasMany(r=>r.Labels)
                .WithOne()
                .HasForeignKey(r => r.BookID)
                .IsRequired();

            builder
                .Property(b => b.ID)
                .HasColumnType("int(11)")
                .HasComment("主键")
                .IsRequired()
                .UseMySqlIdentityColumn();

            builder
                .Property(b => b.Title)
                .HasColumnType("varchar(50)")
                .HasComment("标题")
                .IsRequired()
                .HasDefaultValue("");
        }
    }
}