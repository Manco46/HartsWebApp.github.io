@ModelType IEnumerable(Of HartsWebApp.AppointmentService)
@Code
    ViewData("Title") = "Application Services"

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Appointments.UserID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Service.SectionID)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Appointments.UserID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Service.SectionID)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
