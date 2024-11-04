public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create a new array of the specified length
        double[] multiples = new double[length];

        // Iterate and calculate multiples, considering the sign of 'number'
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Edge case: If amount is equal to data.Count, no rotation is needed
        amount %= data.Count;

        // Reverse the entire list
        Reverse(data, 0, data.Count - 1);

        // Reverse the first 'amount' elements
        Reverse(data, 0, amount - 1);

        // Reverse the remaining elements
        Reverse(data, amount, data.Count - 1);
    }

//Reverse the entire list so the last elements are at the beginning
private static void Reverse(List<int> data, int start, int end)
    {
        // While the start index is less than the end index, continue swapping
        while (start < end)
        {
            // Swap the elements at the start and end indices
            int temp = data[start];
            data[start] = data[end];
            data[end] = temp;
             // Move the start index forward and the end index backward
            start++;
            end--;
        }
    }

}