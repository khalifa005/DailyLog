using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace Migrations.DailyLog.Migrations
{
    [Migration(2)]
    public class _002_ProjectTable :AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(Tables.Project)
                .WithIdColumn()
                .WithColumn("title").AsString(StringLength.Hundred).NotNullable()
                .WithColumn("image_path").AsString().NotNullable();

        }
    }
}
