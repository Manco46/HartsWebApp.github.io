﻿Imports System.ComponentModel.DataAnnotations

Public Class Service

    Public Property ID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Which Section")>
    Public Property SectionID As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="What Sexuality")>
    Public Property Sexuality As String

    <Display(Name:="Is This An Add-On")>
    Public Property Add_On As Boolean

    <Required(ErrorMessage:="This field is required"), Display(Name:="Which Category")>
    Public Property Category As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="What Type")>
    Public Property Type As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Full Description")>
    Public Property Description As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="Duration (minutes)")>
    <DataType(DataType.Duration)>
    Public Property Duration As String

    <Required(ErrorMessage:="This field is required"), Display(Name:="The Cost")>
    <DataType(DataType.Currency)>
    Public Property Fee As String

    <DataType(DataType.ImageUrl, ErrorMessage:="This should be a valid image or pictuer url."), Display(Name:="Link of Picture")>
    Public Property Picture As String

    Public Property myServiceSection As ServiceSection

    Public Property appointmentServices As ICollection(Of AppointmentService)

    Public Property UserCarts As ICollection(Of UserCart)

End Class
