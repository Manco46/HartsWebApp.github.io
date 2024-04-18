@ModelType IEnumerable(Of HartsWebApp.Service)
@Code

    ViewData("Title") = "Harts Cart"

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
                                <span Class="glyphicon glyphicon-trash"></span>
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
                <div class="panel-footer">
                    @ViewBag.TotalAmount
                </div>
            </div>
        </div>

        <hr />
        <div>
            <h3>APPOINTMENT SCHEDULING</h3>

            <div class="form-group">
                <div class="col-md-10">
                    <input class="form-control" type="date" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-10">
                    @Html.DropDownList("timeRequired", New SelectList(ViewBag.TimesRequired), "Prefered Time of Appointment", New With {.class = "form-control"})
                </div>
            </div>
        </div>
        <hr />
        <div>
            @Ajax.ActionLink("CHECKOUT", "AddService", "UserCarts", New With {.serviceID = ""}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "troubleshoot", .InsertionMode = InsertionMode.Replace, .OnSuccess = "hideSelectedItem('" + "" + "')"}, htmlAttributes:=New With {.class = "btn btn-primary btn-block"})

        </div>
    </div>
</div>

<div id="testPay">
    

</div>
<div style="width: 225px">
    <h6 style="
	  margin: 10px 0;
	  padding: 0;
	  font-family: roboto-regular, sans-serif;
	  font-size: 14px;
	  color: #1d1d1b;
	">
        Harts Payments
    </h6>

    <a href="https://pay.ikhokha.com/harts-beauty/buy/hartspayments" style="text-decoration: none">
        <div style="
			overflow: hidden;
			display: flex;
			justify-content: center;
			align-items: center;
			width: 100%;
			height: 48px;
			background: #0BB3BF;
			color: #FFFFFF;
			border: 1px solid #e5e5e5;
			box-shadow: 1px solid #e5e5e5;
			border-radius: 16px;
			font-family: roboto-medium, sans-serif;
			font-weight: 700;
		  ">
            Buy Now
        </div>
    </a>
    <h6 style="
		margin: 5px 0;
		padding: 0;
		font-size: 8px;
		font-family: roboto-regular, sans-serif;
		text-align: center;
	  ">
        Powered by iKhokha
    </h6>
</div>
