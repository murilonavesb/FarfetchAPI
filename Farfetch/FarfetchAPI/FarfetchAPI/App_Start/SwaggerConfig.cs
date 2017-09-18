using System.Web.Http;
using WebActivatorEx;
using FarfetchAPI;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Text.RegularExpressions;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FarfetchAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "FarfetchAPI");
                    //c.OperationFilter(() => new Class.AddAuthorizationHeaderParameterOperationFilter());
                    c.IncludeXmlComments(GetXmlCommentsPath("FarfetchAPI.XML"));
                    c.OperationFilter<FormatXmlCommentProperties>();
                    c.UseFullTypeNameInSchemaIds();
                })
                .EnableSwaggerUi();
        }

        protected static string GetXmlCommentsPath(string fileName)
        {
            return System.String.Format(@"{0}\bin\{1}", System.AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public class FormatXmlCommentProperties : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                operation.description = Formatted(operation.description);
                operation.summary = Formatted(operation.summary);
            }

            private string Formatted(string text)
            {
                if (text == null) return null;

                // Strip out the whitespace that messes up the markdown in the xml comments,
                // but don't touch the whitespace in <code> blocks. Those get fixed below.
                string resultString = Regex.Replace(text, @"(^[ \t]+)(?![^<]*>|[^>]*<\/)", "", RegexOptions.Multiline);
                resultString = Regex.Replace(resultString, @"<code[^>]*>", "<pre>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                resultString = Regex.Replace(resultString, @"</code[^>]*>", "</pre>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
                resultString = Regex.Replace(resultString, @"<!--", "", RegexOptions.Multiline);
                resultString = Regex.Replace(resultString, @"-->", "", RegexOptions.Multiline);

                try
                {
                    string pattern = @"<pre\b[^>]*>(.*?)</pre>";

                    foreach (Match match in Regex.Matches(resultString, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline))
                    {
                        var formattedPreBlock = FormatPreBlock(match.Value);
                        resultString = resultString.Replace(match.Value, formattedPreBlock);
                    }
                    return resultString;
                }
                catch
                {
                    // Something went wrong so just return the original resultString
                    return resultString;
                }
            }

            private string FormatPreBlock(string preBlock)
            {
                // Split the <pre> block into multiple lines
                var linesArray = preBlock.Split('\n');
                if (linesArray.Length < 2)
                {
                    return preBlock;
                }
                else
                {
                    // Get the 1st line after the <pre>
                    string line = linesArray[1];
                    int lineLength = line.Length;
                    string formattedLine = line.TrimStart(' ', '\t');
                    int paddingLength = lineLength - formattedLine.Length;

                    // Remove the padding from all of the lines in the <pre> block
                    for (int i = 1; i < linesArray.Length - 1; i++)
                    {
                        linesArray[i] = linesArray[i].Substring(paddingLength);
                    }

                    var formattedPreBlock = string.Join("", linesArray);
                    return formattedPreBlock;
                }

            }
        }
    }
}
