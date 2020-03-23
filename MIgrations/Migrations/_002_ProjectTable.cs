using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace DailyLog.Migrations.Migrations
{
    [Migration(2)]
    public class _002_ProjectTable:AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Projects")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Title").AsString(255).NotNullable()
                .WithColumn("Image_Path").AsString().NotNullable();

        }
    }
}
