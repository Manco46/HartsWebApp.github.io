Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InsertingTheAddOnTable
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Services", "Add_On", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Services", "Add_On")
        End Sub
    End Class
End Namespace
