Imports System.ComponentModel.DataAnnotations

Public Class ServiceSection


    Public Property ID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Enter Section Name")>
    Public Property SectionName As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Enter Section Description")>
    Public Property SectionDescription As String

    Public Property Services As ICollection(Of Service)

End Class
