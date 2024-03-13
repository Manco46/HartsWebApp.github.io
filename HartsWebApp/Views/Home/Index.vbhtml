@ModelType IEnumerable(Of HartsWebApp.ServiceSection)
@Code
    Dim counter = 0
    ViewData("Title") = "Home Page"
    Dim db As New ApplicationDbContext
    ''Dim serviceData As IEnumerable(Of Service)
End Code

<!--<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>-->





<div Class="w3-content w3-diplay-container">
    @For Each item In Model
        @<div Class="container">
            <h2> @item.SectionName  </h2>
            <div id="myCarousel-@item.SectionName" Class="carousel slide" data-ride="carousel">
                @Html.Partial("_HomeView", db.Services.Where(Function(s) s.Section = item.SectionName).ToList)
                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel-@item.SectionName" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel-@item.SectionName" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    Next



</div>


<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and gives you full control over markup
            for enjoyable, agile development.
        </p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>
</div>
