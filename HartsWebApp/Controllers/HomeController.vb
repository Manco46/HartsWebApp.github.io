

<RequireHttps>
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDbContext

    Function MenCarouselData() As JsonResult
        Dim menCarouselItems = (From e In db.Services
                                Where e.Sexuality = "Male"
                                Select New With {
                           .Category = e.Category,
                           .Type = e.Type,
                           .Description = e.Description,
                           .Duration = e.Duration,
                           .Fee = e.Fee,
                           .Picture = e.Picture
                           }).ToList()
        Return Json(menCarouselItems, JsonRequestBehavior.AllowGet)
    End Function

    Function Index() As ActionResult
        Return View(db.ServiceSections.ToList)
    End Function

    Function About() As ActionResult
        Return View(db.About.FirstOrDefault)
    End Function



    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."


        Return View()
    End Function
End Class
