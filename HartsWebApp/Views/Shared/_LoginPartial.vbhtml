@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="nav navbar-nav navbar-right">

             <li id="btnCart">
                 <a href="@Url.Action("Index", "UserCarts")">
                     <span class="glyphicon glyphicon-shopping-cart"></span>
                     Shopping Cart
                     <span id="noItemsOfCart" class="badge"></span>
                 </a>
             </li>

             <li id="btnCart">
                 <a href="@Url.Action("Index", "Appointments")">
                     <span class="glyphicon glyphicon-calendar"></span>
                     Appointments
                     <span id="noItemsOfAppointment" class="badge"></span>
                 </a>
             </li>

            @If User.IsInRole("ADMIN") Then
                @<li>
                    <a href="@Url.Action("Index", "Services")">Services</a>
                </li>

                @<li>
                    <a href="@Url.Action("Index", "ServiceSections")">Service Sections</a>
                </li>
                 @<li>
                    <a href="@Url.Action("Index", "Account")">Employees</a>
                </li>
                @<li>
                    <a href="@Url.Action("Index", "Role")">Roles</a>
                </li>
            End If    

            <li>
                <a href="@Url.Action("Index", "Manage", routeValues:=Nothing)" title="Manage">
                    Settings
                    <span Class="glyphicon glyphicon-cog"></span>
                </a>
            </li>
            <li>
                <a href="javascript:document.getElementById('logoutForm').submit()">
                    Sign Out
                    <span Class="glyphicon glyphicon glyphicon-log-out"></span>
                </a>
            </li>
        </ul>
    End Using
Else
    @<ul class="nav navbar-nav navbar-right">
        <li>
            <a href="@Url.Action("Register", "Account", routeValues:=Nothing)">
                Sign Up
                <span class="glyphicon glyphicon-list-alt"></span>
            </a>
        </li>
        <li>
            <a href="@Url.Action("Login", "Account", routeValues:=Nothing)">
                Sign In
                <span class="glyphicon glyphicon-log-in"></span>
            </a>

        </li>
    </ul>
End If

<script>
    $(document).ready(function () {
        $.ajax({
            url: "https://localhost:44393/UserCarts/CountItemsOnCart",
            type: "GET",
            dataType: "json",
            success: function (totalItemsCart) {
                $("#noItemsOfCart").empty();
                $("#noItemsOfCart").append(totalItemsCart);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#noItemsOfCart").empty();
                $("#noItemsOfCart").append("Error Type: " + jqXHR.status + " Status: " + jqXHR.statusText + " Response: " + jqXHR.responseText);
            }
        });

        $.ajax({
            url: "https://localhost:44393/Appointments/CountItemsOnCart",
            type: "GET",
            dataType: "json",
            success: function (totalItemsAppointment) {
                $("#noItemsOfAppointment").empty();
                $("#noItemsOfAppointment").append(totalItemsAppointment);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#noItemsOfAppointment").empty();
                $("#noItemsOfAppointment").append("Error Type: " + jqXHR.status + " Status: " + jqXHR.statusText + " Response: " + jqXHR.responseText);
            }
        });

    });
</script>