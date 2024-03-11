Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddUserCartTable
        Inherits DbMigration
    
        Public Overrides Sub Up()

            CreateTable(
                "dbo.UserCarts",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .CartID = c.String(),
                        .UserID = c.String(nullable := False, maxLength := 128),
                        .ServiceID = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.UserID, cascadeDelete := True) _
                .Index(Function(t) t.UserID)


        End Sub
        
        Public Overrides Sub Down()


            DropForeignKey("dbo.UserCarts", "UserID", "dbo.AspNetUsers")
            DropIndex("dbo.UserCarts", New String() { "UserID" })
            DropTable("dbo.UserCarts")

        End Sub
    End Class
End Namespace
