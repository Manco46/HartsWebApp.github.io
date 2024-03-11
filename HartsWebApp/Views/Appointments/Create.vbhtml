@ModelType HartsWebApp.Appointment
@Code
    ViewData("Title") = "Create"
End Code



<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Appointment</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        
     <div id="ServicesSection">

         @Ajax.ActionLink("HAIR LOUNGE", "HairSection", "Appointments", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "HairServices", .InsertionMode = InsertionMode.Replace}, htmlAttributes:={})
         <div id="HairServices" class="form-group">
         </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Is_Dye, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 <div class="checkbox">
                     @Html.EditorFor(Function(model) model.Is_Dye)
                     @Html.ValidationMessageFor(Function(model) model.Is_Dye, "", New With {.class = "text-danger"})
                 </div>
             </div>
         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.Colour, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.Colour, New With {.htmlAttributes = New With {.class = "form-control"}})
                 @Html.ValidationMessageFor(Function(model) model.Colour, "", New With {.class = "text-danger"})
             </div>
         </div>

         @Ajax.ActionLink("NAILS", "HairSection", "Appointments", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "HairServices", .InsertionMode = InsertionMode.Replace}, htmlAttributes:={})
         <div id="HairServices" class="form-group">
         </div>

         @Ajax.ActionLink("MAKE LOUNGE", "HairSection", "Appointments", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "HairServices", .InsertionMode = InsertionMode.Replace}, htmlAttributes:={})
         <div id="HairServices" class="form-group">
         </div>



     </div>
        

        <div id="ScheduleSection">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.AppoDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.AppoDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.AppoDate, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.PreferedTimeOfDay, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.PreferedTimeOfDay, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.PreferedTimeOfDay, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Start_Time, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Start_Time, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Start_Time, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>





        <div id="ResultSection">
            <div class="form-group">
                @Html.LabelFor(Function(model) model.End_Time, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.End_Time, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.End_Time, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Fee, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Fee, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Fee, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>



        <div>
            <div class="form-group">
                @Html.LabelFor(Function(model) model.Employee_ID, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Employee_ID, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Employee_ID, "", New With {.class = "text-danger"})
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(Function(model) model.Status, htmlAttributes:=New With {.class = "control-label col-md-2"})
                <div class="col-md-10">
                    @Html.EditorFor(Function(model) model.Status, New With {.htmlAttributes = New With {.class = "form-control"}})
                    @Html.ValidationMessageFor(Function(model) model.Status, "", New With {.class = "text-danger"})
                </div>
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

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
