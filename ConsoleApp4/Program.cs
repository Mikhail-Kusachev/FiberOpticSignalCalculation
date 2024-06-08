namespace SignalPowerCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataInput dataInput = new DataInput();
            ComplexMath complexMath = new ComplexMath();
            List<double> doubleListAI = dataInput.AskForDoubleList("Ai (dB)");
            List<double> doubleListGI = dataInput.AskForDoubleList("Gi (dB)", doubleListAI.Count);
            List<double> doubleListNI = dataInput.AskForDoubleList("Ni (dBm)", doubleListAI.Count);
            double doublePTx = dataInput.AskForDoubleList("P (dBm)", 1)[0];
            double doublePRx = complexMath.CalculatePRx(doubleListAI, doubleListGI, doubleListNI, doublePTx);
            double doublePNoiseRx = complexMath.CalculatePNoiseRx(doubleListAI, doubleListGI, doubleListNI, doublePTx);
            complexMath.CalculateOSNR(doublePRx, doublePNoiseRx);
        }
    }
}