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
    Public Class ServiceSectionsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: ServiceSections
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.ServiceSections.ToListAsync())
        End Function

        ' GET: ServiceSections/Details/5
        Async Function Details(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serviceSection As ServiceSection = Await db.ServiceSections.FindAsync(id)
            If IsNothing(serviceSection) Then
                Return HttpNotFound()
            End If
            Return View(serviceSection)
        End Function

        ' GET: ServiceSections/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ServiceSections/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="ID,SectionName,SectionDescription")> ByVal serviceSection As ServiceSection) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.ServiceSections.Add(serviceSection)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(serviceSection)
        End Function

        ' GET: ServiceSections/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serviceSection As ServiceSection = Await db.ServiceSections.FindAsync(id)
            If IsNothing(serviceSection) Then
                Return HttpNotFound()
            End If
            Return View(serviceSection)
        End Function

        ' POST: ServiceSections/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,SectionName,SectionDescription")> ByVal serviceSection As ServiceSection) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(serviceSection).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(serviceSection)
        End Function

        ' GET: ServiceSections/Delete/5
        Async Function Delete(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serviceSection As ServiceSection = Await db.ServiceSections.FindAsync(id)
            If IsNothing(serviceSection) Then
                Return HttpNotFound()
            End If
            Return View(serviceSection)
        End Function

        ' POST: ServiceSections/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As String) As Task(Of ActionResult)
            Dim serviceSection As ServiceSection = Await db.ServiceSections.FindAsync(id)
            db.ServiceSections.Remove(serviceSection)
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
