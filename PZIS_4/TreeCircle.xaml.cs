using System.Numerics;
using System.Windows.Controls;

namespace PZIS_4
{
    /// <summary>
    /// Логика взаимодействия для TreeCircle.xaml
    /// </summary>
    public partial class TreeCircle : UserControl
    {
        public const int CircleRadius = 15;

        private Vector2 center = Vector2.Zero;

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

        public TreeCircle()
        {
            InitializeComponent();
        }
    }
}
