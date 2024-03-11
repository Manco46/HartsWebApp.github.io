Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateUserCartTableIDforAutoIDGenerate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropPrimaryKey("dbo.UserCarts")
            AlterColumn("dbo.UserCarts", "ID", Function(c) c.String(nullable := False, maxLength := 128))
            AddPrimaryKey("dbo.UserCarts", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropPrimaryKey("dbo.UserCarts")
            AlterColumn("dbo.UserCarts", "ID", Function(c) c.String(nullable := False, maxLength := 128))
            AddPrimaryKey("dbo.UserCarts", "ID")
        End Sub
    End Class
End Namespace
