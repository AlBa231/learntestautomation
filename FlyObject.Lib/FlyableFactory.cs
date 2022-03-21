namespace FlyObject.Lib
{
    public static class FlyableFactory
    {
        /// <summary>
        /// Return flyable from index
        /// 1 - Bird
        /// 2 - Plane
        /// 3 - Drone
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IFlyable GetFlyable(int index)
        {
            return index switch
            {
                1 => new Bird { Speed = Random.Shared.Next(20) },
                2 => new Plane(),
                3 => new Drone(),
                _ => throw new FlyableException("Invalid flyable, can be 1 (bird), 2 (plane), or 3 (drone)")
            };
        }


        /// <summary>
        /// Return flyable from index (as char type).
        /// 1 - Bird
        /// 2 - Plane
        /// 3 - Drone
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IFlyable GetFlyable(char index)
        {
            try
            {
                var selectorInt = (int)char.GetNumericValue(index);

                return GetFlyable(selectorInt);
            }
            catch (FlyableException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new FlyableException("Invalid flyable index - " + index, e);
            }
        }
    }
}
