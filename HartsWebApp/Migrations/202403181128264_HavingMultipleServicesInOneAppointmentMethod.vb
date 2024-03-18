Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class HavingMultipleServicesInOneAppointmentMethod
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.AppointmentServices",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .AppointmentID = c.String(nullable := False, maxLength := 128),
                        .Service_ID = c.String(maxLength := 128)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.ServiceSections", Function(t) t.Service_ID) _
                .ForeignKey("dbo.Appointments", Function(t) t.AppointmentID, cascadeDelete := True) _
                .Index(Function(t) t.AppointmentID) _
                .Index(Function(t) t.Service_ID)
            
            DropColumn("dbo.Appointments", "HairServiceID")
            DropColumn("dbo.Appointments", "HairServiceAddOnID")
            DropColumn("dbo.Appointments", "Is_Dye")
            DropColumn("dbo.Appointments", "Colour")
            DropColumn("dbo.Appointments", "NailsServiceID")
            DropColumn("dbo.Appointments", "NailsServiceAddOnID")
            DropColumn("dbo.Appointments", "MakeUpServiceID")
            DropColumn("dbo.Appointments", "MakeUpServiceAddOnID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Appointments", "MakeUpServiceAddOnID", Function(c) c.String())
            AddColumn("dbo.Appointments", "MakeUpServiceID", Function(c) c.String())
            AddColumn("dbo.Appointments", "NailsServiceAddOnID", Function(c) c.String())
            AddColumn("dbo.Appointments", "NailsServiceID", Function(c) c.String())
            AddColumn("dbo.Appointments", "Colour", Function(c) c.String(maxLength := 30))
            AddColumn("dbo.Appointments", "Is_Dye", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Appointments", "HairServiceAddOnID", Function(c) c.String())
            AddColumn("dbo.Appointments", "HairServiceID", Function(c) c.String())
            DropForeignKey("dbo.AppointmentServices", "AppointmentID", "dbo.Appointments")
            DropForeignKey("dbo.AppointmentServices", "Service_ID", "dbo.ServiceSections")
            DropIndex("dbo.AppointmentServices", New String() { "Service_ID" })
            DropIndex("dbo.AppointmentServices", New String() { "AppointmentID" })
            DropTable("dbo.AppointmentServices")
        End Sub
    End Class
End Namespace
