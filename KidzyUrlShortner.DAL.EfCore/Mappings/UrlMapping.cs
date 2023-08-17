using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VazirUrlShortner.Domain.Entities;

namespace KidzyUrlShortner.DAL.EfCore.Mappings
{
    public class UrlMapping : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.ToTable("tbl_url");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Slug).IsUnique();
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Slug).HasColumnName("slug").IsRequired().HasMaxLength(10);
            builder.Property(x => x.Link).HasColumnName("link").IsRequired().HasMaxLength(200);
            builder.Property(x => x.TimesVisited).HasColumnName("times_visited").IsRequired().HasDefaultValue(0);
            builder.Property(x => x.CreationDate).HasColumnName("creation_date").IsRequired();
        }
    }
}
