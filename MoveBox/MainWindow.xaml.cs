using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MoveBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // 首先判断按键的方位 比如上下左右
            // 向上移动 移动格子每次减3 向下移动 移动格子每次加3
            // 向左一定 每次减1 向右移动 每次加1

            // 获取白色的border元素
            UIElementCollection children = gridContent.Children;
            Border curBorder = null;
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i] is Border)
                {
                    if (((children[i] as Border).Background as SolidColorBrush).Color.Equals(Colors.White))
                    {
                        curBorder = children[i] as Border;
                    }
                    (children[i] as Border).Background = new SolidColorBrush(Colors.Transparent);
                }
            }

            string name = curBorder.Name;
            int index = Convert.ToInt32(name.Replace("b", ""));

            if (e.Key.Equals(Key.Up))
            {
                index = index - 3 >= 1 ? index - 3 : index;
            }
            else if (e.Key.Equals(Key.Down))
            {
                index = index + 3 <= 9 ? index + 3 : index;
            }
            else if (e.Key.Equals(Key.Left))
            {
                index = index - 1 >= 1 ? index - 1 : index;
            }
            else
            {
                index = index - 1 <= 9 ? index + 1 : index;
            }

            // 将移动到的Border的背景色改成白色
            object control = gridContent.FindName("b" + index);
            if (control != null)
            {
                (control as Border).Background = new SolidColorBrush(Colors.White);
            }

        }
    }
}