using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBuscaCepV2.Migrations
{
    public partial class PopulaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Usuario(Nome,Email,Senha) Values ('Fulano','fulano@email.com','123')");
            mb.Sql("Insert into Usuario(Nome,Email,Senha) Values ('Beltrano','beltrano@email.com','456')");
            mb.Sql("Insert into Usuario(Nome,Email,Senha) Values ('Ciclano','ciclano@email.com','789')");
        }
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Usuarios");
        }
    }
}
