@ModelType IEnumerable(Of HartsWebApp.ServiceSection)
@Code

    ViewData("Title") = "Harts Cart"
    Dim db As New ApplicationDbContext
End Code

<h2>@ViewBag.TotalAmount</h2>

<div class="container">
    <div Class="">
        @For Each item In Model
            @<div class="panel-group">
                <div class="panel panel-default @item.SectionName">
                    <div class="panel-heading">
                        <h3 class="panel-title">

                            @Ajax.ActionLink(item.SectionName, "GetCartSectionItems", "UserCarts", New With {.sectionID = item.ID}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "bodyContent-" + item.SectionName, .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "w3-bar-item w3-button"})
                        </h3>
                    </div>
                    <div id="bodyContent-@item.SectionName" class="panel-body form-group">
                        @Html.Partial("_CartServices", db.Services.Where(Function(s) s.SectionID = item.ID And s.Add_On = False))
                        <hr />
                        <div>
                            <h2>ADD-ONS</h2>
                            @Html.Partial("_CartServices", db.Services.Where(Function(s) s.SectionID = item.ID And s.Add_On = True))
                        </div>
                    </div>

                </div>
            </div>
            @<script>
                $(document).ready(function () {
                    $(.btn-check-@item.ID).click(function () {

                        $("panel panel-default @item.SectionName").attr("class", "panel panel-success @item.SectionName");

                        });

                });
            </script>
        Next
        <hr />
        <div>
            <h3>APPOINTMENT SCHEDULING</h3>

            <div class="form-group">               
                <div class="col-md-10">
                    <input class="form-control" type="date" />
                </div>
            </div>          
            <div class="form-group">
                <div class="col-md-10">
                    @Html.DropDownList("timeRequired", New SelectList(ViewBag.TimesRequired), "Prefered Time of Appointment", New With {.class = "form-control"})
                </div>
            </div>
        </div>        
        <hr />
        <h2>@ViewBag.TotalAmount</h2>

        <div>
            @Ajax.ActionLink("CHECKOUT", "AddService", "UserCarts", New With {.serviceID = ""}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "troubleshoot", .InsertionMode = InsertionMode.Replace, .OnSuccess = "hideSelectedItem('" + "" + "')"}, htmlAttributes:=New With {.class = "btn btn-primary btn-block"})

        </div>
    </div>
</div>






<!--<div id="testing"></div>-->


<script>
    $(document).ready(function () {




        /*var panelSection = $(".panel-collapse");
        var myContentArrayIDs = [];

        panelSection.each(function () {

            myContentArrayIDs.push($(this).attr("id"));

        });

        var sectionID = "";
        var contentBodyID = "";

        //$("#testing").append(panelSection);


        for (var countI = 0; countI < myContentArrayIDs.length; countI++) {

            sectionID = myContentArrayIDs[countI];
            contentBodyID = "bodyContent-" + myContentArrayIDs[countI];

            $.ajax({
                url: "https://localhost:44393/UserCarts/GetCartSectionItems",
                type: "GET",
                data: { sectionName: sectionID },
                dataType: "html",
                success: function (htmlPartialViewData) {
                    $("#" + contentBodyID).empty();
                    $("#" + contentBodyID).append(htmlPartialViewData);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    $("#" + contentBodyID).empty();
                    $("#" + contentBodyID).append("Error Type: " + jqXHR + " Status: " + textStatus + " Exception: " + errorThrown);
                }
            });

        }*/

    });
</script>