@ModelType LoginViewModel
@Code
    ViewBag.Title = "Log in"
End Code

<h2>@ViewBag.Title.</h2>
<div class="container">      
            
    @Using Html.BeginForm("Login", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
        @<div class="container">           
          
            <div class="card">
                <div class="card-header">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    @Html.AntiForgeryToken()
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                </div>
                <div class="card-body">
                    <div class="form-group">                                        
                        <div class="col-md-10">
                            @Html.LabelFor(Function(m) m.Email, New With {.class = "sr-only"})
                            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control", .placeholder = "Email Address", .type = "email"})
                            @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.Password, New With {.class = "sr-only"})
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "Password"})
                            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                @Html.CheckBoxFor(Function(m) m.RememberMe)
                                @Html.LabelFor(Function(m) m.RememberMe)
                            </div>
                        </div>
                    </div>                    
                    <input type="submit" value="Sign In" class="btn btn-lg btn-primary btn-block" />                   
                   

                </div>
            </div>
        </div>


        @<p>
            @Html.ActionLink("Register as a new user", "Register")
        </p>
        @* Enable this once you have account confirmation enabled for password reset functionality
            <p>
                @Html.ActionLink("Forgot your password?", "ForgotPassword")
            </p>*@

    End Using
       
    
    <div class="col-md-4">
        <section id="socialLoginForm">
            @Html.Partial("_ExternalLoginsListPartial", New ExternalLoginListViewModel With {.ReturnUrl = ViewBag.ReturnUrl})
        </section>
    </div>
</div>


@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
