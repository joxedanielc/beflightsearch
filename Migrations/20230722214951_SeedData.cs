using Microsoft.EntityFrameworkCore.Migrations;

namespace beflightsearch.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "FlightName", "AirlineId", "DepartureDateTime", "ArrivalDateTime", "DepartureCity", "ArrivalCity", "Price", "Scales" },
                values: new object[,]
                {
                    { 1, "GYEUIO992", 1, new DateTime(2023, 7, 22, 10, 0, 0), new DateTime(2023, 4, 22, 11, 0, 0), "Guayaquil, Ecuador", "Quito, Ecuador", 86, 0 },
                    { 2, "GYEPAR023", 2, new DateTime(2023, 7, 22, 8, 0, 0), new DateTime(2023, 4, 22, 10, 0, 0), "Guayaquil, Ecuador", "Paris, Francia", 1000, 1 },
                    { 3, "UIOCUE023", 3, new DateTime(2023, 7, 22, 12, 0, 0), new DateTime(2023, 4, 23, 5, 0, 0), "Quito, Ecuador", "Cuenca, Ecuador", 200, 0},
                    { 4, "GYECUE147", 1, new DateTime(2023, 7, 23, 3, 0, 0), new DateTime(2023, 4, 23, 10, 0, 0), "Guayaquil, Ecuador", "Cuenca, Francia", 250, 1 },
                    { 5, "GYEUIO951", 2, new DateTime(2023, 7, 22, 9, 0, 0), new DateTime(2023, 4, 22, 12, 0, 0), "Guayaquil, Ecuador", "Quito, Ecuador", 90, 0 },                    
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
