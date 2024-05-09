Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports HartsWebApp

Namespace Controllers
    Public Class ContactDetailsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: ContactDetails/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim contactDetails As ContactDetails = Await db.ContactDetails.FindAsync(id)
            If IsNothing(contactDetails) Then
                Call Dispose(True)
                Return HttpNotFound()
            End If
            Call Dispose(True)
            Return View(contactDetails)
        End Function

        ' POST: ContactDetails/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,Address,HelpDeskEmail,HelpDeskNumber,ComplaintsEmail")> ByVal contactDetails As ContactDetails) As Task(Of ActionResult)

            If ModelState.IsValid Then
                db.Entry(contactDetails).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Call Dispose(True)
                Return RedirectToAction("Contact", "Home")
            End If
            Call Dispose(True)
            Return View(contactDetails)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
