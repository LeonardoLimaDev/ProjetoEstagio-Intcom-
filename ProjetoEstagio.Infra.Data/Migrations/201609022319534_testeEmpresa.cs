namespace ProjetoEstagio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeEmpresa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Funcionarios", "Empresa_ID", "dbo.Empresas");
            DropIndex("dbo.Funcionarios", new[] { "Empresa_ID" });
            RenameColumn(table: "dbo.Funcionarios", name: "Empresa_ID", newName: "IDEmpresa");
            AlterColumn("dbo.Funcionarios", "IDEmpresa", c => c.Int(nullable: false));
            CreateIndex("dbo.Funcionarios", "IDEmpresa");
            AddForeignKey("dbo.Funcionarios", "IDEmpresa", "dbo.Empresas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionarios", "IDEmpresa", "dbo.Empresas");
            DropIndex("dbo.Funcionarios", new[] { "IDEmpresa" });
            AlterColumn("dbo.Funcionarios", "IDEmpresa", c => c.Int());
            RenameColumn(table: "dbo.Funcionarios", name: "IDEmpresa", newName: "Empresa_ID");
            CreateIndex("dbo.Funcionarios", "Empresa_ID");
            AddForeignKey("dbo.Funcionarios", "Empresa_ID", "dbo.Empresas", "ID");
        }
    }
}
