@ModelType IEnumerable(Of HartsWebApp.Service)
@Code
    ViewData("Title") = "Products & Services"
    Dim parGender As String = ""
    Dim parCatergory As String = ""
End Code
<br />

@If User.IsInRole("ADMIN") Then
    @Ajax.ActionLink("Create A New Service", "Create", "Services", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "glyphicon glyphicon-pencil"})

End If

<div>
    @Html.DropDownList("genderFilter", New SelectList(ViewBag.lstGender), "SELECT A GENDER")
    @Html.DropDownList("catergory", New SelectList(ViewBag.lstCategory), "SELECT A CATEGORY")
    <br />
    <a id="btnFilter" class="btn btn-primary">FILTER</a>
  
</div>

<div class="">@ViewBag.ErrorMessage </div>

<div id="serviceBoxContainer" class="row">
    @For Each item In Model
        @<div class="col-md-4">
            <div class="thumbnail" for="ServiceID-@item.SectionID">
               
                <img class="img-responsive img-rounded" src="" alt="@item.Type - image not available" />
                <div class="caption">
                    <h3>@item.Type</h3>
                    <h5>@item.Category</h5>
                    <p>@item.Description</p>
                    <h4>R @item.Fee</h4>
                    @If User.IsInRole("ADMIN") Then
                        @Ajax.ActionLink("Edit", "Edit", "Services", New With {.id = item.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "glyphicon glyphicon-edit"})@<br />
                        @Ajax.ActionLink("Delete", "Delete", "Services", New With {.id = item.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "glyphicon glyphicon-trash"})
                    End If
                    @Html.ActionLink("ADD TO CART", "AddToCart", "UserCarts", New With {.VALUE = item.ID, .sectionID = item.SectionID}, htmlAttributes:=New With {.class = "btnAddCart btn btn-primary btn-block"})

                </div>
            </div>
        </div>
    Next
</div>

<script>
    $(function () {
        $("#btnFilter").click(function () {
            $("#btnFilter").prop("disabled", true);
            var genderFilter = $("#genderFilter").val();
            var catergory = $("#catergory").val();
           

           $.ajax({

                url: "@Url.Action("Index", "Services")",
                type: "GET",
                data: { sectionID: "", errorMessage: "",genderFilter: genderFilter, catergory: catergory },
                dataType: "html",
                success: function (filteredResults) {
                    $("#realBody").empty();
                    $("#realBody").append(filteredResults);
                    $("#realBody").prop("disabled", false);
                },
                error: function (jqXHR) {
                    $("#realBody").empty();
                    $("#realBody").append("Error Type: " + jqXHR.error + " Status: " + jqXHR.textStatus + " Exception: " + jqXHR.errorThrown);
                }
            });
        });
    });
</script>

