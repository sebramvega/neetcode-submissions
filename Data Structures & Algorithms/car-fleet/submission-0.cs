public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        // Keep each car's position and speed together.
        (int position, int speed)[] cars = new (int, int)[position.Length];

        for (int i = 0; i < position.Length; i++)
        {
            cars[i] = (position[i], speed[i]);
        }

        // Sort cars by position from closest to target to farthest.
        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

        int fleets = 0;

        // Keeps track of the arrival time of the fleet ahead.
        double previousTime = 0;

        for (int i = 0; i < cars.Length; i++)
        {
            // Calculate how long this car would take to reach the target.
            double currentTime =
                (double)(target - cars[i].position) / cars[i].speed;

            // If it arrives later than the fleet ahead, it cannot catch it.
            if (currentTime > previousTime)
            {
                fleets++;
                previousTime = currentTime;
            }

            // Otherwise, it catches the fleet ahead and joins it.
        }

        return fleets;
    }
}