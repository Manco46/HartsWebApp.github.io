@ModelType IEnumerable(Of HartsWebApp.ServiceSection)
@Code

    ViewData("Title") = "Harts Cart"
    Dim db As New ApplicationDbContext
End Code



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