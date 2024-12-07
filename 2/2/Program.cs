namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lineList = new List<string>();
            ProcessInput(lineList);
            bool safe;
            int counter = 0;
            foreach (string line in lineList) 
            {
                safe = CheckLine(line);
                if (safe) { counter++; }
            }
            Console.WriteLine(counter);
        }
        static bool CheckLine(string line)
        {
            string[] lines = line.Split(" ");
            int difference;
            bool? ascending = null;
            for (int i = 1; i < lines.Length; i++)
            {
                difference = Convert.ToInt32(lines[i - 1]) - Convert.ToInt32(lines[i]);
                if (Math.Abs(difference) > 3 || difference == 0)
                {
                    return false;
                }
                if (ascending == null)
                {
                    if (difference < 0) { ascending = true; }
                    else { ascending = false; }
                }
                else
                {
                    if(ascending != difference < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static void ProcessInput(List<string> list)
        {
            // Path: \AdventOfCode2024\2\inputs.z1
            // This will only process it into a list of strings, the actual convertion to integers will happen later.

            string path = Directory.GetCurrentDirectory();
            int pathIndex = path.Length - 18;
            path = path.Remove(pathIndex);
            path += "inputs.txt";
            try
            {
                StreamReader streamReader = new StreamReader(path);
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    list.Add(line);
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
