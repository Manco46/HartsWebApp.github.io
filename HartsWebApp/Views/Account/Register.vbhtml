﻿@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Sign Up"
End Code

<h2 class="">@ViewBag.Title.</h2>

@Using Html.BeginForm("Register", "Account", New With {.dropDownRole = ""}, FormMethod.Post, New With {.class = "form-horizontal center-block", .role = "form"})

    @Html.AntiForgeryToken()
    @<h4>Create a New account.</h4>

    @Html.ValidationSummary("", New With {.class = "text-danger"})
    
    @<div Class="card-body">
        <hr />
        <div Class="form-group">
            <div Class="col-md-10">
                @Html.LabelFor(Function(m) m.Name, New With {.class = "sr-only"})
                @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control", .placeholder = "Firstname", .type = "text"})
                @Html.ValidationMessageFor(Function(m) m.Name, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(m) m.Surname, New With {.class = "sr-only"})
            <div Class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Surname, New With {.class = "form-control", .placeholder = "Surname", .type = "text"})
                @Html.ValidationMessageFor(Function(m) m.Surname, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            <div Class="col-md-10">
                @Html.LabelFor(Function(m) m.Gender, New With {.class = "sr-only"})
                @Html.DropDownListFor(Function(m) m.Gender, New SelectList(ViewBag.Gender), "SELECT THE GENDER", New With {.class = "form-control", .placeholder = "Gender", .type = "text"})
                @Html.ValidationMessageFor(Function(m) m.Gender, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            <div Class="col-md-10">
                @Html.TextBoxFor(Function(m) m.DateOfBirth, New With {.class = "form-control", .type = "date"})
                @Html.ValidationMessageFor(Function(m) m.DateOfBirth, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr />
        @If User.IsInRole("ADMIN") Or User.IsInRole("OWNER") Then
            @<div Class="form-group">
                <div Class="col-md-10">
                    @Html.DropDownList("dropDownRole", New SelectList(ViewBag.RoleComboData), "SELECT A ROLE", htmlAttributes:=New With {.class = "form-control"})
                </div>
            </div>

        End If

        <div Class="form-group">
            @Html.LabelFor(Function(m) m.PhoneNumber, New With {.class = "sr-only"})
            <div Class="col-md-10">
                @Html.TextBoxFor(Function(m) m.PhoneNumber, New With {.class = "form-control", .placeholder = "Phone Number", .type = "number"})
                @Html.ValidationMessageFor(Function(m) m.PhoneNumber, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            <div Class="col-md-10">
                @Html.LabelFor(Function(m) m.Email, New With {.class = "sr-only"})
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control", .placeholder = "Email Address", .type = "email"})
                @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(m) m.Password, New With {.class = "sr-only"})
            <div Class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "New Password", .type = "password"})
                @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div Class="form-group">
            @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "sr-only"})
            <div Class="col-md-10">
                @Html.TextBoxFor(Function(m) m.ConfirmPassword, New With {.class = "form-control", .placeholder = "Confirm Password", .type = "password"})
                @Html.ValidationMessageFor(Function(m) m.ConfirmPassword, "", New With {.class = "text-danger"})
            </div>
        </div>
        <hr style="background-color:black;"/>
        <input type="submit" value="Sign Up" Class="btn btn-lg btn-primary btn-block" />
    </div>
End Using

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
