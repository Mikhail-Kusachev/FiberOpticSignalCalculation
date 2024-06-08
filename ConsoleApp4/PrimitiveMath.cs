namespace SignalPowerCalculator
{
    internal class PrimitiveMath
    {
        public double CalculateSignalAfterGain(double signal, double gain)
        {
            return (signal * gain * Math.Pow(10, 0.1));
        }

        public double CalculateSignalAfterLoss(double signal, double loss)
        {
            return (signal / (loss * Math.Pow(10, 0.1)));

        }

        public double ConvertFromLogToLin(double signal)
        {
            return (Math.Pow(10, signal / 10));
        }

        public double ConvertFromLinToLog(double signal)
        {
            return (10 * Math.Log10(signal));
        }
    }
}
