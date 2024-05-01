Imports System.ComponentModel.DataAnnotations

Public Class Appointment

    Public Property ID As String

    Public Property UserID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Date of Appointment"), DataType(DataType.Date), DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}", ApplyFormatInEditMode:=True)>
    Public Property AppoDate As DateTime

    <Required(ErrorMessage:="This field is required"), Display(Name:="Prefered Time Of The Day")>
    Public Property PreferedTimeOfDay As String

    <Display(Name:="Start Time of Appointment"), DataType(DataType.Time), DisplayFormat(DataFormatString:="{0:HH:mm}", ApplyFormatInEditMode:=True)>
    Public Property Start_Time As String

    <Display(Name:="End Time of Appointment"), DataType(DataType.Time), DisplayFormat(DataFormatString:="{0:HH:mm}", ApplyFormatInEditMode:=True)>
    Public Property End_Time As String

    <Display(Name:="Appointment Fee"), DataType(DataType.Currency)>
    Public Property Fee As Decimal

    <Display(Name:="Employee In Service"), DataType(DataType.Currency), StringLength(20, ErrorMessage:="The employee id cannot be more than 20 characters")>
    Public Property Employee_ID As String

    <Display(Name:="Appointment Status"), StringLength(50, ErrorMessage:="The status cannot be more than 15 characters")>
    Public Property Status As String

    Public Property myUser As ApplicationUser

    Public Property appointmentServices As ICollection(Of AppointmentService)

End Class

Public Class HairServiceViewModel

    Public Property ID As String

    <Display(Name:="Category")>
    Public Property Category As String

    <Display(Name:="Type")>
    Public Property Type As String

    <Display(Name:="Description")>
    Public Property Description As String

    <Display(Name:="Duration (minutes)")>
    <DataType(DataType.Duration)>
    Public Property Duration As String

    <Display(Name:="Cost")>
    <DataType(DataType.Currency)>
    Public Property Fee As String

    <DataType(DataType.ImageUrl)>
    Public Property Picture As Image

End Class

Public Class HairServiceAddOnsViewModel
    <Display(Name:="Hair Add-On's")>
    Public Property HairServiceAddOnID As String

    <Display(Name:="Category")>
    Public Property Category As String

    <Display(Name:="Type")>
    Public Property Type As String

    <Display(Name:="Description")>
    Public Property Description As String

    <Display(Name:="Duration (minutes)")>
    <DataType(DataType.Duration)>
    Public Property Duration As String

    <Display(Name:="Cost")>
    <DataType(DataType.Currency)>
    Public Property Fee As String

    <DataType(DataType.ImageUrl)>
    Public Property Picture As Image

End Class

Public Class NailsServiceViewModel
    <Display(Name:="Nails Service")>
    Public Property NailsServiceID As String

    <Display(Name:="Category")>
    Public Property Category As String

    <Display(Name:="Type")>
    Public Property Type As String

    <Display(Name:="Description")>
    Public Property Description As String

    <Display(Name:="Duration (minutes)")>
    <DataType(DataType.Duration)>
    Public Property Duration As String

    <Display(Name:="Cost")>
    <DataType(DataType.Currency)>
    Public Property Fee As String

    <DataType(DataType.ImageUrl)>
    Public Property Picture As Image
End Class

Public Class NailsServiceAddOnViewModel
    <Display(Name:="Nails Add-On's")>
    Public Property NailsServiceAddOnID As String

    <Display(Name:="Category")>
    Public Property Category As String

    <Display(Name:="Type")>
    Public Property Type As String

    <Display(Name:="Description")>
    Public Property Description As String

    <Display(Name:="Duration (minutes)")>
    <DataType(DataType.Duration)>
    Public Property Duration As String

    <Display(Name:="Cost")>
    <DataType(DataType.Currency)>
    Public Property Fee As String

    <DataType(DataType.ImageUrl)>
    Public Property Picture As Image
End Class
