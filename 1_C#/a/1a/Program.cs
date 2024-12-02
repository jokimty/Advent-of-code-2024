namespace _1a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalDistance = 0;
            List<int> firstList = new List<int>() {1,4,66};
            List<int> secondList = new List<int>() {62,6,2};

            MyBubbleSort(firstList);
            MyBubbleSort(secondList);

            firstList.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("");
            secondList.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("");

            // C# has a "zip" operation which I will try using!

            var zippedLists = firstList.Zip(secondList); // ZippedLists is now a list of tuples with two ints in each tuple!
            foreach ((int, int) i in zippedLists)
            {
                if (i.Item1 > i.Item2)
                {
                    totalDistance += i.Item1 - i.Item2;
                }
                else
                {
                    totalDistance += i.Item2 - i.Item1;

                }
                Console.WriteLine(Convert.ToString(i));
            }
            Console.WriteLine(totalDistance);
        }
        static void MyBubbleSort(List<int> list)
        {
            // Simple and inefficient bubblesort, good enough for this purpose.
            // Takes a list<int> and sorts it. Inital state of the list is lost.
            int tempInt;
            bool sorted = false;
            int counter = 0;
            int listLength = list.Count();

            while (!sorted)
            {
                for (int i = 1; i < listLength - counter; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        tempInt = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = tempInt;
                    }
                }
                counter++;
                if (counter == listLength) { sorted = true; }
            }
        }
        static void ProcessInput(string input)
        {
            // Path: \AdventOfCode2024\1_C#\a\inputs.txt
            //This is where i need to turn the very long text file into two seperate lists...
        }

    }
}
