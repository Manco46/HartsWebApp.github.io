Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ConfigureServiceANDApplicationServiceRelationshipCorrectly
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.AppointmentServices", "Service_ID", "dbo.ServiceSections")
            DropIndex("dbo.AppointmentServices", New String() { "Service_ID" })
            RenameColumn(table := "dbo.AppointmentServices", name := "Service_ID", newName := "ServiceID")
            AlterColumn("dbo.AppointmentServices", "ServiceID", Function(c) c.String(nullable := False, maxLength := 128))
            CreateIndex("dbo.AppointmentServices", "ServiceID")
            AddForeignKey("dbo.AppointmentServices", "ServiceID", "dbo.Services", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.AppointmentServices", "ServiceID", "dbo.Services")
            DropIndex("dbo.AppointmentServices", New String() { "ServiceID" })
            AlterColumn("dbo.AppointmentServices", "ServiceID", Function(c) c.String(maxLength := 128))
            RenameColumn(table := "dbo.AppointmentServices", name := "ServiceID", newName := "Service_ID")
            CreateIndex("dbo.AppointmentServices", "Service_ID")
            AddForeignKey("dbo.AppointmentServices", "Service_ID", "dbo.ServiceSections", "ID")
        End Sub
    End Class
End Namespace
