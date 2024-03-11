@ModelType IEnumerable(Of HartsWebApp.Service)

<ul class="list-group">
    @For Each item In Model
        @<li class="list-group-item">
            @Html.ActionLink(" ", "Delete", "UserCarts", New With {.id = item.ID}, New With {.class = "w3-bar-item w3-button w3-white w3-xlarge w3-right fa fa-trash"})
            <input class="w3-radio w3-bar-item w3-xlarge" type="radio" value="@item.ID" name="serviceGroup @item.Category" />
            <img src="@item.Picture" alt="@item.Type" class="w3-bar-item w3-round w3-hide-small" style="width:85px" />
            <div class="w3-bar-item">
                <span class="w3-large">@item.Type</span><br />
                <span class="">@item.Category</span><br />
                <span class="w3-large">R @item.Fee</span>
            </div>
        </li>
    Next
</ul>