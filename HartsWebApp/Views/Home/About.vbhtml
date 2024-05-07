@Modeltype  HartsWebApp.About
@Code
    ViewData("Title") = "About Us"
End Code
<hr />
@If User.IsInRole("ADMIN") Or User.IsInRole("OWNER") Then

    @Html.ActionLink("EDIT PAGE", "Edit", "Abouts", New With {.id = Model.ID}, htmlAttributes:=New With {.class = "btn btn-default"})

End If
<p>@Model.AboutInformation</p>
<hr />
@Html.Raw(Model.EmbedLinkForPost)

@Html.Raw(Model.EmbedLinkForPost2)

@Html.Raw(Model.EmbedLinkForPost3)

@Html.Raw(Model.EmbedLinkForPost4)
<hr />
<p>@Model.AboutAdditionalInformation</p>

