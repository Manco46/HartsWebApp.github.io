@ModelType IEnumerable(Of HartsWebApp.ServiceSection)
@Code
    ViewData("Title") = "Service Sections"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.SectionName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.SectionDescription)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SectionName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SectionDescription)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
