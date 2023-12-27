using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;


namespace SmartEssayChecker.Api.Services.Foundations.TextInputFormatter
{
    public class TextInput : InputFormatter
    {
        private const string MimeType = "text/plain";

        public TextInput()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(MimeType));
        }

        public override bool CanRead(InputFormatterContext context) =>
            context.HttpContext.Request.ContentType?.StartsWith(MimeType) ?? false;

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();

                return await InputFormatterResult.SuccessAsync(content);
            }
        }
    }
}
