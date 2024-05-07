Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ClientUXaboutInstaContact
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Abouts",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .AboutInformation = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.ContactDetails",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .Address = c.String(),
                        .HelpDeskEmail = c.String(),
                        .HelpDeskNumber = c.String(),
                        .ComplaintsEmail = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.InstagramPosts",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .EmbedLinkForPost = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.InstagramPosts")
            DropTable("dbo.ContactDetails")
            DropTable("dbo.Abouts")
        End Sub
    End Class
End Namespace
