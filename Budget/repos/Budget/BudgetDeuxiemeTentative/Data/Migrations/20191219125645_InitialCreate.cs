using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetDeuxiemeTentative.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banque",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Ville = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IdPersonne = table.Column<Guid>(nullable: false),
                    IdBanque = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecriture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Libelle = table.Column<string>(nullable: false),
                    Debit = table.Column<bool>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    IdCompte = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecriture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    DateDeNaissance = table.Column<DateTime>(nullable: false),
                    Mail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banque");

            migrationBuilder.DropTable(
                name: "Compte");

            migrationBuilder.DropTable(
                name: "Ecriture");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
