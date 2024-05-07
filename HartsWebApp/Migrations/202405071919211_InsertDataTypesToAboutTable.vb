Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InsertDataTypesToAboutTable
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Abouts", "AboutInformation", Function(c) c.String(nullable := False))
            AlterColumn("dbo.Abouts", "AboutAdditionalInformation", Function(c) c.String(nullable := False))
            AlterColumn("dbo.Abouts", "EmbedLinkForPost", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Abouts", "EmbedLinkForPost", Function(c) c.String())
            AlterColumn("dbo.Abouts", "AboutAdditionalInformation", Function(c) c.String())
            AlterColumn("dbo.Abouts", "AboutInformation", Function(c) c.String())
        End Sub
    End Class
End Namespace
