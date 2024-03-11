@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="nav navbar-nav navbar-right">

            <li id="btnCartLink">
                <a href="@Url.Action("Index", "UserCarts")">
                    <span class="glyphicon glyphicon-shopping-cart"></span>
                    Shopping Cart
                    <span id="noItemsOfCart" class="badge"></span>
                </a>             
            </li>
            <li>
                <a href="@Url.Action("Index", "Manage", routeValues:=Nothing)" title="Manage">
                    Settings
                    <span class="glyphicon glyphicon-cog"></span>
                </a>
            </li>
            <li> 
                <a href="javascript:document.getElementById('logoutForm').submit()">
                    Sign Out
                    <span class="glyphicon glyphicon glyphicon-log-out"></span>
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
            success: function (totalItems) {
                $("#noItemsOfCart").empty();
                $("#noItemsOfCart").append(totalItems);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#noItemsOfCart").empty();
                $("#noItemsOfCart").append("Error Type: " + jqXHR + " Status: " + textStatus + " Exception: " + errorThrown);
            }
        });
    });
</script>