using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Media;
using System.Speech.Synthesis;
using QnAMakerChatClient;


namespace QnAMakerChatClient
{
    public class ViewModel : ViewModelBase
    {
        public ViewModel() : base() { SendCommand = new SendCommand(this); }

        public ObservableCollection<ChatItem> ChatItems { get; }
        = new ObservableCollection<ChatItem>();

        private string _question;

        public string Question
        {
            get { return _question; }
            set { _question = value; OnPropertyChanged(); }
        }

        private bool _male;

        public bool Male
        {
            get { return _male; }
            set { _male = value; }
        }


        public SendCommand SendCommand { get; private set; }
    }

    public class SendCommand : CommandBase
    {
        private ViewModel _vm;
        private TextToSpeechAudio tts = new TextToSpeechAudio();
        private Translate ts = new Translate();
        public SendCommand(ViewModel vm) : base() { _vm = vm; }

        public override bool CanExecuteCore(object parameter) => !string.IsNullOrEmpty(_vm.Question);


        public override async void ExecuteCore(object parameter)
        {
            var question = _vm.Question;
            var To = new Token();

            _vm.ChatItems.Add(new ChatItem(MessageType.Send)
            {
                Message = question,
                From = "Me"
            });
            SimpleMessenger.Instance.Send("AddItem", _vm.ChatItems.Last());

            //TranslatorのToken作成
            var TS_key = "58411ff8eb4d43f58b90938d9b28d9ab";
            var TS_token = await To.GetToken(TS_key);

            //翻訳
            var translated = ts.Translator(TS_token, question);

            var client = new QnAClient();
            var answers = await client.GetAnswers(translated);

            var firstAnswer = answers.answers.First();

            var answerItem = new ChatItem(MessageType.Receive)
            {
                Message = firstAnswer.answer,
                Score = firstAnswer.score,
                From = "Bot"
            };
            SimpleMessenger.Instance.Send("AddItem", _vm.ChatItems.Last());

            _vm.ChatItems.Add(answerItem);

            ////TTSのtoken作成
            //var TTS_key = "f15256cdf3dc481682d420db7982457a";
            //var TTS_token = await To.GetToken(TTS_key);

            var gender = _vm.Male == true ? "Ichiro" : "Ayumi";
            ////音声ファイル取得
            //var file = await tts.TextToSpeech(TTS_token,answerItem.Message, gender);
            ////音声再生
            //tts.PlaySound(file);

            //Synthesizerでやってみる
            tts.Synthesizer(answerItem.Message, gender);

            _vm.Question = string.Empty;
        }
    }

    public class ChatItem
    {
        public ChatItem(MessageType type)
        {
            MessageType = type;
        }

        public string Message { get; set; }
        public MessageType MessageType { get; private set; }

        public double Score { get; set; }
        public string From { get; set; }

    }

    public enum MessageType
    {
        Send,
        Receive
    }
}
