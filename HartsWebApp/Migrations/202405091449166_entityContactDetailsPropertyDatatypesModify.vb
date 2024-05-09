Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class entityContactDetailsPropertyDatatypesModify
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.ContactDetails", "Address", Function(c) c.String(nullable := False))
            AlterColumn("dbo.ContactDetails", "HelpDeskEmail", Function(c) c.String(nullable := False))
            AlterColumn("dbo.ContactDetails", "HelpDeskNumber", Function(c) c.String(nullable := False))
            AlterColumn("dbo.ContactDetails", "ComplaintsEmail", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.ContactDetails", "ComplaintsEmail", Function(c) c.String())
            AlterColumn("dbo.ContactDetails", "HelpDeskNumber", Function(c) c.String())
            AlterColumn("dbo.ContactDetails", "HelpDeskEmail", Function(c) c.String())
            AlterColumn("dbo.ContactDetails", "Address", Function(c) c.String())
        End Sub
    End Class
End Namespace
