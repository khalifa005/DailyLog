using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator.Builders.Create.Table;

namespace Migrations.DailyLog
{
    internal static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("id")
                .AsInt32()
                .NotNullable()
                .PrimaryKey()
                .Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithNameColumn(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("name")
                .AsString(StringLength.Hundred)
                .NotNullable();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithTimeStamps(this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("created_at")
                .AsDateTime()
                .NotNullable()
                
                .WithColumn("modified_at")
                .AsDateTime()
                .NotNullable();
        }
    }
}
