@ModelType IEnumerable(Of HartsWebApp.Service)
<h1 id="troubleshoot">@ViewBag.serviceIDs</h1>
<div class="row">
    @For Each item In Model
        @<div class="col-md-4">
             <div class="thumbnail" for="ServiceID-@item.SectionID">
                 <input type="radio" class="btn-check-@item.SectionID" name="ServiceID-@item.SectionID" value="@item.ID" id="ServiceID-@item.SectionID" autocomplete="off" onclick="" />
                 @Ajax.ActionLink(" ", "Delete", "Services", New With {.id = item.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "glyphicon glyphicon-remove"})
                 <img class="img-responsive img-thumbnail" src="" alt="@item.Type - image not available" style="width:100%;" />
                 <div class="caption">
                     <h3>@item.Type</h3>
                     <h5>@item.Category</h5>
                     <p>@item.Description</p>
                     <h4>R @item.Fee</h4>
                 </div>
                 @Ajax.ActionLink("Add To Check 1", "AddService", "UserCarts", New With {.serviceID = item.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "troubleshoot", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "btn btn-block"})

                 <button onclick="callAddService()" id="btnAdd-@item.ID" class="btn btn-block">Add To Check</button>
             </div>
        </div>
        @<script>

           

            function callAddService() {

                $.ajax({

                    url: '@Url.Action("AddService", "UserCarts", "")',
                    type: "GET",
                    data: { serviceID: @item.ID },
                    success: function (data) {
                        $("#applicationBodyContainer").empty();
                        $("#applicationBodyContainer").append(data);
                    }



                };
                });




      

        </script>
    Next
</div>


