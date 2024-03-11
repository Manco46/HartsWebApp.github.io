@ModelType HartsWebApp.Service
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Service</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Section)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Section)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sexuality)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sexuality)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Category)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Category)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Type)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Type)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Duration)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Duration)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fee)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fee)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Picture)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Picture)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
