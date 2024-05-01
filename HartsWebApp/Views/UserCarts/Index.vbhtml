@ModelType IEnumerable(Of HartsWebApp.Service)
@Code

    ViewData("Title") = "My Cart"

End Code

<div class="container">
    <div Class="">

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        CART ITEMS
                    </h3>
                </div>
                <div class="panel-body">
                    <ul class="list-group">
                        @For Each item In Model
                            @<li Class="list-group-item" id="@item.ID">
                                @item.Type - @item.Category - R @item.Fee
                                <span class="label label-info" data-toggle="modal" data-target="#popupInfoItem">more information</span>
                                  @Html.ActionLink(" ", "Delete", "UserCarts", New With {.id = item.ID}, New With {.class = "glyphicon glyphicon-trash"})
                                <!--/*<span Class="glyphicon glyphicon-trash"></span>*/-->
                                <div class="modal fade" id="popupInfoItem" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                              
                                                <button type="button" class="close glyphicon glyphicon-remove" data-dismiss="modal"></button>
                                                <h4 class="modal-title">@item.Type - @item.Category - R @item.Fee</h4>
                                            </div>
                                            <div class="modal-body">
                                                <img src="@item.Picture" alt="@item.Type" />
                                                <p>@item.Description</p>
                                                <h5>@item.Duration (minutes)</h5>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default btn-block">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        Next
                    </ul>
                </div>
                <div class="panel-footer">Total Amount: <h6 id="appointmentTotalFee">@ViewBag.TotalAmount</h6> ZAR/RANDS</div>
            </div>
        </div>

        <hr />
        <div>
            <h3>APPOINTMENT SCHEDULING</h3>
            <div id="testPay">


            </div>
            <div class="form-group">
                <div class="col-md-10">
                    <input id="appointmentDate" class="form-control" type="date" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    @Html.DropDownList("timeRequired", New SelectList(ViewBag.TimesRequired), "Prefered Time of Appointment", New With {.class = "form-control"})
                </div>
            </div>
        </div>
        <hr />        
        <a id="btnCheckout"class="btn btn-primary btn-block">CHECKOUT</a>           
        
    </div>
</div>

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



