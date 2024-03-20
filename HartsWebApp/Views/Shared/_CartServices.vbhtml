@ModelType IEnumerable(Of HartsWebApp.Service)

<div class="row">
    @For Each item In Model
        @<div class="col-md-4">
             <div class="thumbnail" for="ServiceID-@item.SectionID">
                 <input type="radio" class="btn-check" name="ServiceID-@item.SectionID" value="@item.ID" id="ServiceID-@item.SectionID" autocomplete="off" />
                 @Ajax.ActionLink(" ", "Delete", "Services", New With {.id = item.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "glyphicon glyphicon-remove"})
                 <img class="img-responsive img-thumbnail" src="" alt="@item.Type - image not available" style="width:100%;" />
                 <div class="caption">
                     <h3>@item.Type</h3>
                     <h5>@item.Category</h5>
                     <p>@item.Description</p>
                     <h4>R @item.Fee</h4>
                 </div>
             </div>
        </div>
    Next
</div>
