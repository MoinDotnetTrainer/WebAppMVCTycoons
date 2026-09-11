namespace WebAppMVCRepos.Models
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("app-button")]
    public class ButtonTagHelper : TagHelper
    {
        public string Text { get; set; } = "Click";

        public string Type { get; set; } = "button";

        public string CssClass { get; set; }
        
        public override void Process(
            TagHelperContext context,
            TagHelperOutput output)
        {
            output.TagName = "button";

            output.Attributes.SetAttribute("type", Type);

            if (!string.IsNullOrEmpty(CssClass))
            {
                output.Attributes.SetAttribute("class", CssClass);
            }

            output.Content.SetContent(Text);
        }
    }
}
