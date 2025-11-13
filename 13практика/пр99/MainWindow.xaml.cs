using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;

namespace np9
{
    public partial class MainWindow : Window
    {
        private FontFamily currentFontFamily = new FontFamily("Arial");
        private double currentFontSize = 12;
        private Brush currentTextColor = Brushes.Black;
        private Brush currentBackgroundColor = Brushes.White;
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFonts();
        }

        private void InitializeFonts()
        {
            
            fontComboBox.Items.Add("Arial");
            fontComboBox.Items.Add("Times New Roman");
            fontComboBox.Items.Add("Courier New");
            fontComboBox.Items.Add("Verdana");
            fontComboBox.Items.Add("Tahoma");
            fontComboBox.SelectedIndex = 0;

            fontSizeComboBox.Items.Add("8");
            fontSizeComboBox.Items.Add("10");
            fontSizeComboBox.Items.Add("12");
            fontSizeComboBox.Items.Add("14");
            fontSizeComboBox.Items.Add("16");
            fontSizeComboBox.Items.Add("18");
            fontSizeComboBox.Items.Add("20");
            fontSizeComboBox.Items.Add("24");
            fontSizeComboBox.SelectedIndex = 2;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run("Начните вводить текст...")));
        }

        private void ApplyFormatting()
        {
            if (richTextBox.Selection.IsEmpty)
                return;

            TextSelection selection = richTextBox.Selection;
            selection.ApplyPropertyValue(TextElement.FontFamilyProperty, currentFontFamily);
            selection.ApplyPropertyValue(TextElement.FontSizeProperty, currentFontSize);
            selection.ApplyPropertyValue(TextElement.ForegroundProperty, currentTextColor);
            selection.ApplyPropertyValue(TextElement.BackgroundProperty, currentBackgroundColor);

            selection.ApplyPropertyValue(TextElement.FontWeightProperty,
                isBold ? FontWeights.Bold : FontWeights.Normal);
            selection.ApplyPropertyValue(TextElement.FontStyleProperty,
                isItalic ? FontStyles.Italic : FontStyles.Normal);

            if (isUnderline)
                selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
                selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
        }

        private void шрифтToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            fontComboBox.IsDropDownOpen = true;
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowColorDialog(true);
        }

        private void цветФонаToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowColorDialog(false);
        }

        private void ShowColorDialog(bool isTextColor)
        {
            var colorWindow = new Window
            {
                Title = isTextColor ? "Выберите цвет текста" : "Выберите цвет фона",
                Width = 300,
                Height = 350,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };

            var stackPanel = new StackPanel { Margin = new Thickness(10) };

           
            var title = new TextBlock
            {
                Text = isTextColor ? "Цвет текста:" : "Цвет фона:",
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(title);

       
            var colors = new[]
            {
                new { Name = "Черный", Color = Colors.Black },
                new { Name = "Белый", Color = Colors.White },
                new { Name = "Красный", Color = Colors.Red },
                new { Name = "Зеленый", Color = Colors.Green },
                new { Name = "Синий", Color = Colors.Blue },
                new { Name = "Желтый", Color = Colors.Yellow },
                new { Name = "Оранжевый", Color = Colors.Orange },
                new { Name = "Фиолетовый", Color = Colors.Purple },
                new { Name = "Серый", Color = Colors.Gray },
                new { Name = "Коричневый", Color = Colors.Brown }
            };

            foreach (var colorInfo in colors)
            {
                var button = new Button
                {
                    Content = colorInfo.Name,
                    Background = new SolidColorBrush(colorInfo.Color),
                    Foreground = colorInfo.Color == Colors.Black ? Brushes.White : Brushes.Black,
                    Margin = new Thickness(5),
                    Height = 30,
                    Tag = colorInfo.Color
                };

                button.Click += (s, args) =>
                {
                    if (isTextColor)
                        currentTextColor = new SolidColorBrush((Color)button.Tag);
                    else
                        currentBackgroundColor = new SolidColorBrush((Color)button.Tag);

                    ApplyFormatting();
                    colorWindow.Close();
                };

                stackPanel.Children.Add(button);
            }

           
            var cancelButton = new Button
            {
                Content = "Отмена",
                Margin = new Thickness(5, 15, 5, 5),
                Height = 30
            };
            cancelButton.Click += (s, e) => colorWindow.Close();
            stackPanel.Children.Add(cancelButton);

            colorWindow.Content = new ScrollViewer
            {
                Content = stackPanel,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };

            colorWindow.ShowDialog();
        }

        private void полужирныйToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            isBold = !isBold;
            ApplyFormatting();
        }

        private void курсивToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            isItalic = !isItalic;
            ApplyFormatting();
        }

        private void подчеркнутыйToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            isUnderline = !isUnderline;
            ApplyFormatting();
        }

       
        private void fontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontComboBox.SelectedItem != null)
            {
                currentFontFamily = new FontFamily(fontComboBox.SelectedItem.ToString());
                ApplyFormatting();
            }
        }

        private void fontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontSizeComboBox.SelectedItem != null &&
                double.TryParse(fontSizeComboBox.SelectedItem.ToString(), out double size))
            {
                currentFontSize = size;
                ApplyFormatting();
            }
        }

        private void boldButton_Click(object sender, RoutedEventArgs e)
        {
            isBold = !isBold;
            ApplyFormatting();
        }

        private void italicButton_Click(object sender, RoutedEventArgs e)
        {
            isItalic = !isItalic;
            ApplyFormatting();
        }

        private void underlineButton_Click(object sender, RoutedEventArgs e)
        {
            isUnderline = !isUnderline;
            ApplyFormatting();
        }

        private void textColorButton_Click(object sender, RoutedEventArgs e)
        {
            цветТекстаToolStripMenuItem_Click(sender, e);
        }

        private void bgColorButton_Click(object sender, RoutedEventArgs e)
        {
            цветФонаToolStripMenuItem_Click(sender, e);
        }

       
        private void открытьToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Файлы RTF (*.rtf)|*.rtf|All files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(openFileDialog1.FileName)) return;

                try
                {
                    string extension = System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower();

                    if (extension == ".rtf")
                    {
                       
                        TextRange range = new TextRange(richTextBox.Document.ContentStart,
                                                       richTextBox.Document.ContentEnd);
                        using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                        {
                            range.Load(fs, DataFormats.Rtf);
                        }
                    }
                    else
                    {
                       
                        using (var читатель = new StreamReader(openFileDialog1.FileName, Encoding.UTF8))
                        {
                            richTextBox.Document.Blocks.Clear();
                            richTextBox.Document.Blocks.Add(new Paragraph(new Run(читатель.ReadToEnd())));
                        }
                    }
                }
                catch (System.IO.FileNotFoundException ситуация)
                {
                    MessageBox.Show(ситуация.Message + "\nНет такого файла",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ситуация)
                {
                    MessageBox.Show(ситуация.Message,
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Файлы RTF (*.rtf)|*.rtf|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = ".rtf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                try
                {
                    string extension = System.IO.Path.GetExtension(saveFileDialog1.FileName).ToLower();

                    if (extension == ".rtf")
                    {
                      
                        TextRange range = new TextRange(richTextBox.Document.ContentStart,
                                                       richTextBox.Document.ContentEnd);
                        using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                        {
                            range.Save(fs, DataFormats.Rtf);
                        }
                    }
                    else
                    {
                       
                        TextRange range = new TextRange(richTextBox.Document.ContentStart,
                                                       richTextBox.Document.ContentEnd);
                        using (var писатель = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))
                        {
                            писатель.Write(range.Text);
                        }
                    }

                    MessageBox.Show("Файл успешно сохранен!", "Сохранение",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ситуация)
                {
                    MessageBox.Show(ситуация.Message,
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}