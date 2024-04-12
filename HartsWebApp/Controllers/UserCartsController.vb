﻿Imports System
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

                ViewBag.TotalAmount = "Total Amount: " + CStr(db.UserCarts.Where(Function(c) c.UserID = userid).Select(Function(T) T.myService).Sum(Function(j) j.Fee)) + " ZAR/RANDS"

            End If


        End Sub

        ' GET: UserCarts
        Async Function Index() As Task(Of ActionResult)
            ViewbagIntialisation()
            Return View(Await db.ServiceSections.ToListAsync)
        End Function



        ' GET: UserCarts/AddService
        Function AddService(ByVal serviceID As String) As ActionResult


            'lstServices.Add(serviceID)
            'ViewBag.serviceIDs = lstServices

            'Return Json(ViewBag.serviceIDs, JsonRequestBehavior.AllowGet)

            Dim listOfProductIds As New List(Of String)

            If Request.Cookies("CheckoutProducts") IsNot Nothing Then
                Dim existingCookies As HttpCookie = Request.Cookies("CheckoutProducts")
                Dim existingServiceIds As String = existingCookies.Value
                listOfProductIds = JsonConvert.DeserializeObject(Of List(Of String))(existingServiceIds)
            End If


            listOfProductIds.Add(serviceID)

            Dim jsonServiceIds As String = JsonConvert.SerializeObject(listOfProductIds)

            Dim checkOutCookie As New HttpCookie("CheckoutProducts", jsonServiceIds)

            Response.Cookies.Add(checkOutCookie)

            Return Json(jsonServiceIds, JsonRequestBehavior.AllowGet)


        End Function




        Async Function GetCartSectionItems(ByVal sectionID As String) As Task(Of PartialViewResult)

            If User.Identity.IsAuthenticated Then
                Dim userid As String = User.Identity.GetUserId
                Dim filterUser = db.UserCarts.Where(Function(c) c.UserID = userid)
                'fix mistake must be id not name
                Dim groupQuery = filterUser.GroupJoin(db.Services.Where(Function(fs) fs.SectionID = sectionID),
                                                      Function(c) c.ServiceID,
                                                      Function(s) s.ID,
                                                      Function(c, services) New With {
                                                        .UserCart = c,
                                                        .Service = services
                                                       })
                Dim service = Await groupQuery.SelectMany(Function(g) g.Service).ToListAsync

                Return PartialView("GetCartSectionItems", service)
            End If
            Return PartialView("GetCartSectionItems")

        End Function

        ' GET: UserCarts/Details/5
        Async Function Details(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userCart As UserCart = Await db.UserCarts.FindAsync(id)
            If IsNothing(userCart) Then
                Return HttpNotFound()
            End If
            Return View(userCart)
        End Function




        ' GET: UserCarts/Edit/5
        Async Function Edit(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userCart As UserCart = Await db.UserCarts.FindAsync(id)
            If IsNothing(userCart) Then
                Return HttpNotFound()
            End If
            ViewBag.UserID = New SelectList(db.Users, "Id", "FirstName", userCart.UserID)
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
                Return RedirectToAction("Index")
            End If
            ViewBag.UserID = New SelectList(db.Users, "Id", "FirstName", userCart.UserID)
            Return View(userCart)
        End Function

        ' GET: UserCarts/Delete/5
        Async Function Delete(ByVal id As String) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim userCart As UserCart = Await db.UserCarts.FindAsync(id)
            If IsNothing(userCart) Then
                Return HttpNotFound()
            End If
            Return View(userCart)
        End Function


        ' POST: UserCarts/Delete/5
        ''<ActionName("Delete")>
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As String) As Task(Of ActionResult)
            Dim userCart As UserCart = Await db.UserCarts.FirstOrDefaultAsync(Function(c) c.UserID = User.Identity.GetUserId And c.ServiceID = id)
            db.UserCarts.Remove(userCart)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
        Public Async Function NewAddToCart(ByVal VALUE As String, ByVal sectionID As String) As Task(Of ActionResult)

            If User.Identity.IsAuthenticated Then

                If Await db.UserCarts.AnyAsync(Function(ca) ca.ServiceID = VALUE) Then

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
                            Return RedirectToAction("Index", "Services", New With {.sectionID = sectionID})
                        End If
                    End If
                End If
            End If
            Return RedirectToAction("Index", "Services", New With {.sectionID = sectionID})
        End Function

        Public Async Function AddToCart(ByVal VALUE As String) As Task(Of JsonResult)

            If User.Identity.IsAuthenticated Then

                If Await db.UserCarts.AnyAsync(Function(ca) ca.ServiceID = VALUE) Then

                    Return Json(New With {.itemExist = "The Item You Selected Already Exist In Your Cart Records"}, JsonRequestBehavior.AllowGet)

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
                            Return Json(New With {.numberOfItemsInCart = Await db.UserCarts.Where(Function(c) c.UserID = userid).CountAsync}, JsonRequestBehavior.AllowGet)

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
                            Return Json(New With {.numberOfItemsInCart = Await db.UserCarts.Where(Function(c) c.UserID = userid).CountAsync}, JsonRequestBehavior.AllowGet)

                        End If
                    End If
                End If
            Else

                Return Json(New With {.LoginError = Url.Action("AddToCart", "UserCarts", New With {.sectionName = VALUE})}, JsonRequestBehavior.AllowGet)
            End If
            Return Json(New With {.unknownError = "Contact The Shop Administrator For This Error"}, JsonRequestBehavior.AllowGet)
        End Function

        Public Async Function CountItemsOnCart() As Task(Of String)
            Dim Count As Integer = 0
            If User.Identity.IsAuthenticated Then
                Dim userid As String = User.Identity.GetUserId.ToString
                Count = Await db.UserCarts.Where(Function(c) c.UserID = userid).CountAsync
                If Not IsNothing(Count) Then
                    Return Count
                End If
            End If
            Return Count
        End Function

    End Class
End Namespace
