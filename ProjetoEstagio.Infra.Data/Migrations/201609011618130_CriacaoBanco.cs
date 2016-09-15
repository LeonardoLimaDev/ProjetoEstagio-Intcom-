namespace ProjetoEstagio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computadors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlacaMae_ID = c.Int(),
                        Processador_ID = c.Int(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PlacaMaes", t => t.PlacaMae_ID)
                .ForeignKey("dbo.Processadors", t => t.Processador_ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.PlacaMae_ID)
                .Index(t => t.Processador_ID)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.Hds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Capacidade = c.String(),
                        Computador_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Computadors", t => t.Computador_ID)
                .Index(t => t.Computador_ID);
            
            CreateTable(
                "dbo.MemoriaRAMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Capacidade = c.String(),
                        Computador_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Computadors", t => t.Computador_ID)
                .Index(t => t.Computador_ID);
            
            CreateTable(
                "dbo.PlacaMaes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Modelo = c.String(),
                        Marca = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Processadors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Modelo = c.String(),
                        Marca = c.String(),
                        Velocidade = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Funcionarios", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Usuarios", "ID", "dbo.Funcionarios");
            DropForeignKey("dbo.Computadors", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Computadors", "Processador_ID", "dbo.Processadors");
            DropForeignKey("dbo.Computadors", "PlacaMae_ID", "dbo.PlacaMaes");
            DropForeignKey("dbo.MemoriaRAMs", "Computador_ID", "dbo.Computadors");
            DropForeignKey("dbo.Hds", "Computador_ID", "dbo.Computadors");
            DropIndex("dbo.Usuarios", new[] { "ID" });
            DropIndex("dbo.Funcionarios", new[] { "Empresa_ID" });
            DropIndex("dbo.MemoriaRAMs", new[] { "Computador_ID" });
            DropIndex("dbo.Hds", new[] { "Computador_ID" });
            DropIndex("dbo.Computadors", new[] { "Empresa_ID" });
            DropIndex("dbo.Computadors", new[] { "Processador_ID" });
            DropIndex("dbo.Computadors", new[] { "PlacaMae_ID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Empresas");
            DropTable("dbo.Processadors");
            DropTable("dbo.PlacaMaes");
            DropTable("dbo.MemoriaRAMs");
            DropTable("dbo.Hds");
            DropTable("dbo.Computadors");
        }
    }
}
