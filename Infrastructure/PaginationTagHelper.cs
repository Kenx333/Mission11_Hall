using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_Hall.Models.ViewModels;

namespace Mission11_Hall.Infrastructure
{
    // This class defines a custom tag helper for pagination functionality.
    // It generates HTML markup for pagination links based on the provided PaginationInfo model.
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        // Constructor for PaginationTagHelper.
        // It initializes the urlHelperFactory.
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        // Properties for PaginationTagHelper.
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
        public PaginationInfo PageModel { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = string.Empty;
        public string PageClassNormal { get; set; } = string.Empty;
        public string PageClassSelected { get; set; } = string.Empty;

        // Method to process the tag helper.
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Check if ViewContext and PageModel are not null.
            if (ViewContext != null && PageModel != null)
            {
                // Get the URL helper from the factory.
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                // Create a new <div> tag.
                TagBuilder result = new TagBuilder("div");

                // Loop through each page to generate pagination links.
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    // Create an <a> tag for each page.
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    // Add CSS classes if enabled.
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    // Set the page number as inner text.
                    tag.InnerHtml.Append(i.ToString());

                    // Append the <a> tag to the result.
                    result.InnerHtml.AppendHtml(tag);
                }

                // Append the generated pagination links to the output content.
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
