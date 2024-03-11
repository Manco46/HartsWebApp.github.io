


Imports System.Web.Mvc
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework

Namespace Controllers
    <Authorize>
    Public Class RoleController
        Inherits Controller

        Private db As ApplicationDbContext
        Private roleManager As RoleManager(Of IdentityRole)

        Public Sub New()

            db = New ApplicationDbContext
            roleManager = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(db))

        End Sub

        ' GET: Role
        Function Index() As ActionResult
            Dim roles = roleManager.Roles.ToList
            Return View(roles)

        End Function

        Public Function Create() As ActionResult
            Return View()
        End Function

        '<ValidateAntiForgeryToken>
        <HttpPost>
        Public Function Create(newRole As RoleViewModel) As ActionResult

            Try

                If ModelState.IsValid Then
                    If Not roleManager.RoleExists(newRole.Name) Then

                        Dim role = New IdentityRole(newRole.Name)
                        Dim results = roleManager.Create(role)

                        If results.Succeeded Then
                            Return RedirectToAction("Index", "Role")
                        Else
                            ModelState.AddModelError("", "Error while creating a role, please try again later.")
                        End If
                    Else
                        ModelState.AddModelError("", "Role already exists")
                    End If

                End If
                Return View(newRole)
            Catch ex As Exception
                Return View()
            End Try
        End Function

    End Class
End Namespace