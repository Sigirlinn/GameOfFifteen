using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;


namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button empty;
        private int sizeBone = 80, stepBone = 10;
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            double left = ((Button)sender).Margin.Left;
            double top = ((Button)sender).Margin.Top;
            double emLeft = empty.Margin.Left;
            double emTop = empty.Margin.Top;
            if (left == emLeft)
            {
                if ((top == emTop + sizeBone + stepBone) || (top == emTop - (sizeBone + stepBone)))
                {
                    flag = true;
                }

            }
            else if (top == emTop)
            {
                if ((left == emLeft - (sizeBone + stepBone)) || (left == emLeft + sizeBone + stepBone))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                int i = ((Bone)DataContext).GetIndexFromMargin(((Button)sender).Margin, stepBone, sizeBone);
                int j = ((Bone)DataContext).GetIndexFromMargin(empty.Margin, stepBone, sizeBone);
                int k = Convert.ToInt32(((Button)sender).Content);

                ((Bone)DataContext).Bones[i] = 0;
                ((Bone)DataContext).Bones[j] = k;


                ThicknessAnimation buttonAnimation = new ThicknessAnimation();
                buttonAnimation.From = new Thickness(left, top, 0, 0);
                buttonAnimation.To = new Thickness(emLeft, emTop, 0, 0);
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.4);
                ((Button)sender).BeginAnimation(Button.MarginProperty, buttonAnimation);

                ThicknessAnimation emptyAnimation = new ThicknessAnimation();
                buttonAnimation.To = new Thickness(left, top, 0, 0);
                buttonAnimation.From = new Thickness(emLeft, emTop, 0, 0);
                buttonAnimation.Duration = TimeSpan.FromSeconds(0.1);
                empty.BeginAnimation(Button.MarginProperty, buttonAnimation);

                count++;
                textBlock.Text = "Step " + count.ToString();
                if (((Bone)DataContext).WinningCheck())
                {
                    textBlockWin.Opacity = 100;
                    Field.IsEnabled = false;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hideButton();
        }

        private void NewGen(object sender, RoutedEventArgs e)
        {
            empty.Opacity = 100;
            ((Bone)DataContext).Refresh();
            hideButton();
        }

        private void hideButton()
        {
            count = 0;
            textBlock.Text = "Step " + count.ToString();
            textBlockWin.Opacity = 0;
            Field.IsEnabled = true;
            for (int i = 0; i < 16; i++)
            {

                if (((Button)Field.Children[i]).Content.ToString() == "0")
                {
                    ((Button)Field.Children[i]).Opacity = 0;
                    empty = ((Button)Field.Children[i]);
                    break;
                }
            }
        }
    }
}
