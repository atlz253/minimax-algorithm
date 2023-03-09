using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PZIS_4
{
    /// <summary>
    /// Логика взаимодействия для TreeCircle.xaml
    /// </summary>
    public partial class TreeCircle : UserControl
    {
        public const int CircleRadius = 17;

        private Vector2 center = Vector2.Zero;

        private Node? model;

        private int knocks = 0;

        /// <summary>
        /// Центр окружности
        /// </summary>
        public Vector2 Center
        {
            get => center;

            set
            {
                center = value;

                Canvas.SetLeft(this, center.X - CircleRadius);

                Canvas.SetTop(this, center.Y - CircleRadius);
            }
        }

        /// <summary>
        /// Модель узла
        /// </summary>
        public Node? Model
        {
            get => model;

            set
            {
                model = value;

                UpdateColor();

                idLabel.Content = model.Id;
            }
        }

        /// <summary>
        /// Поле для ввода значений
        /// </summary>
        public TextBox TextBox => textBox;

        /// <summary>
        /// Устанавливает цвет узла
        /// </summary>
        private void UpdateColor()
        {
            if (model == null)
            {
                return;
            }

            if (model.IsSolutionNode)
            {
                ellipse.Fill = Brushes.GreenYellow;
            }
            else if (model.IsSkiped)
            {
                ellipse.Fill = Brushes.Red;
            }
            else
            {
                ellipse.Fill = Brushes.LightGray;
            }
        }

        public TreeCircle()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Model == null)
            {
                return;
            }

            if (int.TryParse(textBox.Text, out int value))
            {
                Model.Value = value;
            }
            else if (textBox.Text == string.Empty)
            {
                Model.Value = 0;
            }
            else
            {
                textBox.Text = Model.Value.ToString();
            }
        }

        private void textBox_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!TextBox.IsReadOnly)
            {
                return;
            }

            knocks++;

            if (knocks != 8)
            {
                return;
            }

            MessageBox.Show("В дверь постучали 8 раз.\r\n\r\n- Осьминог, – догадался Штирлиц.\r\n\r\n- Программисты, которым нечем заняться, – парировал осьминог.");

            knocks = 0;
        }
    }
}
