public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        // Each row index maps to a set of digits already seen in that row.
        Dictionary<int, HashSet<char>> digitsSeenInRows =
            new Dictionary<int, HashSet<char>>();

        // Each column index maps to a set of digits already seen in that column.
        Dictionary<int, HashSet<char>> digitsSeenInColumns =
            new Dictionary<int, HashSet<char>>();

        // Each (box row, box column) pair maps to digits already seen in that 3x3 box.
        // Example: boxCoordinates (0,0) represents the top-left 3x3 box.
        Dictionary<(int, int), HashSet<char>> digitsSeenInBoxes =
            new Dictionary<(int, int), HashSet<char>>();

        // Visit every cell using its row and column indexes.
        for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
        {
            for (int columnIndex = 0;
                 columnIndex < board[rowIndex].Length;
                 columnIndex++)
            {
                // Store the current cell so we don't repeatedly write board[rowIndex][columnIndex].
                char currentDigit = board[rowIndex][columnIndex];

                // Empty cells do not count as Sudoku digits, so skip them.
                if (currentDigit == '.')
                {
                    continue;
                }

                // Give this row its own empty set the first time we encounter a digit in it.
                if (!digitsSeenInRows.ContainsKey(rowIndex))
                {
                    digitsSeenInRows.Add(rowIndex, new HashSet<char>());
                }

                // Give this column its own empty set the first time we encounter a digit in it.
                if (!digitsSeenInColumns.ContainsKey(columnIndex))
                {
                    digitsSeenInColumns.Add(columnIndex, new HashSet<char>());
                }

                // Integer division groups indexes 0-2 → 0, 3-5 → 1, and 6-8 → 2.
                // Combining the row group and column group uniquely identifies one 3x3 box.
                (int, int) boxCoordinates =
                    (rowIndex / 3, columnIndex / 3);

                // Give this 3x3 box its own empty set the first time we encounter a digit in it.
                if (!digitsSeenInBoxes.ContainsKey(boxCoordinates))
                {
                    digitsSeenInBoxes.Add(
                        boxCoordinates,
                        new HashSet<char>()
                    );
                }

                // Check BEFORE adding: if the digit is already in any set, it is a duplicate.
                if (digitsSeenInRows[rowIndex].Contains(currentDigit))
                {
                    return false;
                }

                if (digitsSeenInColumns[columnIndex].Contains(currentDigit))
                {
                    return false;
                }

                if (digitsSeenInBoxes[boxCoordinates].Contains(currentDigit))
                {
                    return false;
                }

                // No duplicate was found, so remember this digit in all three locations.
                digitsSeenInRows[rowIndex].Add(currentDigit);
                digitsSeenInColumns[columnIndex].Add(currentDigit);
                digitsSeenInBoxes[boxCoordinates].Add(currentDigit);
            }
        }

        // Every non-empty cell passed all three duplicate checks.
        return true;
    }
}