using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppMVCRepos.Models
{
    [HtmlTargetElement("Heading")]
    public class HeadingTag : TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";
            output.Content.SetContent($"{Name}");
        }

        // button same like
    }
}
