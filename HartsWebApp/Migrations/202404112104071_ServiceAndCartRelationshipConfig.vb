Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ServiceAndCartRelationshipConfig
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.UserCarts", "ServiceID", Function(c) c.String(nullable := False, maxLength := 128))
            CreateIndex("dbo.UserCarts", "ServiceID")
            AddForeignKey("dbo.UserCarts", "ServiceID", "dbo.Services", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.UserCarts", "ServiceID", "dbo.Services")
            DropIndex("dbo.UserCarts", New String() { "ServiceID" })
            AlterColumn("dbo.UserCarts", "ServiceID", Function(c) c.String())
        End Sub
    End Class
End Namespace
