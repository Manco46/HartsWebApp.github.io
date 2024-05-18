Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports HartsWebApp
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Newtonsoft.Json

Imports Microsoft.AspNet.Identity.EntityFramework
Namespace Controllers

    <Authorize>
    Public Class AppointmentsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext


        ' GET: Appointments
        Async Function Index(ByVal appointmentDate As String, ByVal appointmentStartTime As String) As Task(Of ActionResult)


            Dim appointmentsData = From a In db.Appointments

            'Filter Functions
            If Not String.IsNullOrEmpty(appointmentDate) Then
                appointmentsData = appointmentsData.Where(Function(d) d.AppoDate = appointmentDate)
            End If
            If Not String.IsNullOrEmpty(appointmentStartTime) Then
                appointmentsData = appointmentsData.Where(Function(d) d.Start_Time = appointmentStartTime)
            End If

            'Users Role Get
            If User.IsInRole("ADMIN") Or User.IsInRole("OWNER") Then
                Return View(Await appointmentsData.ToListAsync)
            End If
            If User.IsInRole("EMPLOYEE") Then
                Return View(Await appointmentsData.Where(Function(e) e.Employee_ID = User.Identity.GetUserId).ToListAsync)
            End If

            Return View(Await appointmentsData.Include(Function(a) a.myUser).ToListAsync)
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
        'Function Create() As ActionResult
        '    ViewBag.UserID = New SelectList(db.Users, "Id", "Email")
        '    Return View()
        'End Function

        ' POST: Appointments/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        ''<HttpPost()>
        ''<ValidateAntiForgeryToken()>

        Async Function Create(ByVal appointmentDate As String, ByVal appointmentPreferedTime As String, ByVal appointmentFee As String) As Task(Of JsonResult)

            If IsNothing(appointmentDate) Or appointmentDate = "" Then
                Return Json("Please Select A Date", JsonRequestBehavior.AllowGet)
            ElseIf IsNothing(appointmentPreferedTime) Or appointmentPreferedTime = "" Then
                Return Json("Prefered Time of Appointment", JsonRequestBehavior.AllowGet)
            End If


            Dim rnd As New Random
            Dim userid As String = User.Identity.GetUserId


            Dim filterUser = db.UserCarts.Where(Function(c) c.UserID = userid)
            'fix mistake must be id not name
            Dim groupQuery = filterUser.GroupJoin(db.Services,
                                                      Function(c) c.ServiceID,
                                                      Function(s) s.ID,
                                                      Function(c, services) New With {
                                                        .UserCart = c,
                                                        .Service = services
                                                       })
            Dim service = Await groupQuery.SelectMany(Function(g) g.Service).ToListAsync

            ' Create new appointment
            Dim appointment As New Appointment() With {
                .UserID = userid,
                .ID = Guid.NewGuid().ToString("D") + "=aPpO" + CStr(rnd.Next(10, 9999)),
                .AppoDate = appointmentDate,
                .PreferedTimeOfDay = appointmentPreferedTime,
                .Fee = (service.Select(Function(f) f.Fee).Count),
                .Status = "Payment Required",
                .appointmentServices = New List(Of AppointmentService)()
            }

            ' Add appointment services
            For Each item In service
                Dim ass As New AppointmentService() With {
                    .ID = "appointmentServices" + CStr(rnd.Next(100, 999999999)) + "HARTSservices",
                    .AppointmentID = appointment.ID,
                    .ServiceID = item.ID
                }
                appointment.appointmentServices.Add(ass)
            Next

            ' Add appointment to context and save changes
            db.Appointments.Add(appointment)
            Await db.SaveChangesAsync()

            ' Find the cart associated with the user
            Dim cart = Await db.UserCarts.Where(Function(c) c.UserID = userid).ToListAsync
            If cart Is Nothing Then
                Return Json("Cart was not found,", JsonRequestBehavior.AllowGet)
            End If

            ' Remove all products from the cart
            For Each product In cart
                Dim cartProducDelete As UserCart = Await db.UserCarts.FindAsync(product.ID)
                db.UserCarts.Remove(cartProducDelete)
            Next

            ' Save changes to the database
            Await db.SaveChangesAsync()

            Return Json("Success!, Now Go To Appointments And Make Your Online Payment,", JsonRequestBehavior.AllowGet)
        End Function

        Private Sub ViewBagInitialisation(employeeID As String)

            Dim employeesList = From user In db.Users
                                Select New With {
                                    .ID = user.Id,
                                    .Name = user.FirstName,
                                    .Surname = user.Surname,
                                    .Role = (From userRole In user.Roles
                                             Join role In db.Roles.Where(Function(r) r.Name = "EMPLOYEE")
                                                 On userRole.UserId Equals role.Id)}
            employeesList.ToList

            Dim ITEMS As New List(Of SelectListItem)

            For Each item In employeesList
                If item.ID = employeeID Then
                    ITEMS.Add(New SelectListItem With {.Text = $"{item.Name} {item.Surname}", .Value = $"{item.ID}", .Selected = True})
                End If
                ITEMS.Add(New SelectListItem With {.Text = $"{item.Name} {item.Surname}", .Value = $"{item.ID}"})

            Next

            ViewBag.Employees = ITEMS



        End Sub

        ' GET: Appointments/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If


            Dim appointment = Await db.Appointments.FindAsync(id)



            If IsNothing(appointment) Then
                Return HttpNotFound()
            End If

            Call ViewBagInitialisation(appointment.Employee_ID)

            Dim viewModel As New AppointmentEditViewModel



            viewModel.AppoDate = appointment.AppoDate
            viewModel.Status = appointment.Status
            viewModel.PreferedTimeOfDay = appointment.PreferedTimeOfDay
            viewModel.Start_Time = appointment.Start_Time
            viewModel.End_Time = appointment.End_Time
            viewModel.Fee = appointment.Fee

            ViewBag.UserID = New SelectList(db.Users, "Id", "Email", appointment.UserID)
            Return View(viewModel)
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

            Call ViewBagInitialisation(appointment.Employee_ID)

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

        Public Async Function CountItemsOnCart() As Task(Of String)
            Dim Count As Integer = 0
            If User.Identity.IsAuthenticated Then
                Dim userid As String = User.Identity.GetUserId.ToString
                Count = Await db.Appointments.Where(Function(c) c.UserID = userid).CountAsync
                If Not IsNothing(Count) Then
                    Return Count
                End If
            End If
            Return Count
        End Function

        Public Async Function GetEmployeeDetails() As Task(Of JsonResult)
            ' Retrieve specific columns for a user where UserId matches
            Dim employeeDetails = Await db.Users.Where(Function(u) u.Id = User.Identity.GetUserId.ToString).
                                   Select(Function(employee) New With {
                                       .Name = employee.FirstName,
                                       .Surname = employee.Surname,
                                       .Gender = employee.Gender,
                                       .Phone = employee.PhoneNumber
                                   }).FirstOrDefaultAsync

            ' Return the user details
            Return Json(employeeDetails, JsonRequestBehavior.AllowGet)
        End Function

        Public Async Function ConfirmPayment(ByVal appointmentID As String) As Task(Of ActionResult)

            If Not IsNothing(appointmentID) Then
                Try
                    Dim statusEdit = Await db.Appointments.FindAsync(appointmentID)
                    statusEdit.Status = "Payment confirmation, pending..."
                    db.Entry(statusEdit).Property(Function(a) a.Status).IsModified = True
                    Await db.SaveChangesAsync()
                    Return RedirectToAction("Index", "Appointments")
                Catch ex As DbEntityValidationException
                    For Each vEs In ex.EntityValidationErrors
                        For Each vE In vEs.ValidationErrors
                            Debug.WriteLine("Property: {0} Error: {1}", vE.PropertyName, vE.ErrorMessage)
                        Next
                    Next
                End Try
            End If

            Return RedirectToAction("Index", "Appointments")
        End Function





    End Class
End Namespace
