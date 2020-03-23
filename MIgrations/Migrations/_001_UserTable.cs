using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator.Expressions;

namespace DailyLog.Migrations.Migrations
{
    [Migration(1)]
    public class _001_UserTable:AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString().NotNullable()
                .WithColumn("Phone_Nmber").AsString(255).NotNullable()
                .WithColumn("Job_title").AsString(255).Nullable();

        }
    }
}
