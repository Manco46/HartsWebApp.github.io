@Code

    Dim db As New ApplicationDbContext
    Dim items = db.ServiceSections.ToList
End Code
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - HARTS BEAUTY SALON</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    -->

    <script src="~/Scripts/jquery-3.4.1.js"></script>
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>

    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://w3schools.com/w3css/4/w3.css">
    <script src="https://w3schools.com/lib/w3.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <script src="~/Scripts/jquery.form.js"></script>
    <script src="~/Scripts/jquery.form.min.js"></script>

    <script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>
    <script src="~/Scripts/jquery.unobtrusive-ajax.min.js"></script>

</head>
<body id="realBody">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#collapseNav">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("HARTS SALON", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                <!--If User.Identity.IsAuthenticated Then
                        <div id="CartAccessLink">
                            Ajax.ActionLink("CART", "Index", "UserCarts", "", New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "applicationBodyContainer", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "nav navbar-nav"})<h4 style="color:white;"> @Ajax.ViewBag.TotalCartItems</h4>
                        </div>
                End If-->

            </div>
            <div id="collapseNav" class="collapse navbar-collapse">
                <ul class="nav navbar-nav">

                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown">
                            Our Service
                            <span class="caret"></span>
                        </a>
                        <ul class="dropdown-menu">
                            @for Each i In items
                                @<li>
                                    @Ajax.ActionLink(i.SectionName, "Index", "Services", New With {.sectionID = i.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "realBody", .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "w3-bar-item w3-button"})
                                </li>
                            Next
                        </ul>
                    </li>
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                    <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">

        <div id="applicationBodyContainer">
            @RenderBody()
        </div>
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Harts Beauty Services</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)

    

</body>



</html>
