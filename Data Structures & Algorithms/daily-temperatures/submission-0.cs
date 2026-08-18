public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        // Store indexes of days still waiting to find a warmer future temperature.
        Stack<int> waitingDayIndexes = new Stack<int>();

        // result[i] stores how many days until a warmer temperature appears.
        // Unresolved days automatically remain 0.
        int[] result = new int[temperatures.Length];

        // Process each day's temperature from left to right.
        for (int currentDayIndex = 0;
             currentDayIndex < temperatures.Length;
             currentDayIndex++)
        {
            // If no previous days are waiting, add the current day's index.
            if (waitingDayIndexes.Count == 0)
            {
                waitingDayIndexes.Push(currentDayIndex);
                continue;
            }

            // Resolve every previous day whose temperature is lower than today's.
            while (
                waitingDayIndexes.Count > 0 &&
                temperatures[currentDayIndex] >
                temperatures[waitingDayIndexes.Peek()]
            )
            {
                // The top of the stack is a previous day waiting for a warmer day.
                int previousDayIndex = waitingDayIndexes.Peek();

                // Distance between the warmer day and the previous waiting day.
                result[previousDayIndex] =
                    currentDayIndex - previousDayIndex;

                // This previous day has now found its warmer temperature.
                waitingDayIndexes.Pop();
            }

            // The current day now waits for its own future warmer temperature.
            waitingDayIndexes.Push(currentDayIndex);
        }

        return result;
    }
}