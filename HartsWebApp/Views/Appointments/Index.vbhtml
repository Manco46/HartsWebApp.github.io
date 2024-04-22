@ModelType IEnumerable(Of HartsWebApp.Appointment)
@Code
    ViewData("Title") = "Index"
    Dim db As New ApplicationDbContext




End Code


<table class="container">
    
    <tr>

        <th>
            @Html.DisplayName("APPOINTMENT DETAILS")
        </th>
        <th>
            @Html.DisplayName("Service Details")
        </th>
        <th>
            @Html.DisplayName("")
        </th>
        <th>
            @Html.DisplayName("")
        </th>

    </tr>

    @For Each item In Model

        @<tr class="row">
             <p class="alert alert-warning">
                Confirm that the payment was made successfully using the iKhokha Payment processor, so that the admin can approve your appointment and reference you to a stylist.
            </p>

             <td>
                 <h3>@item.AppoDate</h3>
                 <h3>@item.Start_Time - @item.End_Time</h3>
                 <h2>@item.Status</h2>                
             </td>

             <td>
                 <div id="employeeDetails"></div>              
                 <h2>Total Amount For Services: @item.Fee ZAR/RANDS</h2>
                 <span class="label label-info" data-toggle="modal" data-target="#popupInfoItem">more information</span>
             </td>

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

           
            @Ajax.ActionLink("Confirm Payment Was Made", "", "", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "", .InsertionMode = InsertionMode.Replace, .OnSuccess = ""}, htmlAttributes:=New With {.class = "btn btn-primary"})
            <hr />
            @Ajax.ActionLink("Cancel Appointment", "", "", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "", .InsertionMode = InsertionMode.Replace, .OnSuccess = ""}, htmlAttributes:=New With {.class = "btn btn-primary"})

        </tr>
    Next
    
</table>

<script>

    $.ajax({
            url: "@Url.Action("Appointments", "GetEmployeeDetails")",
           Type:   "GET",
            dataType: "json",
            success: function (totalItemsAppointment) {
                $("#employeeDetails").empty();
                $("#employeeDetails").append(totalItemsAppointment);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#employeeDetails").empty();
                $("#employeeDetails").append("Error Type: " + jqXHR.status + " Status: " + jqXHR.statusText + " Response: " + jqXHR.responseText);
            }
        });

    });
</script>