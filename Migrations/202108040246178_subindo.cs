namespace ValidadorCep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subindo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CEP = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Enderecoes");
        }
    }
}
