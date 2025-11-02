using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IS4439_Project_1.TagHelpers
{
    // This tag helper targets <test>...</test>
    [HtmlTargetElement("test")]
    public class TestTagHelper : TagHelper
    {
        // Optional attributes to control the link
        public string Url { get; set; } = "https://www.ucc.ie/";
        public string? Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Turn <test> into <a>
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;

            // Set the href
            output.Attributes.SetAttribute("href", Url);

            // Uses provided Text=… or fallback to inner content or a default label
            if (!string.IsNullOrWhiteSpace(Text))
            {
                output.Content.SetContent(Text);
            }
            else
            {
                // If no Text attribute, try child content - if empty, use a default
                var child = context.Items.ContainsKey("child") ? context.Items["child"]?.ToString() : null;
                output.Content.SetContent(string.IsNullOrWhiteSpace(child) ? "Visit site" : child!);
            }
        }
    }
}
