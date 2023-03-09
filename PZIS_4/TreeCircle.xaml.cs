using System.Numerics;
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
    }
}
