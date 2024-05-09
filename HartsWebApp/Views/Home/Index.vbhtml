@ModelType IEnumerable(Of HartsWebApp.ServiceSection)
@Code
    Dim counter = 0
    ViewData("Title") = "Home Page"
    Dim db As New ApplicationDbContext

End Code

<div Class="list-group">
    @For Each item In Model
        @<div Class="list-group-item">
             <h2 class="text-center" style=" background-color:#acacac; color:#ffffff;"> @item.SectionName.ToUpper SECTION</h2>
            <div id="myCarousel-@item.SectionName" Class="carousel slide" data-ride="carousel">
                @Html.Partial("_HomeView", db.Services.Where(Function(s) s.SectionID = item.ID).ToList)
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



