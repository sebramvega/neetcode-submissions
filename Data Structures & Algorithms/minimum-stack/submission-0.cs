public class MinStack
{
    // Stores the actual values pushed onto the MinStack.
    private Stack<int> valueStack;

    // Stores the minimum value at each corresponding level of valueStack.
    private Stack<int> minimumStack;

    public MinStack()
    {
        // Initialize both stacks when the MinStack object is created.
        valueStack = new Stack<int>();
        minimumStack = new Stack<int>();
    }

    public void Push(int val)
    {
        // Always push the actual value onto the main stack.
        valueStack.Push(val);

        // If this is the first value, it is automatically the minimum.
        if (minimumStack.Count == 0)
        {
            minimumStack.Push(val);
        }
        else
        {
            // Store whichever is smaller: the new value or the previous minimum.
            // This means minimumStack.Peek() always gives the current minimum.
            minimumStack.Push(Math.Min(val, minimumStack.Peek()));
        }
    }

    public void Pop()
    {
        // Pop both stacks so their corresponding levels stay synchronized.
        valueStack.Pop();
        minimumStack.Pop();
    }

    public int Top()
    {
        // Return the actual value currently at the top of the stack.
        return valueStack.Peek();
    }

    public int GetMin()
    {
        // The top of minimumStack always stores the current minimum.
        return minimumStack.Peek();
    }
}
