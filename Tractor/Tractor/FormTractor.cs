namespace Tractor
{
    public partial class FormTractor : Form
    {
        private DrawingTractor _tractor;
        public FormTractor()
        {
            InitializeComponent();
        }
        //����� ���������
        private void Draw()
        {
            Bitmap bmp = new(pictureBoxTractor.Width, pictureBoxTractor.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _tractor?.DrawTransport(gr);
            pictureBoxTractor.Image = bmp;
        }
        //������ ��������
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            Random random = new();
            _tractor = new DrawingTractor();
            _tractor.Init(random.Next(30, 50), random.Next(1000, 2000), 
                Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
            _tractor.SetPosition(random.Next(10, 100), random.Next(10, 100), 
                pictureBoxTractor.Width, pictureBoxTractor.Height);
            toolStripStatusLabelSpeed.Text = $"��������: {_tractor.Tractor.Speed}";
            toolStripStatusLabelWeight.Text = $"���: {_tractor.Tractor.Weight}";
            toolStripStatusLabelBodyColor.Text = $"����: {_tractor.Tractor.BodyColor.Name}";
            Draw();
        }
        //������ ������������
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            //�������� ��� ������
            //?? - ���� ��, ��� �����, �� ����� ����,
            //����������� ���, ����� ����������� ��, ��� ������
            string name = ((Button)sender)?.Name ?? string.Empty;
            switch (name)
            {
                //��� �� ������ ������� ��� ����,
                //���� �� �������� �� �������� �������
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
        //��������� �������� ������
        private void PictureBoxTractor_Resize(object sender, EventArgs e)
        {
            _tractor?.ChangeBorders(pictureBoxTractor.Width, pictureBoxTractor.Height);
            Draw();
        }
    }
}