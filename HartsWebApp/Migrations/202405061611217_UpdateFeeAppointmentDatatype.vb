Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class UpdateFeeAppointmentDatatype
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Appointments", "Fee", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Appointments", "Fee", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
        End Sub
    End Class
End Namespace
