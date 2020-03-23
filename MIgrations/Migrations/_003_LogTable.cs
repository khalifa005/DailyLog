using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace DailyLog.Migrations.Migrations
{
    [Migration(3)]
    public class _003_LogTable:AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Logs")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Duration").AsInt32().NotNullable()
                .WithColumn("Details").AsString().NotNullable()
                .WithColumn("title").AsString(255).NotNullable()
                .WithColumn("Is_Active").AsBoolean().WithDefaultValue(true).NotNullable()
                .ForeignKey("Users","Id")
                .ForeignKey("Projects","Id");   

        }
    }
}
