@ModelType IEnumerable(Of HartsWebApp.Service)

@For Each item In Model
    @If IsNothing(item) Then
        @<h4>EMPTY/NOTHING </h4>
    End If
    @<div class="col-md-4">        
        <div class="thumbnail" for="HairServiceID">
            <img class="img-responsive img-rounded" src="" alt="@item.Type - image not available" />
            <div class="caption">
                <h3>@item.Type</h3>
                <h5>@item.Category</h5>                
                <h4>R @item.Fee</h4>               
            </div>
        </div>
    </div>
Next