using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace Migrations.DailyLog.Migrations
{
    [Migration(3)]
    public class _003_LogTable :AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(Tables.Log)
                .WithIdColumn()
                .WithColumn("date_created_gmt").AsDateTime().NotNullable()
                .WithColumn("duration_in_minutes").AsInt32().NotNullable()
                .WithColumn("title").AsString(StringLength.Hundred).NotNullable()
                .WithColumn("details").AsString(StringLength.TwoHundredFiftyFive).NotNullable()
                .WithColumn("is_active").AsBoolean().WithDefaultValue(true).NotNullable()
                .WithColumn("created_by_user_id").AsInt64().NotNullable().ForeignKey(Tables.User, "id").Indexed()
                .WithColumn("project_id").AsInt32().Nullable().ForeignKey(Tables.Project, "id").Indexed();


        }
    }
}
