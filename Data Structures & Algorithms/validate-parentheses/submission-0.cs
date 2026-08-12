public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> openBrackets = new Stack<char>();

        foreach (char currentChar in s)
        {
            // Store opening brackets so they can be matched later.
            if (currentChar == '(' || currentChar == '[' || currentChar == '{')
            {
                openBrackets.Push(currentChar);
            }
            else
            {
                // A closing bracket cannot match if there are no open brackets.
                if (openBrackets.Count == 0)
                {
                    return false;
                }

                // Remove the most recent opening bracket so we can check for a match.
                char lastOpenBracket = openBrackets.Pop();

                // The closing bracket must match the most recent opening bracket.
                if (currentChar == ')' && lastOpenBracket != '(' ||
                    currentChar == ']' && lastOpenBracket != '[' ||
                    currentChar == '}' && lastOpenBracket != '{')
                {
                    return false;
                }
            }
        }

        // The string is valid only if every opening bracket was closed.
        return openBrackets.Count == 0;
    }
}