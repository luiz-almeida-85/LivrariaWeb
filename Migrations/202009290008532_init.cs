namespace LivrariaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Escritor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        Editora = c.String(nullable: false),
                        Endereço = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Npag = c.Int(nullable: false),
                        Gereno = c.String(nullable: false),
                        IdEscritor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Escritor", t => t.IdEscritor, cascadeDelete: true)
                .Index(t => t.IdEscritor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livros", "IdEscritor", "dbo.Escritor");
            DropIndex("dbo.Livros", new[] { "IdEscritor" });
            DropTable("dbo.Livros");
            DropTable("dbo.Escritor");
        }
    }
}
