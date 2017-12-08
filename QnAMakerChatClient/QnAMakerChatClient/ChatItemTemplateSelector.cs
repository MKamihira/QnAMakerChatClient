using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace QnAMakerChatClient
{
    public class ChatItemTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var chatItem = item as ChatItem;
            if (chatItem == null) return base.SelectTemplate(item, container);

            var element = container as FrameworkElement;
            if (chatItem.MessageType == MessageType.Send)
            {
                return (DataTemplate)element.FindResource("sendTemplate");
            }
            else
            {
                return (DataTemplate)element.FindResource("receiveTemplate");
            }
        }
    }
}
