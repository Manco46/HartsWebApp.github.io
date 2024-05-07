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
    Public Class AboutsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Abouts/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim about As About = Await db.About.FindAsync(id)
            If IsNothing(about) Then
                Call Dispose(True)
                Return HttpNotFound()
            End If
            Call Dispose(True)
            Return View(about)
        End Function

        ' POST: Abouts/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="AboutInformation,AboutAdditionalInformation,EmbedLinkForPost,EmbedLinkForPost2,EmbedLinkForPost3,EmbedLinkForPost4")> ByVal about As About) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(about).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Call Dispose(True)
                Return RedirectToAction("Index")
            End If
            Return View(about)
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
