using Haber.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data.Builders
{
  public class HaberBuilder
    {
        public HaberBuilder(EntityTypeConfiguration<Haberler> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.HaberBaslik).IsRequired();
            entity.Property(e => e.HaberDetay).IsRequired();
            entity.Property(e => e.HaberPhoto).IsRequired();
            entity.Property(e => e.IsActive).IsRequired();

        }

    }
}
