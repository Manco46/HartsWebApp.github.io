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
    Public Class ServicesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Services
        Async Function Index(ByVal sectionName As String, ByVal errorMessage As String) As Task(Of ActionResult)
            ViewBag.ErrorMessage = errorMessage
            Return View(Await db.Services.Where(Function(s) s.Section = sectionName).ToListAsync())
        End Function

        ' GET: Services/Details/5
        Async Function Details(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Service = Await db.Services.FindAsync(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function

        ' GET: Services/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Services/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="ID,Section,Sexuality,Category,Type,Description,Duration,Fee,Picture")> ByVal service As Service) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Services.Add(service)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(service)
        End Function

        ' GET: Services/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Service = Await db.Services.FindAsync(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function

        ' POST: Services/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,Section,Sexuality,Category,Type,Description,Duration,Fee,Picture")> ByVal service As Service) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(service).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(service)
        End Function

        ' GET: Services/Delete/5
        Async Function Delete(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim service As Service = Await db.Services.FindAsync(id)
            If IsNothing(service) Then
                Return HttpNotFound()
            End If
            Return View(service)
        End Function

        ' POST: Services/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As String) As Task(Of ActionResult)
            Dim service As Service = Await db.Services.FindAsync(id)
            db.Services.Remove(service)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
