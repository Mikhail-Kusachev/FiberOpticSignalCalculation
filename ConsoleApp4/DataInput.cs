using System.Text.RegularExpressions;

namespace SignalPowerCalculator
{
    internal class DataInput
    {
        public List<double> AskForDoubleList(string varName)
        {
            return AskForDoubleList(varName, 0);
        }

        public List<double> AskForDoubleList(string varName, int arraySize)
        {
            var result = new List<double>();
            string? input;
            bool isCorrectInput = false;
            bool isAllPositive = true;
            while (!isCorrectInput)
            {
                string arraySizeString = "";
                if (arraySize == 0)
                    arraySizeString = "any";
                else if (arraySize > 0)
                    arraySizeString = arraySize.ToString();
                else
                    Console.WriteLine("debug: arraySize can't be less than 0 during AskForDoubleList()");
                Console.WriteLine($"enter {varName} float {arraySizeString}-length array with space separator " +
                        "and press enter (example \"0.1 0.1 0.1\" or \"1 2 3\"): ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;
                NormalizeFloatArrayString(ref input);
                try
                {
                    result = input.Split(' ').Select(n => Convert.ToDouble(n)).ToList();
                }
                catch (Exception e)
                {
                    if (e.GetType().Name == "FormatException")
                        Console.WriteLine("wrong input");
                    else
                        Console.WriteLine($"debug: exeption {e.GetType().Name} during AskForDoubleList()");
                    continue;
                }
                isAllPositive = true;
                foreach (double d in result)
                    if (d <= 0)
                    {
                        Console.WriteLine($"in real world system {varName} can't be negative or 0");
                        isAllPositive = false;
                        break;
                    }
                if ((result.Count == arraySize || arraySize == 0) && isAllPositive)
                    isCorrectInput = true;
            }
            return result;
        }

        private void NormalizeFloatArrayString(ref string input)
        {
            input = input.Replace(',', '.');
            input = Regex.Replace(input, @"\s+$", "");
        }
    }
}
