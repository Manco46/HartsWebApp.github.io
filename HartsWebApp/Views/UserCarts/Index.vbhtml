@ModelType IEnumerable(Of HartsWebApp.Service)
@Code

    ViewData("Title") = "My Cart"

End Code

<br />
<div class="container">
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading" style="background-color:#469372; color:#ffffff;">
                <h3 class="panel-title text-center">
                    CART ITEMS
                </h3>
            </div>
            <div class="panel-body">               
                <ul Class="list-group">                    
                    @For Each item In Model
                        @<li Class="list-group-item text-center" id="@item.ID" style="color:#469372;">
                            @item.Type - @item.Category - R @item.Fee
                            <span class="label label-info" data-toggle="modal" data-target="#popupInfoItem_@item.ID">more information</span>
                            @Html.ActionLink(" ", "Delete", "UserCarts", New With {.id = item.ID}, New With {.class = "glyphicon glyphicon-trash"})
                            <!--/*<span Class="glyphicon glyphicon-trash"></span>*/-->
                            <div class="modal" role="dialog" id="popupInfoItem_@item.ID">
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content" style="color:#000000;">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h3 class="modal-title">@item.Type - @item.Category - R @item.Fee</h3>
                                        </div>
                                        <div class="modal-body">
                                            <img src="@item.Picture" alt="@item.Type - image not available" style="width:400px;height:250px;" />
                                            <h4><p>@item.Description</p></h4>
                                            <h3>@item.Duration (minutes)</h3>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default btn-block" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </li>
                    Next
                </ul>
            </div>
            <div class="panel-footer" style="background-color:#469372; color:#ffffff;">
                <h3 id="appointmentTotalFee" class="text-center">Total Amount: @ViewBag.TotalAmount ZAR/RANDS</h3>
            </div>
        </div>
    </div>

    <hr />
    <div>
        <h3 style="color:#469372;">APPOINTMENT SCHEDULING</h3>
        <div id="testPay">


        </div>
        <div class="form-group" style="color:#469372;">
            <div class="col-md-10">
                <input style="color:#469372;" id="appointmentDate" class="form-control center-block" type="date" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                @Html.DropDownList("timeRequired", New SelectList(ViewBag.TimesRequired), "Prefered Time of Appointment", New With {.class = "form-control center-block", .style = "color:#469372;"})
            </div>
        </div>
    </div>
</div>
<hr />
<a id="btnCheckout" class="btn btn-block" style="background-color:#469372; color:#ffffff;">CHECKOUT</a>

<div id="testPay">


</div>

<script>
    $(function () {
        $("#btnCheckout").click(function () {
            $("#btnCheckout").prop("disabled", true);
            var appoDate = $("#appointmentDate").val();
            var appoTime = $("#timeRequired").val();
            var totalFee = $("#appointmentTotalFee").val();

            $.ajax({

                url: "@Url.Action("Create", "Appointments")",
                type: "POST",
                data: { appointmentDate: appoDate, appointmentPreferedTime: appoTime, appointmentFee : totalFee },
                dataType: "json",
                success: function (appoResults) {
                    $("#testPay").empty();
                    $("#testPay").append(appoResults);
                    $("#btnCheckout").prop("enabled", true);
                    var url = "@Url.Action("Index", "Appointments")";
                    // Redirect to the specified URL
                    window.location.href = url;
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    $("#testPay").empty();
                    $("#testPay").append("Error Type: " + jqXHR.status + " Status: " + jqXHR.statusText + " Response text: " + jqXHR.responseText);
                    $("#btnCheckout").prop("enabled", true);
                }
            });
        });
    });
</script>



