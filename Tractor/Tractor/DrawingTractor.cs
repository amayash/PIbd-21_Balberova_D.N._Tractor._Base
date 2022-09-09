namespace Tractor
{
    internal class DrawingTractor
    {
        //класс-сущность. можно получать из него данные
        public EntityTractor Tractor { get; private set; }

        private float _startPosX;
        private float _startPosY;
        //вопрос - знак, что поля может не быть. отрисовать не сможем
        private int? _pictureWidth = null;
        private int? _pictureHeight = null;
        private readonly int _tractorWidth = 90;
        private readonly int _tractorHeight = 72;

        public void Init(int speed, float weight, Color bodyColor)
        {
            Tractor = new EntityTractor();
            Tractor.Init(speed, weight, bodyColor);
        }
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            // проверки
            if (width <= _tractorWidth + x) 
            {
                _pictureWidth = null;
                _pictureHeight = null;
                return;
            }
            if (height <= _tractorHeight + y)
            {
                _pictureWidth = null;
                _pictureHeight = null;
                return;
            }
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        // изменение направления перемещения
        public void MoveTransport(Enumeration enumeration)
        {
            if (!_pictureWidth.HasValue || !_pictureHeight.HasValue)
            {
                return;
            }
            switch (enumeration)
            {
                // вправо
                case Enumeration.Right:
                    if (_startPosX + _tractorWidth + Tractor.Step < _pictureWidth)
                    {
                        _startPosX += Tractor.Step;
                    }
                    break;
                //влево
                case Enumeration.Left:
                    if (_startPosX - Tractor.Step > 0)
                    {
                        _startPosX -= Tractor.Step;
                    }
                    break;
                //вверх
                case Enumeration.Up:
                    if (_startPosY - Tractor.Step > 0)
                    {
                        _startPosY -= Tractor.Step;
                    }
                    break;
                //вниз
                case Enumeration.Down:
                    if (_startPosY + _tractorHeight + Tractor.Step < _pictureHeight)
                    {
                        _startPosY += Tractor.Step;
                    }
                    break;
            }
        }
        // отрисовка
        public void DrawTransport(Graphics g)
        {
            if (_startPosX < 0 || _startPosY < 0
                || !_pictureHeight.HasValue || !_pictureWidth.HasValue)
            {
                return;
            }
            //цвет
            Brush br = new SolidBrush(Tractor?.BodyColor ?? Color.Black);
            g.FillRectangle(br, _startPosX + 10, _startPosY + 25, 78, 20);
            g.FillRectangle(br, _startPosX + 50, _startPosY, 38, 25);
            g.FillRectangle(br, _startPosX + 15, _startPosY, 5, 25);
            Pen pen = new(Color.Black);
            //границы 
            g.DrawEllipse(pen, _startPosX, _startPosY + 50, 20, 22);
            g.DrawEllipse(pen, _startPosX + 70, _startPosY + 50, 20, 22);
            g.DrawRectangle(pen, _startPosX + 10, _startPosY + 50, 70, 22);

            g.DrawRectangle(pen, _startPosX + 10, _startPosY + 25, 78, 20);
            g.DrawRectangle(pen, _startPosX + 50, _startPosY, 38, 25);
            g.DrawRectangle(pen, _startPosX + 15, _startPosY, 5, 25);
            //гусеница
            Brush brGray = new SolidBrush(Color.Gray);
            g.FillEllipse(brGray, _startPosX, _startPosY + 50, 20, 22);
            g.FillEllipse(brGray, _startPosX + 70, _startPosY + 50, 20, 22);
            g.FillRectangle(brGray, _startPosX + 10, _startPosY + 50, 70, 22);
            //катки в гусенице
            Pen fatPen = new(Color.Black, 3);
            g.DrawEllipse(fatPen, _startPosX + 2, _startPosY + 53, 15, 15);
            g.DrawEllipse(fatPen, _startPosX + 72, _startPosY + 53, 15, 15);
            g.DrawEllipse(fatPen, _startPosX + 22, _startPosY + 53, 5, 5);
            g.DrawEllipse(fatPen, _startPosX + 62, _startPosY + 53, 5, 5);
            g.DrawEllipse(fatPen, _startPosX + 32, _startPosY + 57, 10, 10);
            g.DrawEllipse(fatPen, _startPosX + 47, _startPosY + 57, 10, 10);
            
        }

        // смена границ формы отрисовки
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void ChangeBorders(int width, int height)
        {
            _pictureWidth = width;
            _pictureHeight = height;
            if (_pictureWidth <= _tractorWidth || _pictureHeight <= _tractorHeight)
            {
                _pictureWidth = null;
                _pictureHeight = null;
                return;
            }
            if (_startPosX + _tractorWidth > _pictureWidth)
            {
                _startPosX = _pictureWidth.Value - _tractorWidth;
            }
            if (_startPosY + _tractorHeight > _pictureHeight)
            {
                _startPosY = _pictureHeight.Value - _tractorHeight;
            }
        }
    }
}