using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dichvuhoanhao
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Baogia Brandname",
                url: "sms-brandname/bao-gia",
                defaults: new { controller = "Brandname", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia Icheck",
                url: "icheck/bao-gia",
                defaults: new { controller = "ICheck", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia Digital",
                url: "digital-marketing/bao-gia",
                defaults: new { controller = "Digital", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia Dauso",
                url: "cong-thanh-toan/bao-gia",
                defaults: new { controller = "Dauso", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia Hddt",
                url: "hoa-don-dien-tu/bao-gia",
                defaults: new { controller = "Hddt", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            //routes.MapRoute(
            //    name: "Baogia 3c_cskh",
            //    url: "cskh_3c/bao-gia",
            //    defaults: new { controller = "CSKH_3C", action = "Baogia" },
            //    namespaces: new[] { "Dichvuhoanhao.Controllers" }
            //);

            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Search", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Lienhe",
                url: "lien-he",
                defaults: new { controller = "Lienhe", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Website",
                url: "thiet-ke-website",
                defaults: new { controller = "Website", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Tichdiem",
                url: "tich-diem-doi-qua",
                defaults: new { controller = "Tichdiem", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Detail",
                url: "sms-brandname/{url}-{id}",
                defaults: new { controller = "Brandname", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia",
                url: "sms-brandname/bai-viet/{url}",
                defaults: new { controller = "Brandname", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Brandname",
                url: "sms-brandname",
                defaults: new { controller = "Brandname", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );

            routes.MapRoute(
                name: "Detail1",
                url: "icheck/{url}-{id}",
                defaults: new { controller = "ICheck", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia1",
                url: "icheck/bai-viet/{url}",
                defaults: new { controller = "ICheck", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "ICheck",
                url: "icheck",
                defaults: new { controller = "ICheck", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Detail2",
                url: "digital-marketing/{url}-{id}",
                defaults: new { controller = "Digital", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia2",
                url: "digital-marketing/bai-viet/{url}",
                defaults: new { controller = "Digital", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Digital",
                url: "digital-marketing",
                defaults: new { controller = "Digital", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Detail3",
                url: "hoa-don-dien-tu/{url}-{id}",
                defaults: new { controller = "Hddt", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia3",
                url: "hoa-don-dien-tu/bai-viet/{url}",
                defaults: new { controller = "Hddt", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Hddt",
                url: "hoa-don-dien-tu",
                defaults: new { controller = "Hddt", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Detail4",
                url: "cong-thanh-toan/{url}-{id}",
                defaults: new { controller = "Dauso", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia4",
                url: "cong-thanh-toan/bai-viet/{url}",
                defaults: new { controller = "Dauso", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Dauso",
                url: "cong-thanh-toan",
                defaults: new { controller = "Dauso", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );

            routes.MapRoute(
                name: "Detail5",
                url: "bao-hanh-dien-tu/{url}-{id}",
                defaults: new { controller = "CCC", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Detail6",
                url: "thiet-ke-website/{url}-{id}",
                defaults: new { controller = "Website", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Detail7",
                url: "tich-diem-doi-qua/{url}-{id}",
                defaults: new { controller = "Tichdiem", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "Baogia5",
                url: "bao-hanh-dien-tu/bai-viet/{url}",
                defaults: new { controller = "CCC", action = "Baogia" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
            routes.MapRoute(
                name: "CCC",
                url: "bao-hanh-dien-tu",
                defaults: new { controller = "CCC", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );


            routes.MapRoute(
                name: "Home",
                url: "trang-chu",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dichvuhoanhao.Controllers" }
            );
        }
    }
}
