@ModelType HartsWebApp.AppointmentService
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>AppointmentService</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Appointments.UserID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Appointments.UserID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Service.SectionID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Service.SectionID)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
