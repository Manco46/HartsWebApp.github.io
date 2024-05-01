Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AppointmentStatusMakeCharsLonger
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Appointments", "Status", Function(c) c.String(maxLength := 50))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Appointments", "Status", Function(c) c.String(maxLength := 15))
        End Sub
    End Class
End Namespace
