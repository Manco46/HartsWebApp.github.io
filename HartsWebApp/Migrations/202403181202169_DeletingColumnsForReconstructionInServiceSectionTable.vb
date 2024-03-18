Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class DeletingColumnsForReconstructionInServiceSectionTable
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.ServiceSections", "SectionName")
            DropColumn("dbo.ServiceSections", "SectionDescription")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.ServiceSections", "SectionDescription", Function(c) c.String(nullable := False))
            AddColumn("dbo.ServiceSections", "SectionName", Function(c) c.String(nullable := False))
        End Sub
    End Class
End Namespace
