using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PracticalWork15
{
    public partial class MainWindow : Window
    {
        private readonly Color[] colors = {
            Colors.Red, Colors.Green, Colors.Blue,
            Colors.Yellow, Colors.Purple, Colors.Orange
        };

        private Random random = new Random();
        private DispatcherTimer garlandTimer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGarlandTimer();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Border border)
            {
                Point clickPosition = e.GetPosition(border);

                Button newButton = new Button
                {
                    Content = $"Кнопка {DateTime.Now:HH:mm:ss}",
                    Width = 120,
                    Height = 40,
                    Background = new SolidColorBrush(GetRandomColor()),
                    Foreground = Brushes.White,
                    FontWeight = FontWeights.Bold
                };

                Canvas.SetLeft(newButton, clickPosition.X - newButton.Width / 2);
                Canvas.SetTop(newButton, clickPosition.Y - newButton.Height / 2);

                newButton.Click += (s, args) =>
                {
                    if (s is Button btn)
                    {
                        var parent = btn.Parent as Panel;
                        parent?.Children.Remove(btn);
                    }
                };

                if (!(border.Child is Canvas canvas))
                {
                    canvas = new Canvas();
                    border.Child = canvas;

                    TextBlock instruction = new TextBlock
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 14,
                        Foreground = Brushes.DarkGray
                    };
                    canvas.Children.Add(instruction);
                }

                (border.Child as Canvas).Children.Add(newButton);
            }
        }

        private void InitializeGarlandTimer()
        {
            garlandTimer = new DispatcherTimer();
            garlandTimer.Interval = TimeSpan.FromMilliseconds(300);
            garlandTimer.Tick += GarlandTimer_Tick;
        }

        private void CreateGarland_Click(object sender, RoutedEventArgs e)
        {
            GarlandPanel.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                Button garlandButton = new Button
                {
                    Content = $"Btn {i + 1}",
                    Width = 80,
                    Height = 40,
                    Margin = new Thickness(5),
                    FontWeight = FontWeights.Bold,
                    Tag = i
                };

                GarlandPanel.Children.Add(garlandButton);
            }

            UpdateGarlandColors();
            garlandTimer.Start();
        }

        private void GarlandTimer_Tick(object sender, EventArgs e)
        {
            UpdateGarlandColors();
        }

        private void UpdateGarlandColors()
        {
            Color previousColor = Colors.Transparent;

            foreach (Button button in GarlandPanel.Children)
            {
                Color newColor;
                do
                {
                    newColor = GetRandomColor();
                } while (newColor == previousColor); // Соседние цвета не должны совпадать

                button.Background = new SolidColorBrush(newColor);
                button.Foreground = GetContrastColor(newColor);
                previousColor = newColor;
            }
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            MoveObject(0, -10);
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            MoveObject(0, 10);
        }

        private void MoveLeft_Click(object sender, RoutedEventArgs e)
        {
            MoveObject(-10, 0);
        }

        private void MoveRight_Click(object sender, RoutedEventArgs e)
        {
            MoveObject(10, 0);
        }

        private void MoveObject(double deltaX, double deltaY)
        {
            double newX = Canvas.GetLeft(MovableObject) + deltaX;
            double newY = Canvas.GetTop(MovableObject) + deltaY;

            // Проверяем границы Canvas
            if (newX >= 0 && newX <= MovementCanvas.ActualWidth - MovableObject.Width)
            {
                Canvas.SetLeft(MovableObject, newX);
            }

            if (newY >= 0 && newY <= MovementCanvas.ActualHeight - MovableObject.Height)
            {
                Canvas.SetTop(MovableObject, newY);
            }
        }

        private Color GetRandomColor()
        {
            return colors[random.Next(colors.Length)];
        }

        private Brush GetContrastColor(Color backgroundColor)
        {
            double luminance = (0.299 * backgroundColor.R + 0.587 * backgroundColor.G + 0.114 * backgroundColor.B) / 255;
            return luminance > 0.5 ? Brushes.Black : Brushes.White;
        }

        protected override void OnClosed(EventArgs e)
        {
            garlandTimer?.Stop();
            base.OnClosed(e);
        }
    }
}