﻿@ModelType HartsWebApp.ServiceSection
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>ServiceSection</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })       

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SectionName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SectionName, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.SectionName, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.SectionDescription, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.SectionDescription, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.SectionDescription, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
