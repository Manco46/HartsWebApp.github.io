@ModelType IEnumerable(Of HartsWebApp.Service)

<div class="row">
    @For Each item In Model
        @<div class="col-md-4">
            <input type="radio" class="btn-check" name="HairServiceID" value="@item.ID" id="HairServiceID" autocomplete="off" />
            <div class="thumbnail" for="HairServiceID">
                <img class="img-responsive img-rounded" src="" alt="@item.Type - image not available" />
                <div class="caption">
                    <h3>@item.Type</h3>
                    <h5>@item.Category</h5>
                    <p>@item.Description</p>
                    <h4>R @item.Fee</h4>
                    <button class="btnAddCart btn btn-primary btn-block" onclick="getValue(@item.ID)">ADD TO CART</button>
                </div>
            </div>
        </div>
    Next
</div>

<script>
   
    function getValue(itemID) {
        $(".btnAddCart").prop("disabled", true);        
        $.ajax({
            url: "https://localhost:44393/UserCarts/AddToCart",
            type: "POST",
            data: { VALUE: itemID },
            dataType: "json",
            success: function (data) {
                $("#noItemsOfCart").empty();
                $("#noItemsOfCart").append(data);
                $(".btnAddCart").prop("disabled", false);                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#serviceBoxContainer").empty();
                $("#serviceBoxContainer").append("Error Type: " + jqXHR + " Status: " + textStatus + " Exception: " + errorThrown);
            }
        });
    }
   
</script>