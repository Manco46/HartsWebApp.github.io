@ModelType IEnumerable(Of HartsWebApp.Service)
@Code

    ViewData("Title") = "Home Page"
    Dim indicatorCounter = 0
    Dim slideCounter = 0
    ''Dim serviceData As IEnumerable(Of Service)
End Code
<!-- Indicators -->
<ol class="carousel-indicators">

    @For Each indicatorItem In Model
        @<li data-target="myCarousel-@indicatorItem.SectionID" data-slide-to="@indicatorCounter" class="@IIf(indicatorCounter = 0, "active", "")"></li>
        indicatorCounter += 1
    Next
</ol>
 
<!-- Wrapper for slides -->
<div class="carousel-inner">
    @For Each slideItem In Model
        @<div class="item @IIf(slideCounter = 0, "active", "")">
            <img src="@slideItem.Picture" alt="@slideItem.Type" style="width:100%; height:10%">
            <div class="carousel-caption">
                <h2>@slideItem.Type</h2>
                <p>@slideItem.Description</p>
                @Html.ActionLink("Add To Cart", "AddToCart", "UserCarts", New With {.VALUE = slideItem.ID, .sectionID = slideItem.SectionID}, htmlAttributes:=New With {.class = "btn btn-default btn-block"})
                <br />
            </div>            
        </div>
        slideCounter += 1
    Next
</div>





