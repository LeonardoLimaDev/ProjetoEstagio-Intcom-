namespace ProjetoEstagio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testeComputadorHdMemoriaRAM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hds", "Computador_ID", "dbo.Computadors");
            DropForeignKey("dbo.MemoriaRAMs", "Computador_ID", "dbo.Computadors");
            DropForeignKey("dbo.Computadors", "Empresa_ID", "dbo.Empresas");
            DropIndex("dbo.Computadors", new[] { "Empresa_ID" });
            DropIndex("dbo.Hds", new[] { "Computador_ID" });
            DropIndex("dbo.MemoriaRAMs", new[] { "Computador_ID" });
            RenameColumn(table: "dbo.Hds", name: "Computador_ID", newName: "IDComputador");
            RenameColumn(table: "dbo.MemoriaRAMs", name: "Computador_ID", newName: "IDComputador");
            RenameColumn(table: "dbo.Computadors", name: "Empresa_ID", newName: "IDEmpresa");
            AlterColumn("dbo.Computadors", "IDEmpresa", c => c.Int(nullable: false));
            AlterColumn("dbo.Hds", "IDComputador", c => c.Int(nullable: false));
            AlterColumn("dbo.MemoriaRAMs", "IDComputador", c => c.Int(nullable: false));
            CreateIndex("dbo.Computadors", "IDEmpresa");
            CreateIndex("dbo.Hds", "IDComputador");
            CreateIndex("dbo.MemoriaRAMs", "IDComputador");
            AddForeignKey("dbo.Hds", "IDComputador", "dbo.Computadors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MemoriaRAMs", "IDComputador", "dbo.Computadors", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Computadors", "IDEmpresa", "dbo.Empresas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computadors", "IDEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.MemoriaRAMs", "IDComputador", "dbo.Computadors");
            DropForeignKey("dbo.Hds", "IDComputador", "dbo.Computadors");
            DropIndex("dbo.MemoriaRAMs", new[] { "IDComputador" });
            DropIndex("dbo.Hds", new[] { "IDComputador" });
            DropIndex("dbo.Computadors", new[] { "IDEmpresa" });
            AlterColumn("dbo.MemoriaRAMs", "IDComputador", c => c.Int());
            AlterColumn("dbo.Hds", "IDComputador", c => c.Int());
            AlterColumn("dbo.Computadors", "IDEmpresa", c => c.Int());
            RenameColumn(table: "dbo.Computadors", name: "IDEmpresa", newName: "Empresa_ID");
            RenameColumn(table: "dbo.MemoriaRAMs", name: "IDComputador", newName: "Computador_ID");
            RenameColumn(table: "dbo.Hds", name: "IDComputador", newName: "Computador_ID");
            CreateIndex("dbo.MemoriaRAMs", "Computador_ID");
            CreateIndex("dbo.Hds", "Computador_ID");
            CreateIndex("dbo.Computadors", "Empresa_ID");
            AddForeignKey("dbo.Computadors", "Empresa_ID", "dbo.Empresas", "ID");
            AddForeignKey("dbo.MemoriaRAMs", "Computador_ID", "dbo.Computadors", "ID");
            AddForeignKey("dbo.Hds", "Computador_ID", "dbo.Computadors", "ID");
        }
    }
}
