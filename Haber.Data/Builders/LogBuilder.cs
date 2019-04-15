using Haber.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Data.Builders
{
    public class LogBuilder
    {
        public LogBuilder(EntityTypeConfiguration<LogLama> entity)
        {
            entity.HasKey(e => e.Id);


        }
    }
}
