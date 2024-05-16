@ModelType HartsWebApp.ContactDetails

@Code
    ViewData("Title") = "Contact Us"
End Code
@If User.IsInRole("ADMIN") Or User.IsInRole("OWNER") Then

    @Html.ActionLink("EDIT PAGE", "Edit", "ContactDetails", New With {.id = Model.ID}, htmlAttributes:=New With {.class = "btn btn-default"})

End If
<h2 class="alert-info">@ViewData("Title").</h2>

<div class="list-group">
    <address class="list-group-item">
        <strong>Physical Address: </strong>@Model.Address
    </address>
    <div class="list-group-item">
        <script>
            (g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })
                ({ key: "", v: "beta" });
        </script>
        <script>
            // Initialize and add the map
            let map;

            async function initMap() {
                // The location of Shop
                const position = { lat: -33.93302064119899, lng: 18.860053397012027 };
                // Request needed libraries.
                //ts-ignore
                const { Map } = await google.maps.importLibrary("maps");
                const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

                // The map, centered at Shop
                map = new Map(document.getElementById("map"), {
                    zoom: 14,
                    center: position,
                    mapId: "DEMO_MAP_ID",
                });

                // The marker, positioned at Shop
                const marker = new AdvancedMarkerElement({
                    map: map,
                    position: position,
                    title: "HG International Unisex Salon",
                });
            }
            initMap();
        </script>
    </div>

    <div class="list-group-item">
        <strong>Email: </strong><a href="@Model.HelpDeskEmail">@Model.HelpDeskEmail</a><br />
        <strong>Phone Number: </strong><a href="@Model.HelpDeskNumber">@Model.HelpDeskNumber</a><br />
    </div>
    <div class="list-group-item">
        <strong>Complaints Email Address: </strong><a href="@Model.ComplaintsEmail">@Model.ComplaintsEmail</a>
    </div>
</div>