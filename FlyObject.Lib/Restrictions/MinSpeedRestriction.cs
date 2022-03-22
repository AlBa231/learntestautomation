using FlyObject.Lib.Models;

namespace FlyObject.Lib.Restrictions
{
    public class MinSpeedRestriction: IRestriction
    {
        public int MinimalSpeed { get; }
        public string? ErrorMessage { get; private set; }
        public string Description => MinimalSpeed.ToString("0.#");

        public MinSpeedRestriction(int minimalSpeed)
        {
            MinimalSpeed = minimalSpeed;
        }

        public bool Validate(Flyable flyable)
        {
            if (flyable.Speed < MinimalSpeed)
            {
                ErrorMessage = $"Speed {flyable.Speed} is less than {MinimalSpeed}.";
                return false;
            }
            return true;
        }
    }
}
