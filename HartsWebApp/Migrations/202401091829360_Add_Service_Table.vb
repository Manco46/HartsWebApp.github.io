Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Add_Service_Table
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Services",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .Sexuality = c.String(nullable := False),
                        .Category = c.String(nullable := False),
                        .Type = c.String(nullable := False),
                        .Description = c.String(nullable := False),
                        .Duration = c.String(nullable := False),
                        .Fee = c.String(nullable := False),
                        .Picture = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Services")
        End Sub
    End Class
End Namespace
