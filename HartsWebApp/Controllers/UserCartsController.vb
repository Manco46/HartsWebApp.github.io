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
Imports Newtonsoft.Json

Namespace Controllers
    <Authorize>
    Public Class UserCartsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext
        'Dim lstServices As New List(Of String)

        Private Sub ViewbagIntialisation()
            If User.Identity.IsAuthenticated Then
                Dim lstTimesRequired As New List(Of String)
                lstTimesRequired.Add("07:00")
                lstTimesRequired.Add("08:00")
                lstTimesRequired.Add("09:00")
                lstTimesRequired.Add("10:00")
                lstTimesRequired.Add("11:00")
                lstTimesRequired.Add("12:00")
                lstTimesRequired.Add("13:00")
                lstTimesRequired.Add("14:00")
                lstTimesRequired.Add("15:00")
                lstTimesRequired.Add("16:00")
                lstTimesRequired.Add("17:00")
                lstTimesRequired.Add("18:00")
                lstTimesRequired.Add("19:00")
                lstTimesRequired.Add("20:00")
                ViewBag.TimesRequired = lstTimesRequired

                Dim userid As String = User.Identity.GetUserId
                ViewBag.UserID = userid


                Dim firstFee = db.UserCarts.Where(Function(c) c.UserID = userid).Select(Function(T) T.myService).FirstOrDefault()

                If firstFee IsNot Nothing Then
                    ViewBag.TotalAmount = CStr(db.UserCarts.Where(Function(c) c.UserID = userid).Select(Function(T) T.myService).Sum(Function(j) j.Fee))
                Else
                    ' Handle the case where there are no service fees
                    ViewBag.TotalAmount = CStr("0")
                End If




            End If
        End Sub

        ' GET: UserCarts
        Async Function Index() As Task(Of ActionResult)
            ViewbagIntialisation()

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

            Call Dispose(True)
            Return View(service)
        End Function


        Async Function GetCartSectionItems() As Task(Of PartialViewResult)

            If User.Identity.IsAuthenticated Then
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
                Call Dispose(True)
                Return PartialView("GetCartSectionItems", service)
            End If
            Call Dispose(True)
            Return PartialView("GetCartSectionItems")

        End Function

        ' GET: UserCarts/Details/5
        Async Function Details(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userCart As UserCart = Await db.UserCarts.FindAsync(id)
            If IsNothing(userCart) Then
                Call Dispose(True)
                Return HttpNotFound()
            End If
            Call Dispose(True)
            Return View(userCart)
        End Function




        ' GET: UserCarts/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userCart As UserCart = Await db.UserCarts.FindAsync(id)
            If IsNothing(userCart) Then
                Call Dispose(True)
                Return HttpNotFound()
            End If
            ViewBag.UserID = New SelectList(db.Users, "Id", "FirstName", userCart.UserID)
            Call Dispose(True)
            Return View(userCart)
        End Function

        ' POST: UserCarts/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="ID,CartID,UserID,ServiceID")> ByVal userCart As UserCart) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(userCart).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Call Dispose(True)
                Return RedirectToAction("Index")
            End If
            ViewBag.UserID = New SelectList(db.Users, "Id", "FirstName", userCart.UserID)
            Call Dispose(True)
            Return View(userCart)
        End Function

        ' GET: Services/Delete/5
        Async Function Delete(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cart As UserCart = Await db.UserCarts.FirstOrDefaultAsync(Function(s) s.ServiceID = id)
            If IsNothing(cart) Then
                Call Dispose(True)
                Return HttpNotFound()
            End If
            Call Dispose(True)
            Return View(cart)
        End Function

        ' POST: Services/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As String) As Task(Of ActionResult)
            Dim cart As UserCart = Await db.UserCarts.FirstOrDefaultAsync(Function(s) s.ServiceID = id)
            db.UserCarts.Remove(cart)
            Await db.SaveChangesAsync()
            Call Dispose(True)
            Return RedirectToAction("Index")
        End Function

        Public Async Function AddToCart(ByVal VALUE As String, ByVal sectionID As String) As Task(Of ActionResult)

            If User.Identity.IsAuthenticated Then

                If Await db.UserCarts.AnyAsync(Function(ca) ca.ServiceID = VALUE) Then
                    Call Dispose(True)
                    Return RedirectToAction("Index", "Services", New With {.sectionID = sectionID, .errorMessage = "The Item You Selected Already Exist In Your Cart Records"})

                Else

                    Dim userid As String = User.Identity.GetUserId
                    Dim ID = Guid.NewGuid().ToString("X")


                    If Await db.UserCarts.AnyAsync(Function(c) c.UserID = userid) Then

                        Dim cartSearchModel = Await db.UserCarts.Where(Function(u) u.UserID = userid).FirstOrDefaultAsync

                        Dim model As New UserCart() With {
                            .ID = ID,
                            .CartID = cartSearchModel.CartID,
                            .UserID = userid,
                            .ServiceID = VALUE
                        }
                        If ModelState.IsValid Then

                            db.UserCarts.Add(model)
                            Await db.SaveChangesAsync()
                            Call Dispose(True)
                            Return RedirectToAction("Index", "Services", New With {.sectionID = sectionID})
                        End If

                    Else
                        Dim strCartID = "CART+" + Guid.NewGuid().ToString("P")

                        Dim model As New UserCart() With {
                            .ID = ID,
                            .CartID = strCartID,
                            .UserID = userid,
                            .ServiceID = VALUE
                        }
                        If ModelState.IsValid Then

                            db.UserCarts.Add(model)
                            Await db.SaveChangesAsync()
                            Call Dispose(True)
                            Return RedirectToAction("Index", "Services", New With {.sectionID = sectionID})
                        End If
                    End If
                End If
            End If
            Return RedirectToAction("Index", "Services", New With {.sectionID = sectionID})
        End Function

        Public Async Function CountItemsOnCart() As Task(Of String)
            Dim Count As Integer = 0
            If User.Identity.IsAuthenticated Then
                Dim userid As String = User.Identity.GetUserId.ToString
                Count = Await db.UserCarts.Where(Function(c) c.UserID = userid).CountAsync
                If Not IsNothing(Count) Then
                    Call Dispose(True)
                    Return Count
                End If
            End If
            Call Dispose(True)
            Return Count
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
