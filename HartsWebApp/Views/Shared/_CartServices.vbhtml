@ModelType IEnumerable(Of HartsWebApp.Service)



<h1 id="troubleshoot">@ViewBag.serviceIDs</h1>
<div class="row">
    @For Each item In Model
        @<div class="col-md-4" id="@item.ID">
            <div class="thumbnail" for="ServiceID-@item.SectionID">
                @Ajax.ActionLink(" Remove", "DeleteConfirmed", "Usercarts", New With {.id = item.ID}, New AjaxOptions With {.HttpMethod = "POST", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "glyphicon glyphicon-remove"})
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

<script>
    function hideSelectedItem(itemID) {
        alert(itemID);
        $("#" + itemID).hide();
    }

</script>