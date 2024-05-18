Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AppointmentModelEdit
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Appointments", "Employee_ID", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Appointments", "Employee_ID", Function(c) c.String(maxLength := 20))
        End Sub
    End Class
End Namespace
