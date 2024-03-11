Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class AddAppointments
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Appointments",
                Function(c) New With
                    {
                        .ID = c.String(nullable := False, maxLength := 128),
                        .ClientID = c.String(nullable := False, maxLength := 128),
                        .HairStyleID = c.String(nullable := False),
                        .HairStyleAddOnID = c.String(nullable := False),
                        .Is_Dye = c.Boolean(nullable := False),
                        .Colour = c.String(maxLength := 30),
                        .NailsStyleID = c.String(),
                        .MakeUpStyleID = c.String(),
                        .AppoDate = c.DateTime(nullable := False),
                        .PreferedTimeOfDay = c.String(nullable := False),
                        .Start_Time = c.String(),
                        .End_Time = c.String(),
                        .Fee = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Employee_ID = c.String(maxLength := 20),
                        .Status = c.String(maxLength := 15)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AspNetUsers", Function(t) t.ClientID, cascadeDelete := True) _
                .Index(Function(t) t.ClientID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Appointments", "ClientID", "dbo.AspNetUsers")
            DropIndex("dbo.Appointments", New String() { "ClientID" })
            DropTable("dbo.Appointments")
        End Sub
    End Class
End Namespace
