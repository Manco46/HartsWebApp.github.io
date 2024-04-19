@ModelType IEnumerable(Of HartsWebApp.Appointment)
@Code
    ViewData("Title") = "Index"
    Dim db As New ApplicationDbContext
End Code


<div class="container">
    <div class="row">
        @For Each item In Model

            @<div class="col-sm-4">
                <h3>@item.AppoDate</h3>
                <h3>@item.Start_Time - @item.End_Time</h3>
                <h2>@item.Status</h2>
                <span class="label label-info" data-toggle="modal" data-target="#popupInfoItem">more information</span>

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

                    <a href="https://pay.ikhokha.com/harts-beauty/buy/hartspayments" target="_blank" style="text-decoration: none">
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

                <p class="alert alert-warning">
                    Confirm that the payment was made successfully using the iKhokha Payment processor, so that the admin can approve your appointment and reference you to a stylist.
                </p>
                @Ajax.ActionLink("Confirm Payment Was Made", "", "", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "", .InsertionMode = InsertionMode.Replace, .OnSuccess = ""}, htmlAttributes:=New With {.class = "btn btn-primary"})
                <hr />
                @Ajax.ActionLink("Cancel Appointment", "", "", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "", .InsertionMode = InsertionMode.Replace, .OnSuccess = ""}, htmlAttributes:=New With {.class = "btn btn-primary"})

            </div>
        Next
    </div>
</div>