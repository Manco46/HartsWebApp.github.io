@ModelType IEnumerable(Of HartsWebApp.Service)
@Code
    Dim counter = 0
    ViewData("Title") = "Home Page"
End Code

<!--<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>-->

<div class="container">
    <h2>Panel Group</h2>
    <div class="panel-group">
        <div class="panel panel-success">
            <div class="panel-heading">Panel Header</div>
            <div class="panel-body">Panel Content</div>

        </div>
    </div>
</div>



<div id="carousel-container" class="carousel slide" data-ride="carousel">

    <div class="carousel-inner"></div>
    <a class="carousel-control-prev" href="#carousel-container" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="carousel-control-next" href="#carousel-container" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>

</div>
<script>
    $(document).ready(function () {

         $.ajax({
            url: '@Url.Action("MenCarouselData", "Home")',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var $carsouselInner = $('.carousel-inner');

                $.each(data, function (index, item) {

                    var carouselItem = '<div class="carousel-item">' +
                        '<div Class="col-md-4" style="border:1px solid grey; background-color:darkslategray; color:white;" >' +
                        '<img id="' + item.Picture + '" src="' + item.Picture + '" alt="' + item.Type + '" width="120" height="120" /><br />' +
                        '<h4>' + item.Category + '</h4>' +
                        '<h3>' + item.Type + '</h3>' +
                        '<p>' + item.Description + '</p>' +
                        '<label> Minutes: ' + item.Duration + '</label>' +
                        '<h4>R ' + item.Fee + '</h4>' +
                        '</div></div>';
                    $carsouselInner.append(carouselItem);
                });
                $carsouselInner.children('.carousel-item').first().addClass('active');
            }
        });        
</script>


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
