using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBuscaCepV2.Migrations
{
    public partial class PopulaEnderecos : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Enderecos(Cep,Rua,Bairro,Cidade,UF,UsuarioId) Values('79081-362','Rua Benjamin Correa da Costa','Jardim Nhanhá','Campo Grande','MS',1)");
            mb.Sql("Insert into Enderecos(Cep,Rua,Bairro,Cidade,UF,UsuarioId) Values('79006-190','Rua Melanias Barbosa','Vila Taquarussu','Campo Grande','MS',1)");
            mb.Sql("Insert into Enderecos(Cep,Rua,Bairro,Cidade,UF,UsuarioId) Values('69918-502','Rua Iracema','Vilage Wilde Maciel','Rio Branco','AC',1)");
            mb.Sql("Insert into Enderecos(Cep,Rua,Bairro,Cidade,UF,UsuarioId) Values('89203-066','Rua Coronel Sotero Cardoso da Cunha','Atiradores','Joinville','SC',3)");
            mb.Sql("Insert into Enderecos(Cep,Rua,Bairro,Cidade,UF,UsuarioId) Values('29315-002','Rua Nilton Monteiro dos Santos','Alto União','Cachoeiro de Itapemirim','ES',2)");
            mb.Sql("Insert into Enderecos(Cep,Rua,Bairro,Cidade,UF,UsuarioId) Values('12575-030','Rua Joaquim Alves Pereira','Ponte Alta','Aparecida','SP',2)");
        }
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Enderecos");
        }
    }
}
