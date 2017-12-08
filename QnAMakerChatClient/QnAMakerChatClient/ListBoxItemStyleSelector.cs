using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;

namespace QnAMakerChatClient
{
    public class ListBoxItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var chatItem = item as ChatItem;
            if (chatItem == null) return base.SelectStyle(item, container);

            var element = container as FrameworkElement;

            if(chatItem.MessageType == MessageType.Send)
            {
                return (Style)element.FindResource("sendItemStyle");
            }
            else
            {
                return (Style)element.FindResource("receiveItemStyle");
            }
        }
    }
}
