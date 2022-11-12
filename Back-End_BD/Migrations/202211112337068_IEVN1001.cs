namespace Back_End_BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IEVN1001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maestros",
                c => new
                    {
                        Matricula = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        Correo = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Matricula);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Maestros");
        }
    }
}
