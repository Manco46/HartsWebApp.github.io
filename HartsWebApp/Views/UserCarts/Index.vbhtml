@ModelType IEnumerable(Of HartsWebApp.ServiceSection)
@Code

    ViewData("Title") = "Harts Cart"
End Code
@Using Ajax.BeginForm("Create", "Appointments", New AjaxOptions With {.HttpMethod = "POST"})


    @<div class="container">
        <div Class="">
            @For Each item In Model
                @<div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                @Ajax.ActionLink(item.SectionName, "GetCartSectionItems", "UserCarts", New With {.sectionName = item.SectionName}, New AjaxOptions With {.HttpMethod = "GET", .UpdateTargetId = "bodyContent-" + item.SectionName, .InsertionMode = InsertionMode.Replace}, htmlAttributes:=New With {.class = "w3-bar-item w3-button"})                            
                            </h3>
                        </div>                    
                        <div id="bodyContent-@item.SectionName" class="panel-body"></div>                                    
                    </div>
                </div>
            Next
        </div>
    </div>
End Using





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