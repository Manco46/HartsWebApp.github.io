Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema



Public Class UserCart
    Public Property ID As String
    Public Property CartID As String
    Public Property UserID As String
    Public Property ServiceID As String
    Public Property myUser As ApplicationUser
End Class
