@ModelType IEnumerable(Of HartsWebApp.ApplicationUser)

<p>
    @Html.ActionLink("Create New", "Create")
</p>

<div class="list-group">
    <div class="list-group-item-heading">

    </div>

    @For Each item In Model
        @<div class="list-group-item">
          
            <div class="form-group">
                 @Html.DisplayNameFor(Function(model) model.FirstName):
                <div class="">
                    @Html.DisplayFor(Function(modelItem) item.FirstName)
                </div>                
            </div>

            <div class="form-group">
                @Html.DisplayNameFor(Function(model) model.Surname):
                <div class="">
                    @Html.DisplayFor(Function(modelItem) item.Surname)
                </div>
            </div>
            <div class="form-group">
                 @Html.DisplayNameFor(Function(model) model.Email):
                <div class="">
                    @Html.DisplayFor(Function(modelItem) item.Email)
                </div>                
            </div>
            <div class="form-group">
                 @Html.DisplayNameFor(Function(model) model.PhoneNumber):
                <div class="">
                    @Html.DisplayFor(Function(modelItem) item.PhoneNumber)
                </div>                
            </div>         
           
            <div>
                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
            </div>
        </div>
         @<br />
    Next

</div>