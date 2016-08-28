using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using KangHui.Web.Models;

namespace KangHui.Web
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("DefaultConnection")
        {
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ef 6新特性，自动加载配置
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<JianBao> JianBao { get; set; }


    }
}