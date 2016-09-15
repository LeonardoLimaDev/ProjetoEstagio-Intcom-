namespace ProjetoEstagio.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionarios", "IDUsuario", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionarios", "IDUsuario");
        }
    }
}
