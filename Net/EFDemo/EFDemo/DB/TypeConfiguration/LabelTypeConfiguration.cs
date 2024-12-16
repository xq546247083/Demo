using EFDemo.DB.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.DB.TypeConfiguration
{
    public class LabelTypeConfiguration : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.HasKey(r=>r.ID);

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

            builder
                .Property(b => b.BookID)
                .HasColumnType("int(11)")
                .HasDefaultValue(-1)
                .HasComment("书的ID")
                .IsRequired();
        }
    }
}