using AzureDevopsStateTracker.Data;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureDevopsStateTracker.Migrations
{
    public partial class FunctionToTimeInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var rawFunction = @"CREATE OR ALTER FUNCTION ToTime (@segundos float)
                                RETURNS TIME
                                AS BEGIN
                                    return CONVERT(TIME, DATEADD(SECOND, @segundos + 86400000, 0), 114)
                                END";
            migrationBuilder.Sql(rawFunction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropFunction = @$"DROP FUNCTION IF EXISTS {DataBaseConfig.SchemaName}.ToTime";
            migrationBuilder.Sql(dropFunction);
        }
    }
}
