@ModelType HartsWebApp.UserCart
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>UserCart</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.myUser.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.myUser.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CartID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CartID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.ServiceID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.ServiceID)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
