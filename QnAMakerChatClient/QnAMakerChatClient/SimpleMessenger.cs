using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnAMakerChatClient
{
    public class SimpleMessenger
    {
        public static SimpleMessenger Instance { get; } = new SimpleMessenger();

        private SimpleMessenger() { }

        private Dictionary<string, object> _subscribes = new Dictionary<string, object>();

        public void Subscribe<TArgs>(string key, Action<TArgs> args) => _subscribes[key] = args;

        public void UnSubscribe(string key) => _subscribes.Remove(key);

        public void Send<TArgs>(string key, TArgs args)
        {
            if (_subscribes.ContainsKey(key))
            {
                Action<TArgs> action = _subscribes[key] as Action<TArgs>;
                action?.Invoke(args);
            }
        }
    }
}
