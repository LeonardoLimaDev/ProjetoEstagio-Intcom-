namespace ProjetoEstagio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testecomputador : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computadors", "PlacaMae_ID", "dbo.PlacaMaes");
            DropForeignKey("dbo.Computadors", "Processador_ID", "dbo.Processadors");
            DropIndex("dbo.Computadors", new[] { "PlacaMae_ID" });
            DropIndex("dbo.Computadors", new[] { "Processador_ID" });
            RenameColumn(table: "dbo.Computadors", name: "PlacaMae_ID", newName: "IDPlacaMae");
            RenameColumn(table: "dbo.Computadors", name: "Processador_ID", newName: "IDProcessador");
            AlterColumn("dbo.Computadors", "IDPlacaMae", c => c.Int(nullable: false));
            AlterColumn("dbo.Computadors", "IDProcessador", c => c.Int(nullable: false));
            CreateIndex("dbo.Computadors", "IDPlacaMae");
            CreateIndex("dbo.Computadors", "IDProcessador");
            AddForeignKey("dbo.Computadors", "IDPlacaMae", "dbo.PlacaMaes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Computadors", "IDProcessador", "dbo.Processadors", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Computadors", "IDProcessador", "dbo.Processadors");
            DropForeignKey("dbo.Computadors", "IDPlacaMae", "dbo.PlacaMaes");
            DropIndex("dbo.Computadors", new[] { "IDProcessador" });
            DropIndex("dbo.Computadors", new[] { "IDPlacaMae" });
            AlterColumn("dbo.Computadors", "IDProcessador", c => c.Int());
            AlterColumn("dbo.Computadors", "IDPlacaMae", c => c.Int());
            RenameColumn(table: "dbo.Computadors", name: "IDProcessador", newName: "Processador_ID");
            RenameColumn(table: "dbo.Computadors", name: "IDPlacaMae", newName: "PlacaMae_ID");
            CreateIndex("dbo.Computadors", "Processador_ID");
            CreateIndex("dbo.Computadors", "PlacaMae_ID");
            AddForeignKey("dbo.Computadors", "Processador_ID", "dbo.Processadors", "ID");
            AddForeignKey("dbo.Computadors", "PlacaMae_ID", "dbo.PlacaMaes", "ID");
        }
    }
}
