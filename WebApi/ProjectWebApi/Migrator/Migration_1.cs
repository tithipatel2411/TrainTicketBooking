using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace Model.Migrator
{
    [Migration(11121211)]
    public class Migration_1 : Migration
    {
        public override void Down()
        {
            //throw new System.NotImplementedException();
            Delete.Table("Abccccc");
            //Delete.FromTable("fluentmigration").Row(new { Name = "Added Migration", migration = "insert data in fluentmigration" });
        }

        public override void Up()
        {
            //throw new System.NotImplementedException();

            Create.Table("Abcccc")
            .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Subject").AsString().NotNullable();

            //Insert.IntoTable("fluentmigration").Row(new { Name = "Added Migration", migration = "insert data in fluentmigration" });

        }
    }
}
