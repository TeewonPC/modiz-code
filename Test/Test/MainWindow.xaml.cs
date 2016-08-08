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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Test.ViewModel;

namespace Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ellipse> ellPig=new List<Ellipse>();
        int pigNum = 0;
        List<Ellipse> ellBird = new List<Ellipse>();
        int birdNum = 0;
        List<Ellipse> ellCrab = new List<Ellipse>();
        int crabNum = 0;
        List<Ellipse> ellSnake = new List<Ellipse>();
        int snakeNum = 0;
        int time = 0;
        int totalNum = 0;
        int flag = 0;
        int clearNum = 0;
        MyBlood myBlood;
        DispatcherTimer timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            myBlood = new MyBlood { blood = 10000 };
            this.Canvas.DataContext = myBlood;
            this.Loaded += new RoutedEventHandler(MainWindow_loaded);
        }
        private void MainWindow_loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;

            #region 猪之歌
            if (time % 2 == 0 && totalNum<50)
            {
                //MessageBox.Show("YYY");
                var brush = new ImageBrush(pigImage.Source); //定义图片画刷
                Ellipse temp = new Ellipse();
                temp.Width = 40;
                temp.Height = 50;
                temp.Fill = brush;
                ellPig.Add(temp);
                Canvas.Children.Add(ellPig[pigNum]);
                Random ran = new Random();
                int RandKey = ran.Next(40, 360);
                Canvas.SetLeft(ellPig[pigNum], RandKey);
                Canvas.SetTop(ellPig[pigNum], 0);
                ellPig[pigNum].MouseDown += new MouseButtonEventHandler(elips_MouseDown1);
                pigNum++;
                totalNum++;
            }

            for (int i = 0; i < ellPig.Count(); i++)
            {
                Point curPoint = new Point();
                curPoint.X = Canvas.GetLeft(ellPig[i]);
                curPoint.Y = Canvas.GetTop(ellPig[i]);
                Point deskPoint = curPoint;
                deskPoint.X = curPoint.X ;
                deskPoint.Y = curPoint.Y + 30;

                double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));
                double _secNumber = (_s / 1000) * 500;

                Storyboard storyboard = new Storyboard();

                //创建Y轴方向动画
                DoubleAnimation doubleAnimation = new DoubleAnimation(
                  Canvas.GetTop(ellPig[i]),
                  deskPoint.Y,
                  new Duration(TimeSpan.FromMilliseconds(_secNumber))
                );
                Storyboard.SetTarget(doubleAnimation, ellPig[i]);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
                storyboard.Children.Add(doubleAnimation);

                //动画播放
                storyboard.Begin();
                if (deskPoint.Y>=600)
                {
                    Canvas.Children.Remove(ellPig[i]);
                    myBlood.blood -= 1000;
                }
                if (myBlood.blood <= 0)
                {
                    timer.Stop();
                    gameOver();
                }
            }
            #endregion

            #region 大闸蟹
            if (time % 4 == 0 && totalNum < 50)
            {
                //MessageBox.Show("YYY");
                var brush = new ImageBrush(crabImage.Source); //定义图片画刷
                Ellipse temp = new Ellipse();
                temp.Width = 50;
                temp.Height = 40;
                temp.Fill = brush;
                ellCrab.Add(temp);
                Canvas.Children.Add(ellCrab[crabNum]);
                Random ran = new Random();
                int RandKey = ran.Next(40, 560);
                Canvas.SetLeft(ellCrab[crabNum], 0);
                Canvas.SetTop(ellCrab[crabNum], RandKey);
                ellCrab[crabNum].MouseDown += new MouseButtonEventHandler(elips_MouseDown2);
                crabNum++;
                totalNum++;
            }

            for (int i = 0; i < ellCrab.Count(); i++)
            {
                Point curPoint = new Point();
                curPoint.X = Canvas.GetLeft(ellCrab[i]);
                curPoint.Y = Canvas.GetTop(ellCrab[i]);
                Point deskPoint = curPoint;
                deskPoint.X = curPoint.X + 10;
                deskPoint.Y = curPoint.Y;

                double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));
                double _secNumber = (_s / 1000) * 500;

                Storyboard storyboard = new Storyboard();

                //创建X轴方向动画
                DoubleAnimation doubleAnimation = new DoubleAnimation(
                  Canvas.GetLeft(ellCrab[i]),
                  deskPoint.X,
                  new Duration(TimeSpan.FromMilliseconds(_secNumber))
                );
                Storyboard.SetTarget(doubleAnimation, ellCrab[i]);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
                storyboard.Children.Add(doubleAnimation);

                //动画播放
                storyboard.Begin();
                if (deskPoint.X >= 400)
                {
                    Canvas.Children.Remove(ellCrab[i]);
                    myBlood.blood -= 200;
                }
                if (myBlood.blood <= 0)
                {
                    timer.Stop();
                    gameOver();
                }
            }
            #endregion

            #region 烤乳鸽
            if (time % 3 == 0 && totalNum < 50)
            {
                //MessageBox.Show("YYY");
                var brush = new ImageBrush(birdImage.Source); //定义图片画刷
                Ellipse temp = new Ellipse();
                temp.Width = 50;
                temp.Height = 40;
                temp.Fill = brush;
                ellBird.Add(temp);
                Canvas.Children.Add(ellBird[birdNum]);
                Random ran = new Random();
                int RandKey = ran.Next(50, 350);
                Canvas.SetLeft(ellBird[birdNum], RandKey);
                Canvas.SetTop(ellBird[birdNum], 0);
                ellBird[birdNum].MouseDown += new MouseButtonEventHandler(elips_MouseDown3);
                birdNum++;
                totalNum++;
            }

            for (int i = 0; i < ellBird.Count(); i++)
            {
                Point curPoint = new Point();
                curPoint.X = Canvas.GetLeft(ellBird[i]);
                curPoint.Y = Canvas.GetTop(ellBird[i]);
                double x = 350 - curPoint.X;
                double y = 560 - curPoint.Y;
                double k = y / x;
                double z = System.Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));
                Point deskPoint = curPoint;
                deskPoint.X = System.Math.Sqrt(2500 / (Math.Pow(k, 2) + 1)) + curPoint.X;
                deskPoint.Y = k * (deskPoint.X - curPoint.X) + curPoint.Y; 

                double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));
                double _secNumber = (_s / 1000) * 500;

                Storyboard storyboard = new Storyboard();

                //创建X轴方向动画
                DoubleAnimation doubleAnimation = new DoubleAnimation(
                  Canvas.GetLeft(ellBird[i]),
                  deskPoint.X,
                  new Duration(TimeSpan.FromMilliseconds(_secNumber))
                );
                Storyboard.SetTarget(doubleAnimation, ellBird[i]);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
                storyboard.Children.Add(doubleAnimation);

                //创建Y轴方向动画
                doubleAnimation = new DoubleAnimation(
                  Canvas.GetTop(ellBird[i]),
                  deskPoint.Y,
                  new Duration(TimeSpan.FromMilliseconds(_secNumber))
                );
                Storyboard.SetTarget(doubleAnimation, ellBird[i]);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
                storyboard.Children.Add(doubleAnimation);

                //动画播放
                storyboard.Begin();
                if (deskPoint.X >= 400)
                {
                    Canvas.Children.Remove(ellBird[i]);
                 
                    myBlood.blood -= 100;
                }
                else if (deskPoint.Y >= 600)
                {
                    Canvas.Children.Remove(ellBird[i]);
                    myBlood.blood -= 100;
                }
                if (myBlood.blood <= 0)
                {
                    timer.Stop();
                    gameOver();
                }
            }
            #endregion

            #region 苦蛇胆
            if (time % 5 == 0 && totalNum < 50)
            {
                //MessageBox.Show("YYY");
                var brush = new ImageBrush(snakeImage.Source); //定义图片画刷
                Ellipse temp = new Ellipse();
                temp.Width = 40;
                temp.Height = 50;
                temp.Fill = brush;
                ellSnake.Add(temp);
                Canvas.Children.Add(ellSnake[snakeNum]);
                Random ran = new Random();
                int RandKey = ran.Next(0, 350);
                Canvas.SetLeft(ellSnake[snakeNum], RandKey);
                Canvas.SetTop(ellSnake[snakeNum], 0);
                ellSnake[snakeNum].MouseDown += new MouseButtonEventHandler(elips_MouseDown4);
                snakeNum++;
                totalNum++;
            }

            for (int i = 0; i < ellSnake.Count(); i++)
            {
                Point curPoint = new Point();
                curPoint.X = Canvas.GetLeft(ellSnake[i]);
                curPoint.Y = Canvas.GetTop(ellSnake[i]);
                Point deskPoint = curPoint;
                if ((i + time) % 2 == 1)
                {
                    deskPoint.X = curPoint.X + 10;
                    deskPoint.Y = curPoint.Y + 10;
                }
                else
                {
                    deskPoint.X = curPoint.X - 10;
                    deskPoint.Y = curPoint.Y + 10;
                }
                

                double _s = System.Math.Sqrt(Math.Pow((deskPoint.X - curPoint.X), 2) + Math.Pow((deskPoint.Y - curPoint.Y), 2));
                double _secNumber = (_s / 1000) * 500;

                Storyboard storyboard = new Storyboard();

                //创建X轴方向动画
                DoubleAnimation doubleAnimation = new DoubleAnimation(
                  Canvas.GetLeft(ellSnake[i]),
                  deskPoint.X,
                  new Duration(TimeSpan.FromMilliseconds(_secNumber))
                );
                Storyboard.SetTarget(doubleAnimation, ellSnake[i]);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
                storyboard.Children.Add(doubleAnimation);

                //创建Y轴方向动画
                doubleAnimation = new DoubleAnimation(
                  Canvas.GetTop(ellSnake[i]),
                  deskPoint.Y,
                  new Duration(TimeSpan.FromMilliseconds(_secNumber))
                );
                Storyboard.SetTarget(doubleAnimation, ellSnake[i]);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
                storyboard.Children.Add(doubleAnimation);

                //动画播放
                storyboard.Begin();
                if (deskPoint.Y >= 600)
                {
                    Canvas.Children.Remove(ellBird[i]);
                    myBlood.blood -= 500;
                }
                if (myBlood.blood <= 0)
                {
                    timer.Stop();
                    gameOver();
                }
            }
            #endregion

            #region 数量超过50结束游戏
            if (totalNum >= 50 && clearNum == 50)
            {
                if (myBlood.blood >= 9000)
                {
                    MessageBox.Show("恭喜过关,奖励:★★★");
                    flag = 1;
                    gameOver();
                }
                else if (myBlood.blood >= 6000)
                {
                    MessageBox.Show("恭喜过关,奖励:★★");
                    flag = 1;
                    gameOver();
                }
                else
                {
                    MessageBox.Show("恭喜过关,奖励:★");
                    flag = 1;
                    gameOver();
                }
            }
            #endregion
        }

        private void elips_MouseDown4(object sender, MouseButtonEventArgs e)
        {
            clearNum++;
            Ellipse thisElips = sender as Ellipse;
            ellSnake.Remove(thisElips);
            snakeNum--;
            Canvas.Children.Remove(thisElips);
        }

        private void elips_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            clearNum++;
            Ellipse thisElips = sender as Ellipse;
            ellBird.Remove(thisElips);
            birdNum--;
            Canvas.Children.Remove(thisElips);
        }

        private void elips_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            clearNum++;
            Ellipse thisElips = sender as Ellipse;
            ellCrab.Remove(thisElips);
            crabNum--;
            Canvas.Children.Remove(thisElips);
        }

        private void elips_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            clearNum++;
            Ellipse thisElips = sender as Ellipse;
            ellPig.Remove(thisElips);
            pigNum--;
            Canvas.Children.Remove(thisElips);
        }

        private void gameOver()
        {
            timer.Stop();
            if (flag == 0)
            {
                MessageBox.Show("游戏结束！(题主女儿痛哭流涕)");
            }
            myBlood.blood = 10000;
            Canvas.Children.Clear();
            return;
        }
    }
}