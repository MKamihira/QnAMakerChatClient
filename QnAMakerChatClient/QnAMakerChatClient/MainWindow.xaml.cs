using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QnAMakerChatClient
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender,RoutedEventArgs e)
        {
            SimpleMessenger.Instance.Subscribe<ChatItem>("AddItem",(item) => chatList.ScrollIntoView(item));
        }

        private void MainWindow_Closed(object sender,EventArgs e)
        {
            SimpleMessenger.Instance.UnSubscribe("AddItem");
        }
    }
}
