Imports System.ComponentModel.DataAnnotations

Public Class About
    Public Property ID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="About Us Introduction")>
    Public Property AboutInformation As String
    <Required(ErrorMessage:="This field is required"), Display(Name:="About Us Conclusion")>
    Public Property AboutAdditionalInformation As String
    <Required(ErrorMessage:="This field is required"), Display(Name:="1. Instagram Post"), DataType(DataType.Html), AllowHtml>
    Public Property EmbedLinkForPost As String
    <Display(Name:="2. Instagram Post"), DataType(DataType.Html), AllowHtml>
    Public Property EmbedLinkForPost2 As String
    <Display(Name:="3. Instagram Post"), DataType(DataType.Html), AllowHtml>
    Public Property EmbedLinkForPost3 As String
    <Display(Name:="4. Instagram Post"), DataType(DataType.Html), AllowHtml>
    Public Property EmbedLinkForPost4 As String

End Class


Public Class ContactDetails
    Public Property ID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Store Address\Location"), DataType(DataType.Text)>
    Public Property Address As String
    <Required(ErrorMessage:="This field is required"), Display(Name:="Helpdesk Email Address"), DataType(DataType.EmailAddress)>
    Public Property HelpDeskEmail As String
    <Required(ErrorMessage:="This field is required"), Display(Name:="Helpdesk Phone Number"), DataType(DataType.PhoneNumber)>
    Public Property HelpDeskNumber As String
    <Required(ErrorMessage:="This field is required"), Display(Name:="Complaints Email Address"), DataType(DataType.EmailAddress)>
    Public Property ComplaintsEmail As String

End Class