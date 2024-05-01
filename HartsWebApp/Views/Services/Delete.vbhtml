@ModelType HartsWebApp.Service
@Code
    ViewData("Title") = "Delete"
    Dim db As ApplicationDbContext
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Service</h4>
    <hr />
    <dl class="dl-horizontal">
       
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
