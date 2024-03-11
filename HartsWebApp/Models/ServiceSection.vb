Imports System.ComponentModel.DataAnnotations

Public Class ServiceSection

    <Required(ErrorMessage:="This field is required"), Display(Name:="ID")>
    Public Property ID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Enter Section Name")>
    Public Property SectionName As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Enter Section Description")>
    Public Property SectionDescription As String

End Class
