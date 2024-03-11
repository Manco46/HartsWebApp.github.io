@Imports System.Collections.Generic
@Imports Microsoft.AspNet.Identity.EntityFramework
@Modeltype IEnumerable(Of IdentityRole)

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>

@If Model.Count = 0 Then

    @<h3>No Roles Found</h3> 

Else

    @<Table Class="table">
        <tr>
            <th>
                @Html.DisplayName("Role ID")
            </th>
            <th>
                @Html.DisplayName("Role Name")
            </th>
    
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Id)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Name)
                </td>

                <td>
                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |   
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                </td>
            </tr>
        Next

    </table>
End If

