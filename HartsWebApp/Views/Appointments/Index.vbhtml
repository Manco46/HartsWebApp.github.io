@ModelType IEnumerable(Of HartsWebApp.Appointment)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.myUser.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.HairServiceID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.HairServiceAddOnID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Is_Dye)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Colour)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NailsServiceID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NailsServiceAddOnID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MakeUpServiceID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MakeUpServiceAddOnID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AppoDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PreferedTimeOfDay)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Start_Time)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.End_Time)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fee)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Employee_ID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Status)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.myUser.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.HairServiceID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.HairServiceAddOnID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Is_Dye)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Colour)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NailsServiceID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NailsServiceAddOnID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MakeUpServiceID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MakeUpServiceAddOnID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AppoDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PreferedTimeOfDay)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Start_Time)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.End_Time)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Fee)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Employee_ID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Status)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ID })
        </td>
    </tr>
Next

</table>
