Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class EditingTheDataTypeOfAddOnToBoolean
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Services", "Add_On", Function(c) c.Boolean(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Services", "Add_On", Function(c) c.String())
        End Sub
    End Class
End Namespace
