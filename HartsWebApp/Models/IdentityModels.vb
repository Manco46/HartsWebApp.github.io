﻿Imports System.Data.Entity
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser

    Public Property FirstName As String
    Public Property Surname As String
    Public Property Gender As String
    Public Property DateOfBirth As DateTime?
    Public Property Appointments As ICollection(Of Appointment)
    Public Property UserCarts As ICollection(Of UserCart)


    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)

    Public Property Appointments As DbSet(Of Appointment)
    Public Property Services As DbSet(Of Service)
    Public Property UserCarts As DbSet(Of UserCart)
    Public Property ServiceSections As DbSet(Of ServiceSection)
    Public Property AppointmentServices As DbSet(Of AppointmentService)
    Public Property About As DbSet(Of About)

    Public Property ContactDetails As DbSet(Of ContactDetails)

    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)

        modelBuilder.Entity(Of ApplicationUser)() _
            .HasMany(Function(u) u.Appointments) _
            .WithRequired(Function(a) a.myUser) _
            .HasForeignKey(Function(a) a.UserID)

        modelBuilder.Entity(Of ApplicationUser)() _
            .HasMany(Function(u) u.UserCarts) _
            .WithRequired(Function(a) a.myUser) _
            .HasForeignKey(Function(a) a.UserID)

        modelBuilder.Entity(Of Service)() _
            .HasMany(Function(u) u.UserCarts) _
            .WithRequired(Function(s) s.myService) _
            .HasForeignKey(Function(s) s.ServiceID)

        modelBuilder.Entity(Of Appointment)() _
           .HasMany(Function(u) u.appointmentServices) _
           .WithRequired(Function(a) a.Appointments) _
           .HasForeignKey(Function(a) a.AppointmentID)

        modelBuilder.Entity(Of Service)() _
           .HasMany(Function(u) u.appointmentServices) _
           .WithRequired(Function(a) a.Service) _
           .HasForeignKey(Function(a) a.ServiceID)

        modelBuilder.Entity(Of ServiceSection)() _
          .HasMany(Function(u) u.Services) _
          .WithRequired(Function(a) a.myServiceSection) _
          .HasForeignKey(Function(a) a.SectionID)


    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function


    'Public Property ApplicationUsers As System.Data.Entity.DbSet(Of ApplicationUser)
End Class
