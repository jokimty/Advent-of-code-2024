namespace _1a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalDistance = 0;
            List<int> firstList = new List<int>();
            List<int> secondList = new List<int>();

            ProcessInput(firstList, secondList);
            MyBubbleSort(firstList);
            MyBubbleSort(secondList);

            // C# has a "zip" operation which is cool.

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
        static void ProcessInput(List<int> list1, List<int> list2)
        {
            // Path: \AdventOfCode2024\1_C#\a\inputs.txt
            // This is where i need to turn the very long text file into two seperate lists...
            string path = Directory.GetCurrentDirectory();
            int pathIndex = path.Length - 19;
            path = path.Remove(pathIndex);
            path += "inputs.txt";
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string line = streamReader.ReadLine();
                string[] splitString;
                while (line != null)
                {
                    splitString = line.Split(null);
                    list1.Add(Convert.ToInt32(splitString[0]));
                    list2.Add(Convert.ToInt32(splitString[3])); // 3 because 1 & 2 are empty spaces.
                    line = streamReader.ReadLine();

                }
                streamReader.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
