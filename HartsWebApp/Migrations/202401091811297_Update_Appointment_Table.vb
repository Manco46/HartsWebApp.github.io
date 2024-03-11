Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Update_Appointment_Table
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameColumn(table := "dbo.Appointments", name := "ClientID", newName := "UserID")
            RenameIndex(table := "dbo.Appointments", name := "IX_ClientID", newName := "IX_UserID")
            AddColumn("dbo.Appointments", "HairServiceID", Function(c) c.String())
            AddColumn("dbo.Appointments", "HairServiceAddOnID", Function(c) c.String())
            AddColumn("dbo.Appointments", "NailsServiceID", Function(c) c.String())
            AddColumn("dbo.Appointments", "NailsServiceAddOnID", Function(c) c.String())
            AddColumn("dbo.Appointments", "MakeUpServiceID", Function(c) c.String())
            AddColumn("dbo.Appointments", "MakeUpServiceAddOnID", Function(c) c.String())
            DropColumn("dbo.Appointments", "HairStyleID")
            DropColumn("dbo.Appointments", "HairStyleAddOnID")
            DropColumn("dbo.Appointments", "NailsStyleID")
            DropColumn("dbo.Appointments", "MakeUpStyleID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Appointments", "MakeUpStyleID", Function(c) c.String())
            AddColumn("dbo.Appointments", "NailsStyleID", Function(c) c.String())
            AddColumn("dbo.Appointments", "HairStyleAddOnID", Function(c) c.String(nullable := False))
            AddColumn("dbo.Appointments", "HairStyleID", Function(c) c.String(nullable := False))
            DropColumn("dbo.Appointments", "MakeUpServiceAddOnID")
            DropColumn("dbo.Appointments", "MakeUpServiceID")
            DropColumn("dbo.Appointments", "NailsServiceAddOnID")
            DropColumn("dbo.Appointments", "NailsServiceID")
            DropColumn("dbo.Appointments", "HairServiceAddOnID")
            DropColumn("dbo.Appointments", "HairServiceID")
            RenameIndex(table := "dbo.Appointments", name := "IX_UserID", newName := "IX_ClientID")
            RenameColumn(table := "dbo.Appointments", name := "UserID", newName := "ClientID")
        End Sub
    End Class
End Namespace
