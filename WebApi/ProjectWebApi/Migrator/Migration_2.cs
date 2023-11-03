using FluentMigrator;
using Prompt.Infrastructure;

namespace ProjectWebApi.Migrator
{
        [Migration(11111)]
    public class Migration_2 : Migration
    {
        public override void Down()
        {
            //throw new System.NotImplementedException();
            Delete.Table("ExtraFieldTable");
            //Delete.FromTable("fluentmigration").Row(new { Name = "Added Migration", migration = "insert data in fluentmigration" });
        }

        public override void Up()
        {
            //throw new System.NotImplementedException();

            Create.Table("ExtraFieldTable")
            .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
            .WithColumn("Name").AsString(100).NotNullable() //varchar
            .WithColumn("Address").AsString(int.MaxValue).NotNullable() //varchar(max)
            .WithColumn("Subject").AsCustom("nvarchar(2000)").NotNullable() //nvarchar(max)
           .WithColumn("InterestRate").AsDecimal(7, 2) // decimal(7,2)
            .WithColumn("Discount").AsFloat() // float
            .WithCreatedBy(ColumnType.Nullable).WithDefaultCreatedOn() // datetime,bit
            .WithUpdatedBy(ColumnType.Nullable).WithUpdatedOn() // big int
            .WithVersionNo()
           .WithColumn("IsActive").AsBoolean().WithDefaultValue(true); // bit

            //Insert.IntoTable("fluentmigration").Row(new { Name = "Added Migration", migration = "insert data in fluentmigration" });

        }
    }
}
