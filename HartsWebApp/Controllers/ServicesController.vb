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
    <Authorize(Roles:="ADMIN")>
    Public Class ServicesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        Private Sub ViewBagInitialisation()
            Dim gender As New List(Of String)
            gender.Add("MALE")
            gender.Add("FEMALE")

            Dim catergoryList = From s In db.Services Select s.Category.ToUpper

            ViewBag.lstCategory = catergoryList
            ViewBag.lstGender = gender
        End Sub

        ' GET: Services
        <AllowAnonymous>
        Async Function Index(ByVal sectionID As String, ByVal errorMessage As String) As Task(Of ActionResult)

            If User.IsInRole("ADMIN") Then
                ViewBagInitialisation()
                Return View(Await db.Services.ToListAsync())
            End If

            ViewBag.ErrorMessage = errorMessage

            ViewBagInitialisation()
            'fix mistake must be id not name
            Return View(Await db.Services.Where(Function(s) s.SectionID = sectionID).ToListAsync())
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
            getViewbagData()

            Return View()
        End Function

        Private Sub getViewbagData()
            Dim getServiceSections = db.ServiceSections.ToList()
            Dim serviceDisplayData As New List(Of SelectListItem)

            For Each item In getServiceSections
                serviceDisplayData.Add(New SelectListItem With {.Text = item.SectionName, .Value = item.ID})
            Next

            ViewBag.Section = serviceDisplayData

            Dim lstGender As New List(Of String)
            lstGender.Add("MALE")
            lstGender.Add("FEMALE")
            ViewBag.Gender = lstGender
        End Sub

        ' POST: Services/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="SectionID,Sexuality,Add_On,Category,Type,Description,Duration,Fee,Picture")> ByVal service As Service) As Task(Of ActionResult)

            service.ID = "service" + Guid.NewGuid().ToString("D")

            If ModelState.IsValid Then
                db.Services.Add(service)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If

            getViewbagData()

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
            getViewbagData()
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

            getViewbagData()

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
