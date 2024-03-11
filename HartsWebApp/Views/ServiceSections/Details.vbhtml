@ModelType HartsWebApp.ServiceSection
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>ServiceSection</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.SectionName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SectionName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SectionDescription)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SectionDescription)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
