Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddingServiceSectionModifyingServiceTable
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ServiceSections",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .SectionName = c.String(nullable := False),
                        .SectionDescription = c.String(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.Services", "Section", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Services", "Section")
            DropTable("dbo.ServiceSections")
        End Sub
    End Class
End Namespace
