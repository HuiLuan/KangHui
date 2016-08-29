using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace KangHui.Web.Models.Maps
{
    public class JianBaoMap: EntityTypeConfiguration<JianBao>
    {
        public JianBaoMap()
        {

            this.ToTable("jianbao");
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.CreateTime).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }

    public class KuCunMap : EntityTypeConfiguration<KuCun>
    {
        public KuCunMap()
        {
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.ToTable("kucun");

        }
    }
    public class YueBaoMap : EntityTypeConfiguration<YueBao>
    {
        public YueBaoMap()
        {
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.ToTable("yuebao");

        }
    }
}