namespace MyLinq;

public static partial class MyLinq
{
    public static double MyAverage(this IEnumerable<int> collection)
    {
        int count = 0;
        double sum = 0;

        foreach (int item in collection)
        {
            sum += item;
            count++;
        }

        return sum / count;
    }
}
