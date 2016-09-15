namespace ProjetoEstagio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeUsuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuarios", "ID", "dbo.Funcionarios");
            DropIndex("dbo.Usuarios", new[] { "ID" });
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Usuarios", "ID");
            CreateIndex("dbo.Funcionarios", "IDUsuario");
            AddForeignKey("dbo.Funcionarios", "IDUsuario", "dbo.Usuarios", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "IDUsuario", "dbo.Usuarios");
            DropIndex("dbo.Funcionarios", new[] { "IDUsuario" });
            DropPrimaryKey("dbo.Usuarios");
            AlterColumn("dbo.Usuarios", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Usuarios", "ID");
            CreateIndex("dbo.Usuarios", "ID");
            AddForeignKey("dbo.Usuarios", "ID", "dbo.Funcionarios", "ID");
        }
    }
}
