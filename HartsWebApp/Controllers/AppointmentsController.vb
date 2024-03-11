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
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security

Namespace Controllers

    <Authorize>
    Public Class AppointmentsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Appointments
        Async Function Index() As Task(Of ActionResult)
            Dim appointments = db.Appointments.Include(Function(a) a.myUser)
            Return View(Await appointments.ToListAsync())
        End Function

        ' GET: Appointments/Details/5
        Async Function Details(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim appointment As Appointment = Await db.Appointments.FindAsync(id)
            If IsNothing(appointment) Then
                Return HttpNotFound()
            End If
            Return View(appointment)
        End Function

        ' GET: Appointments/Create
        Function Create() As ActionResult
            ViewBag.UserID = New SelectList(db.Users, "Id", "Email")
            Return View()
        End Function

        ' POST: Appointments/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="ID,UserID,HairServiceID,HairServiceAddOnID,Is_Dye,Colour,NailsServiceID,NailsServiceAddOnID,MakeUpServiceID,MakeUpServiceAddOnID,AppoDate,PreferedTimeOfDay,Start_Time,End_Time,Fee,Employee_ID,Status")> ByVal appointment As Appointment) As Task(Of ActionResult)


            appointment.UserID = User.Identity.GetUserId


            If ModelState.IsValid Then
                db.Appointments.Add(appointment)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Dim catergoryList = From s In db.Services Select s.Category.ToUpper
            ViewBag.lstCategory = catergoryList
            Dim gender As New List(Of String)
            gender.Add("MALE")
            gender.Add("FEMALE")
            ViewBag.lstGender = gender
            ViewBag.UserID = New SelectList(db.Users, "Id", "Email", appointment.UserID)
            Return View(appointment)
        End Function

        ' GET: Appointments/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim appointment As Appointment = Await db.Appointments.FindAsync(id)
            If IsNothing(appointment) Then
                Return HttpNotFound()
            End If
            ViewBag.UserID = New SelectList(db.Users, "Id", "Email", appointment.UserID)
            Return View(appointment)
        End Function

        ' POST: Appointments/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,UserID,HairServiceID,HairServiceAddOnID,Is_Dye,Colour,NailsServiceID,NailsServiceAddOnID,MakeUpServiceID,MakeUpServiceAddOnID,AppoDate,PreferedTimeOfDay,Start_Time,End_Time,Fee,Employee_ID,Status")> ByVal appointment As Appointment) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(appointment).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.UserID = New SelectList(db.Users, "Id", "Email", appointment.UserID)
            Return View(appointment)
        End Function

        ' GET: Appointments/Delete/5
        Async Function Delete(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim appointment As Appointment = Await db.Appointments.FindAsync(id)
            If IsNothing(appointment) Then
                Return HttpNotFound()
            End If
            Return View(appointment)
        End Function

        ' POST: Appointments/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As String) As Task(Of ActionResult)
            Dim appointment As Appointment = Await db.Appointments.FindAsync(id)
            db.Appointments.Remove(appointment)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Public Async Function HairSection() As Task(Of PartialViewResult)
            Dim results = Await db.Services.ToListAsync
            Dim catergoryList = From s In db.Services Select s.Category.ToUpper
            ViewBag.lstCategory = Await catergoryList.ToListAsync

            Dim gender As New List(Of String)
            gender.Add("MALE")
            gender.Add("FEMALE")
            ViewBag.lstGender = gender

            If IsNothing(results) Then
                ViewBag.Error = "There Is Nothing In The Table"
            End If

            Return PartialView("_HairSection", results)
        End Function

        Public Async Function filterHairSection(genderFilter As String, catergory As String) As Task(Of PartialViewResult)
            '  Dim results = From s In db.Services
            '                Where s.Category = "Hair Service"
            '               Select Case s
            '
            'Dim results As New List(Of Service)
            'Dim catergoryList = From s In db.Services Select s.Category.ToUpper
            'ViewBag.lstCategory = catergoryList

            'Dim gender As New List(Of String)
            'gender.Add("MALE")
            'gender.Add("FEMALE")
            'ViewBag.lstGender = gender

            Dim results = From s In db.Services
            'Await db.Services.ToListAsync

            If Not String.IsNullOrEmpty(genderFilter) Then
                results = results.Where(Function(s) s.Sexuality.Contains(genderFilter))

            End If
            If Not String.IsNullOrEmpty(catergory) Then
                results = results.Where(Function(s) s.Category.Contains(catergory))
            End If

            If IsNothing(results) Then
                ViewBag.Error = "There Is Nothing In The Table"
            End If

            Return PartialView("_ServiceItems", Await results.ToListAsync)
        End Function

    End Class
End Namespace
