' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.MapRoute(
            "DefaultDetails",
            "{controller}/Details",
            New With {
               .controller = "Product",
                .action = "Index",
                .id = UrlParameter.Optional
                }
            )
        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}", _
            New With {.controller = "Product", .action = "Index", .id = UrlParameter.Optional}
        )
    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class
