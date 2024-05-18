@ModelType HartsWebApp.AppointmentEditViewModel 
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Appointment</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
       
        <div class="form-group">
            @Html.LabelFor(Function(model) model.AppoDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DisplayFor(Function(model) model.AppoDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.EditorFor(Function(model) model.AppoDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.AppoDate, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.PreferedTimeOfDay, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DisplayFor(Function(model) model.PreferedTimeOfDay, New With {.htmlAttributes = New With {.class = "form-control"}})
            </div>
        </div>

        <div class="form-group">

            <div class="list-group">
                <div class="list-group-item">
                    @Html.LabelFor(Function(model) model.myClient.fName, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    @Html.DisplayFor(Function(model) model.myClient.fName, New With {.htmlAttributes = New With {.class = "form-control"}})

                    @Html.LabelFor(Function(model) model.myClient.Surname, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    @Html.DisplayFor(Function(model) model.myClient.Surname, New With {.htmlAttributes = New With {.class = "form-control"}})

                    @Html.LabelFor(Function(model) model.myClient.Gender, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    @Html.DisplayFor(Function(model) model.myClient.Gender, New With {.htmlAttributes = New With {.class = "form-control"}})

                    @Html.LabelFor(Function(model) model.myClient.PhoneNumber, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    @Html.DisplayFor(Function(model) model.myClient.PhoneNumber, New With {.htmlAttributes = New With {.class = "form-control"}})

                    @Html.LabelFor(Function(model) model.myClient.EmailAddress, htmlAttributes:=New With {.class = "control-label col-md-2"})
                    @Html.DisplayFor(Function(model) model.myClient.EmailAddress, New With {.htmlAttributes = New With {.class = "form-control"}})
                </div>

            </div>

        </div>

        <div class="form-group center-block">
            @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Status, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Status, "", New With {.class = "text-danger"})
            </div>
        </div>       

        <div class="form-group center-block">
            @Html.LabelFor(Function(model) model.Start_Time, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DisplayFor(Function(model) model.Start_Time, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.EditorFor(Function(model) model.Start_Time, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Start_Time, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group center-block ">
            @Html.LabelFor(Function(model) model.End_Time, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DisplayFor(Function(model) model.End_Time, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.EditorFor(Function(model) model.End_Time, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.End_Time, "", New With {.class = "text-danger"})
            </div>
        </div>      

        <div class="form-group center-block">           
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.EmployeeID, New SelectList(ViewBag.Employees), "SELECT AN EMPLOYEE", htmlAttributes:=New With {.Class = "form-control center-block", .style = "color:#000000;"})
                @Html.ValidationMessageFor(Function(model) model.End_Time, "", New With {.class = "text-danger"})
            </div>
        </div>      
   

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>  End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
