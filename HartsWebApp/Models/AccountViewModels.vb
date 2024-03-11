Imports System.ComponentModel.DataAnnotations

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <Display(Name:="Email Address")>
    Public Property Email As String
End Class

Public Class ExternalLoginListViewModel
    Public Property ReturnUrl As String
End Class

Public Class SendCodeViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
    Public Property ReturnUrl As String
    Public Property RememberMe As Boolean
End Class

Public Class VerifyCodeViewModel
    <Required>
    Public Property Provider As String
    
    <Required>
    <Display(Name:="Code")>
    Public Property Code As String
    
    Public Property ReturnUrl As String
    
    <Display(Name:="Remember this browser?")>
    Public Property RememberBrowser As Boolean

    Public Property RememberMe As Boolean
End Class

Public Class ForgotViewModel
    <Required>
    <Display(Name:="Email Address")>
    Public Property Email As String
End Class

Public Class LoginViewModel
    <Required>
    <Display(Name:="Email Address")>
    <EmailAddress>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <Display(Name:="Remember me?")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel

    <Required(ErrorMessage:="This field is required"), Display(Name:="Name"), StringLength(100, ErrorMessage:="Your name cannot be more than 100 characters")>
    Public Property Name As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Surname"), StringLength(100, ErrorMessage:="Your surname cannot be more than 100 characters")>
    Public Property Surname As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Date of Birth"), DataType(DataType.Date), DisplayFormat(DataFormatString:="{0:dddd, MMMM dd, yyyy}", ApplyFormatInEditMode:=True)>
    Public Property DateOfBirth As DateTime?

    <Required(ErrorMessage:="This field is required"), Display(Name:="Gender")>
    Public Property Gender As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Phone Number")>
    <DataType(DataType.PhoneNumber, ErrorMessage:="This should be a valid Phone Number")>
    Public Property PhoneNumber As String

    <Required(ErrorMessage:="This field is required")>
    <EmailAddress>
    <Display(Name:="Email Address")>
    Public Property Email As String

    <Required(ErrorMessage:="This field is required")>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="Confirm password")>
    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
    Public Property ConfirmPassword As String
End Class

Public Class ResetPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="Email Address")>
    Public Property Email() As String

    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password() As String

    <DataType(DataType.Password)>
    <Display(Name:="Confirm password")>
    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="Email Address")>
    Public Property Email() As String
End Class
