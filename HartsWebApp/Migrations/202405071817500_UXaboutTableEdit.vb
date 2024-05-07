Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UXaboutTableEdit
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Abouts", "AboutAdditionalInformation", Function(c) c.String())
            AddColumn("dbo.Abouts", "EmbedLinkForPost", Function(c) c.String())
            AddColumn("dbo.Abouts", "EmbedLinkForPost2", Function(c) c.String())
            AddColumn("dbo.Abouts", "EmbedLinkForPost3", Function(c) c.String())
            AddColumn("dbo.Abouts", "EmbedLinkForPost4", Function(c) c.String())
            DropTable("dbo.InstagramPosts")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.InstagramPosts",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .EmbedLinkForPost = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            DropColumn("dbo.Abouts", "EmbedLinkForPost4")
            DropColumn("dbo.Abouts", "EmbedLinkForPost3")
            DropColumn("dbo.Abouts", "EmbedLinkForPost2")
            DropColumn("dbo.Abouts", "EmbedLinkForPost")
            DropColumn("dbo.Abouts", "AboutAdditionalInformation")
        End Sub
    End Class
End Namespace
