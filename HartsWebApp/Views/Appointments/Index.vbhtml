@ModelType IEnumerable(Of HartsWebApp.Appointment)
@Code
    ViewData("Title") = "Index"
    Dim db As New ApplicationDbContext
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
@For Each item In Model

    @<div class="panel-group panel-success">
        <div class="panel-heading">
            <div class="panel-title">
                <h3>@Html.DisplayFor(Function(modelItem) item.AppoDate)</h3>
                <h3>@Html.DisplayFor(Function(modelItem) item.PreferedTimeOfDay)</h3>
                <h3>@Html.DisplayFor(Function(modelItem) item.Start_Time)</h3>
                <h3>@Html.DisplayFor(Function(modelItem) item.End_Time)</h3>

            </div>
        </div>
        <div class="panel-body">
            <div>
                @Html.Partial("_AppointmentServiceView", db.Services.Find(item.HairServiceID))
                @Html.Partial("_AppointmentServiceView", db.Services.Find(item.HairServiceAddOnID))
            </div>
            <div>
                @Html.Partial("_AppointmentServiceView", db.Services.Find(item.NailsServiceID))
                @Html.Partial("_AppointmentServiceView", db.Services.Find(item.NailsServiceAddOnID))
            </div>
            <div>
                @Html.Partial("_AppointmentServiceView", db.Services.Find(item.MakeUpServiceID))
                @Html.Partial("_AppointmentServiceView", db.Services.Find(item.MakeUpServiceAddOnID))
            </div>
        </div>

        <div class="panel-footer">

            <h3>Total Fee: R @Html.DisplayFor(Function(modelItem) item.Fee)</h3>
            <h3>@Html.DisplayFor(Function(modelItem) item.Employee_ID)</h3>
            <h3>@Html.DisplayFor(Function(modelItem) item.Status)</h3>
        </div>

    </div>
Next