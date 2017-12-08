using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QnAMakerChatClient
{
    public class Answer
    {
        public string answer { get; set; }
        public List<string> questions { get; set; }
        public double score { get; set; }
    }

    public class AnswersObject
    {
        public List<Answer> answers { get; set; }
    }

    public class Token
    {
        //tokenつくるよ
        public async Task<string> GetToken(string key)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            var uri = @"https://api.cognitive.microsoft.com/sts/v1.0/issueToken";

            using (var content = new ByteArrayContent(new byte[0]))
            {
                content.Headers.ContentLength = 0;
                var response = await client.PostAsync(uri, content);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }

}
