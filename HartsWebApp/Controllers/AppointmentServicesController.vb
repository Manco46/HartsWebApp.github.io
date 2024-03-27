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
    Public Class AppointmentServicesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: AppointmentServices
        Async Function Index() As Task(Of ActionResult)
            Dim appointmentServices = db.AppointmentServices.Include(Function(a) a.Appointments).Include(Function(a) a.Service)
            Return View(Await appointmentServices.ToListAsync())
        End Function

        ' GET: AppointmentServices/Details/5
        Async Function Details(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim appointmentService As AppointmentService = Await db.AppointmentServices.FindAsync(id)
            If IsNothing(appointmentService) Then
                Return HttpNotFound()
            End If
            Return View(appointmentService)
        End Function

        ' GET: AppointmentServices/Create
        Function Create() As ActionResult
            ViewBag.AppointmentID = New SelectList(db.Appointments, "ID", "UserID")
            ViewBag.ServiceID = New SelectList(db.Services, "ID", "SectionID")
            Return View()
        End Function

        ' POST: AppointmentServices/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="ID,AppointmentID,ServiceID")> ByVal appointmentService As AppointmentService) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.AppointmentServices.Add(appointmentService)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.AppointmentID = New SelectList(db.Appointments, "ID", "UserID", appointmentService.AppointmentID)
            ViewBag.ServiceID = New SelectList(db.Services, "ID", "SectionID", appointmentService.ServiceID)
            Return View(appointmentService)
        End Function

        ' GET: AppointmentServices/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim appointmentService As AppointmentService = Await db.AppointmentServices.FindAsync(id)
            If IsNothing(appointmentService) Then
                Return HttpNotFound()
            End If
            ViewBag.AppointmentID = New SelectList(db.Appointments, "ID", "UserID", appointmentService.AppointmentID)
            ViewBag.ServiceID = New SelectList(db.Services, "ID", "SectionID", appointmentService.ServiceID)
            Return View(appointmentService)
        End Function

        ' POST: AppointmentServices/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,AppointmentID,ServiceID")> ByVal appointmentService As AppointmentService) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(appointmentService).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.AppointmentID = New SelectList(db.Appointments, "ID", "UserID", appointmentService.AppointmentID)
            ViewBag.ServiceID = New SelectList(db.Services, "ID", "SectionID", appointmentService.ServiceID)
            Return View(appointmentService)
        End Function

        ' GET: AppointmentServices/Delete/5
        Async Function Delete(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim appointmentService As AppointmentService = Await db.AppointmentServices.FindAsync(id)
            If IsNothing(appointmentService) Then
                Return HttpNotFound()
            End If
            Return View(appointmentService)
        End Function

        ' POST: AppointmentServices/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As String) As Task(Of ActionResult)
            Dim appointmentService As AppointmentService = Await db.AppointmentServices.FindAsync(id)
            db.AppointmentServices.Remove(appointmentService)
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
