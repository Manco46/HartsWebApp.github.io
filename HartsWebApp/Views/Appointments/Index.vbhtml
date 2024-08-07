﻿@ModelType IEnumerable(Of HartsWebApp.Appointment)
@Code
    ViewData("Title") = "Appointments"
    Dim db As New ApplicationDbContext
End Code


<div>
    @If User.IsInRole("CLIENT") Then
        @<p Class="alert alert-warning">
            Confirm that the payment was made successfully Using the iKhokha Payment processor, so that the admin can approve your appointment And reference you To a stylist.
        </p>
    End If
</div>
<br />
<div class="">
    
    @Html.TextBox("inputAppointmentDate", "", htmlAttributes:=New With {.Class = "form-control center-block", .type = "date"})
    <br />
    @Html.TextBox("inputAppointmentStartTime", "", htmlAttributes:=New With {.Class = "form-control center-block", .type = "time"})
    <br />
    <a id="btnAppoFilter" class="btn btn-primary center-block">FILTER</a>
</div>


<div class="list-group">
    <div class="list-group-item-heading">
        <h2>APPOINTMENTS DETAILS</h2>
    </div>

    @For Each item In Model
        @<div class="list-group-item">
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ID})


            <h3>@item.AppoDate.ToLongDateString</h3>
            <h3>@item.Start_Time - @item.End_Time</h3>

            <h4 class="alert alert-warning">Status: @item.Status</h4>
            <div id="employeeDetails"></div>

            <h5><span class="label label-success" data-toggle="modal" data-target="#popupInfoItem">more information</span></h5>

            <hr />

            <h4 class="alert-info">Payment Reference: @item.ID <br /> Total Amount: @item.Fee ZAR/RANDS</h4>


            @If Not item.Status = "Payment confirmation, pending..." Then
                @<div style="width: 225px">
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
                @<hr />
                @Html.ActionLink("Confirm Payment Was Made", "ConfirmPayment", "Appointments", New With {.appointmentID = item.ID}, htmlAttributes:=New With {.Class = "btn btn-success btn-block"})

            End If

            @Ajax.ActionLink("Cancel Appointment", "", "", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "", .InsertionMode = InsertionMode.Replace, .OnSuccess = ""}, htmlAttributes:=New With {.class = "btn btn-danger btn-block"})

        </div>
        @<br />
    Next
</div>

<script>

   /* $.ajax({
        url: "Url.Action("Appointments", "GetEmployeeDetails")",
        type:   "GET",
        dataType: "json",
        success: function (totalItemsAppointment) {
            $("#employeeDetails").empty();
            $("#employeeDetails").append(totalItemsAppointment);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            $("#employeeDetails").empty();
            $("#employeeDetails").append("Error Type: " + jqXHR.status + " Status: " + jqXHR.statusText + " Response: " + jqXHR.responseText);
        }        
    });*/


    $("#btnAppoFilter").click(function () {
        $("#btnAppoFilter").prop("disabled", true);
            var dateFilter = $("#inputAppointmentDate").val();
            var startTimeFilter = $("#inputAppointmentStartTime").val();


           $.ajax({

                url: "@Url.Action("Index", "Appointments")",
                type: "GET",
                data: { appointmentDate:dateFilter, appointmentDate:startTimeFilter },
                dataType: "html",
                success: function (filteredResults) {
                    $("#realBody").empty();
                    $("#realBody").append(filteredResults);
                    $("#btnAppoFilter").prop("disabled", false);
                },
                error: function (jqXHR) {
                    $("#realBody").empty();
                    $("#realBody").append("Error Type: " + jqXHR.error + " Status: " + jqXHR.textStatus + " Exception: " + jqXHR.errorThrown);
                }
            });
        });
</script>