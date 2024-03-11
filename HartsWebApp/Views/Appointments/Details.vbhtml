@ModelType HartsWebApp.Appointment
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Appointment</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.myUser.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.myUser.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.HairServiceID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HairServiceID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.HairServiceAddOnID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.HairServiceAddOnID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Is_Dye)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Is_Dye)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Colour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Colour)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NailsServiceID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NailsServiceID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NailsServiceAddOnID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NailsServiceAddOnID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MakeUpServiceID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MakeUpServiceID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MakeUpServiceAddOnID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MakeUpServiceAddOnID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AppoDate)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AppoDate)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PreferedTimeOfDay)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PreferedTimeOfDay)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Start_Time)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Start_Time)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.End_Time)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.End_Time)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fee)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fee)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Employee_ID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Employee_ID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
