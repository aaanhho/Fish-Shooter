using FishShooting;

namespace FishShooting
{
    public interface IMove
    {
        // Objects need to know X coordinate since they all go left
        public float X { get; set; }
        
        // Method for objects to move left
        public void MoveLeft(float Speed);
    }
}