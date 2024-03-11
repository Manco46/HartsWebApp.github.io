Imports System.ComponentModel.DataAnnotations

Public Class RoleViewModel

    <Required(ErrorMessage:="This Field Is Required"), Display(Name:="User Role")>
    Public Property Name As String

End Class
