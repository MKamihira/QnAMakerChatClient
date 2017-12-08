using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace QnAMakerChatClient
{
    public class QnAClient
    {
        public async Task<AnswersObject> GetAnswers(string question)
        {
            if (string.IsNullOrEmpty(question))
                throw new ArgumentException(nameof(question));

            var endpointUrl = "https://westus.api.cognitive.microsoft.com/qnamaker/v2.0";
            var webApiUrl = endpointUrl + "/knowledgebases/88dc5c75-1f86-4694-9248-fe9bb3f1865d/generateAnswer";

            var content = new StringContent(JsonConvert.SerializeObject(new { question = question }));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "ab05c969568943248bcd51b5b25d2bcf");

                using (var response = await client.PostAsync(webApiUrl, content))
                {
                    return JsonConvert.DeserializeObject<AnswersObject>(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
