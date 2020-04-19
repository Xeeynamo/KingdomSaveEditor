using KHSave.LibFf7Remake.Models;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class PositionModel
    {
        private readonly Position _position;

        public PositionModel(Position position)
        {
            _position = position;
        }

        public float X { get => _position.X; set => _position.X = value; }
        public float Y { get => _position.Y; set => _position.Y = value; }
        public float Z { get => _position.Z; set => _position.Z = value; }
    }
}
