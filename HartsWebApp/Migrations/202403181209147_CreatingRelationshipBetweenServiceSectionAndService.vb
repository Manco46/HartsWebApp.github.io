Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CreatingRelationshipBetweenServiceSectionAndService
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Services", "myServiceSection_ID", "dbo.ServiceSections")
            DropIndex("dbo.Services", New String() { "myServiceSection_ID" })
            DropColumn("dbo.Services", "SectionID")
            RenameColumn(table := "dbo.Services", name := "myServiceSection_ID", newName := "SectionID")
            AddColumn("dbo.ServiceSections", "SectionName", Function(c) c.String(nullable := False))
            AddColumn("dbo.ServiceSections", "SectionDescription", Function(c) c.String(nullable := False))
            AlterColumn("dbo.Services", "SectionID", Function(c) c.String(nullable := False, maxLength := 128))
            AlterColumn("dbo.Services", "SectionID", Function(c) c.String(nullable := False, maxLength := 128))
            CreateIndex("dbo.Services", "SectionID")
            AddForeignKey("dbo.Services", "SectionID", "dbo.ServiceSections", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Services", "SectionID", "dbo.ServiceSections")
            DropIndex("dbo.Services", New String() { "SectionID" })
            AlterColumn("dbo.Services", "SectionID", Function(c) c.String(maxLength := 128))
            AlterColumn("dbo.Services", "SectionID", Function(c) c.String(nullable := False))
            DropColumn("dbo.ServiceSections", "SectionDescription")
            DropColumn("dbo.ServiceSections", "SectionName")
            RenameColumn(table := "dbo.Services", name := "SectionID", newName := "myServiceSection_ID")
            AddColumn("dbo.Services", "SectionID", Function(c) c.String(nullable := False))
            CreateIndex("dbo.Services", "myServiceSection_ID")
            AddForeignKey("dbo.Services", "myServiceSection_ID", "dbo.ServiceSections", "ID")
        End Sub
    End Class
End Namespace
