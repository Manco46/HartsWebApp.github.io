@ModelType IEnumerable(Of HartsWebApp.Service)

<div>
    @Html.DropDownList("genderFilter", New SelectList(ViewBag.lstGender), "SELECT A GENDER")
    @Html.DropDownList("catergory", New SelectList(ViewBag.lstCategory), "SELECT A CATEGORY")
    <a id="btnFilter" class="btn btn-primary">FILTER</a>
 </div>

<div id="serviceBoxContainer" class="container">
    <div class="row">
        @For Each item In Model
            @<div class="col-md-4">
                <input type="radio" class="btn-check" name="HairServiceID" value="@item.ID" id="HairServiceID" autocomplete="off" />
                <div class="thumbnail" for="HairServiceID">
                    <img class="img-responsive img-rounded" src="~/Content/IMG_20210529_155710.jpg" alt="@item.Type - image not available" />
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
</div>

<script>
    $(function () {
        $("#btnFilter").click(function () {
            $("#btnFilter").prop("disabled", true);
            var genderFilter = $("#genderFilter").val();
            var catergory = $("#catergory").val();

            $.ajax({

                url: "https://localhost:44393/Appointments/filterHairSection",
                type: "GET",
                data: { genderFilter: genderFilter, catergory: catergory },
                dataType: "html",
                success: function (filteredResults) {
                    $("#serviceBoxContainer").empty();
                    $("#serviceBoxContainer").append(filteredResults);
                    $("#btnFilter").prop("disabled", false);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    $("#serviceBoxContainer").empty();
                    $("#serviceBoxContainer").append("Error Type: " + jqXHR + " Status: " + textStatus + " Exception: " + errorThrown);
                }
            });
        });
    });       
</script>
