using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator.Expressions;
namespace Migrations.DailyLog.Migrations
{
    [Migration(1)]
    public class _001_UserTable :AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(Tables.User)
                .WithIdColumn()
                .WithNameColumn()
                .WithColumn("email").AsString(StringLength.TwoHundredFiftyFive).NotNullable()
                .WithColumn("password").AsString(StringLength.FiveHundredFifty).NotNullable()
                .WithColumn("phone_nmber").AsString(StringLength.TwoHundredFiftyFive).NotNullable()
                .WithColumn("job_title").AsString(StringLength.TwoHundredFiftyFive).Nullable();

        }
    }
}
