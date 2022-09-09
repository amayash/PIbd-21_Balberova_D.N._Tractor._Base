namespace Tractor
{
    //класс-сущность "трактор"
    internal class EntityTractor
    {
        //скорость
        public int Speed { get; private set; }
        //вес
        public float Weight { get; private set; }
        //цвет
        public Color BodyColor { get; private set; }
        //шаг. => - возвращает
        public float Step => Speed * 100 / Weight;
        //метод для инициализации полей объекта
        public void Init(int speed, float weight, Color bodyColor)
        {
            Random random = new();
            Speed = speed <= 0 ? random.Next(10, 50) : speed;
            Weight = weight <= 0 ? random.Next(40, 70) : weight;
            BodyColor = bodyColor;
        }
    }
}
