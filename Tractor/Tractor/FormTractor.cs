namespace Tractor
{
    public partial class FormTractor : Form
    {
        private DrawingTractor _tractor;
        public FormTractor()
        {
            InitializeComponent();
        }
        //метод отрисовки
        private void Draw()
        {
            Bitmap bmp = new(pictureBoxTractor.Width, pictureBoxTractor.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _tractor?.DrawTransport(gr);
            pictureBoxTractor.Image = bmp;
        }
        //кнопка создания
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random random = new();
            _tractor = new DrawingTractor();
            _tractor.Init(random.Next(30, 50), random.Next(1000, 2000), 
                Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
            _tractor.SetPosition(random.Next(10, 100), random.Next(10, 100), 
                pictureBoxTractor.Width, pictureBoxTractor.Height);
            toolStripStatusLabelSpeed.Text = $"Скорость: {_tractor.Tractor.Speed}";
            toolStripStatusLabelWeight.Text = $"Вес: {_tractor.Tractor.Weight}";
            toolStripStatusLabelBodyColor.Text = $"Цвет: {_tractor.Tractor.BodyColor.Name}";
            Draw();
        }
        //кнопки передвижения
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            //?? - если то, что слева, не равно нулю,
            //используйте это, иначе используйте то, что справа
            string name = ((Button)sender)?.Name ?? string.Empty;
            switch (name)
            {
                //все со знаком вопроса для того,
                //если мы кликнули до создания объекта
                case "buttonUp":
                    _tractor?.MoveTransport(Enumeration.Up);
                    break;
                case "buttonDown":
                    _tractor?.MoveTransport(Enumeration.Down);
                    break;
                case "buttonLeft":
                    _tractor?.MoveTransport(Enumeration.Left);
                    break;
                case "buttonRight":
                    _tractor?.MoveTransport(Enumeration.Right);
                    break;
            }
            Draw();
        }
        //изменение размеров окошка
        private void PictureBoxTractor_Resize(object sender, EventArgs e)
        {
            _tractor?.ChangeBorders(pictureBoxTractor.Width, pictureBoxTractor.Height);
            Draw();
        }
    }
}