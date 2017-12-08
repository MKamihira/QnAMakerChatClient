using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;


namespace QnAMakerChatClient
{
    public class TextToSpeechAudio
    {
        public async Task<string> TextToSpeech(string token,string answer,string gender)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Microsoft-OutputFormat", "riff-16khz-16bit-mono-pcm");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.DefaultRequestHeaders.Add("X-Search-AppId", Guid.NewGuid().ToString("N"));
            client.DefaultRequestHeaders.Add("X-Search-ClientID", Guid.NewGuid().ToString("N"));
            var uri = @"https://speech.platform.bing.com/synthesize";

            //合成させる文章生成部分（ssmlでPostするので注意を！）
            var speechSsml = $"<prosody volume='+50'>{answer}</prosody>";
            var speakSsml = $"<speak version='1.0' xml:lang='en-US'><voice xml:lang='ja-JP' xml:gender='Male' name='Microsoft Server Speech Text to Speech Voice (ja-JP, {gender}, Apollo)'>{speechSsml}</voice></speak>";

            byte[] bytes = Encoding.UTF8.GetBytes(speakSsml);
            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/ssml+xml");
                //レスポンス取得
                var response = await client.PostAsync(uri, content);
                var responseStream = response.Content.ReadAsStreamAsync().Result;
                //ファイル作成
                using (var outputFileStream = new FileStream("file.wav", FileMode.Create, FileAccess.Write))
                {
                    responseStream.CopyTo(outputFileStream);
                    return outputFileStream.Name;
                }
            }
        }

        private System.Media.SoundPlayer player = null;

        //再生止める
        public void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        //再生する
        public void PlaySound(string soundFile)
        {
            player = new System.Media.SoundPlayer(soundFile);
            player.Play();
        }


        //SpeechSynthesizerで再生してみる
        public void Synthesizer (string message, string gender)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            if (gender == "Ichiro")
                synth.SelectVoiceByHints(VoiceGender.Male);
            else
                synth.SelectVoiceByHints(VoiceGender.Female);


            //オーディオ出力を設定
            synth.SetOutputToDefaultAudioDevice();
            //出力
            synth.Speak(message);
        }
    }
}
