@ModelType LoginViewModel
@Code
    ViewBag.Title = "Log in"
End Code

<hr style="color:black;" />
<p>
    @Html.ActionLink("Register as a new user", "Register")
</p>
<hr style="color:black;" />

<div class="center-block container">
    @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal col-md-4", .role = "form"})
        @<div class="container center-block">
            <div class="card">
                <div class="card-header">
                    <h4>Use a local account to log in.</h4>
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
                        <div class="col-md-10">
                            @Html.LabelFor(Function(m) m.RememberMe)
                            @Html.CheckBoxFor(Function(m) m.RememberMe)
                        </div>
                    </div>
                    <input type="submit" value="Sign In" class="btn btn-lg btn-primary btn-block" />
                    <br />
                    @* Enable this once you have account confirmation enabled for password reset functionality*@
                    <p>
                        @Html.ActionLink("Forgot your password?", "ForgotPassword")
                    </p>
                </div>
            </div>
        </div>
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
