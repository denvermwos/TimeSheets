using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TimeSheets.Web.CustomHtmlHelpers
{
    public static class DateTimeHelper
    {
        public static MvcHtmlString DateTimeFor<TModel, TValue>(this HtmlHelper<TModel> self,
            Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var inputGroupDiv = new TagBuilder("div");
            var inputGroupAddonSpan = new TagBuilder("span");
            var glyphiconSpan = new TagBuilder("span");

            //Main Input
            //MvcHtmlString input = self.TextBoxFor(expression, "{0:dd/MM/yyyy HH:mm}", new { @class = "form-control", data_date_format = "DD/MM/YYYY HH:mm" });
            MvcHtmlString input = self.TextBoxFor(expression, "{0:ddd dd MMM yyyy HH:mm}", new { @class = "form-control", data_date_format = "ddd DD MMM YYYY HH:mm" });
           
            inputGroupDiv.AddCssClass("datetimepicker");
            inputGroupDiv.AddCssClass("date");
            inputGroupDiv.AddCssClass("input-group");


            inputGroupDiv.InnerHtml = input.ToHtmlString();

            glyphiconSpan.AddCssClass("glyphicon");
            glyphiconSpan.AddCssClass("glyphicon-time");

            inputGroupAddonSpan.AddCssClass("input-group-addon");
            inputGroupAddonSpan.InnerHtml = glyphiconSpan.ToString();

            inputGroupDiv.InnerHtml += inputGroupAddonSpan;

            return new MvcHtmlString(inputGroupDiv.ToString());
        }

        public static MvcHtmlString DateFor<TModel, TValue>(this HtmlHelper<TModel> self,
            Expression<Func<TModel, TValue>> expression)
        {
            var inputGroupDiv = new TagBuilder("div");


            //Main Input
            //MvcHtmlString input = self.TextBoxFor(expression, "{0:dd/MM/yyyy}", new { @class = "form-control", data_date_format = "DD/MM/yyyy", data_date_pickTime = "false", name = "id" });
            MvcHtmlString input = self.TextBoxFor(expression, "{0:ddd dd MMM yyyy}", new { @class = "form-control", data_date_format = "ddd DD MMM YYYY", data_date_pickTime = "false", name = "id" });
            inputGroupDiv.AddCssClass("datetimepicker");


            inputGroupDiv.InnerHtml = input.ToHtmlString();


            return new MvcHtmlString(inputGroupDiv.ToString());
        }
    }
}