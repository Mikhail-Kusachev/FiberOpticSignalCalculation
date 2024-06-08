namespace SignalPowerCalculator
{
    internal class ComplexMath
    {
        private PrimitiveMath _primitiveMath;
        public ComplexMath()
        {
            _primitiveMath = new PrimitiveMath();
        }
        public double CalculatePRx(List<double> doubleListAI, List<double> doubleListGI,
            List<double> doubleListNI, double doubleP)
        {
            double result = doubleP;
            if ((doubleListAI.Count == doubleListGI.Count) && (doubleListAI.Count == doubleListNI.Count))
            {
                for (int i = 0; i < doubleListAI.Count; i++)
                {
                    result = _primitiveMath.CalculateSignalAfterLoss(result, doubleListAI[i]);
                    result = _primitiveMath.CalculateSignalAfterGain(result, doubleListGI[i]);
                }
                Console.WriteLine($"PRx dBm = {result}");
            }
            else
            {
                Console.WriteLine("debug: arrays count not the same during CalculatePRx()");
            }
            return result;
        }

        //copy-paste because something goes wrong during testing and I want to sleep
        //check commented code below for better concept
        public double CalculatePNoiseRx(List<double> doubleListAI, List<double> doubleListGI,
            List<double> doubleListNI, double doubleP)
        {
            doubleP = 0;
            double result = doubleP;
            if ((doubleListAI.Count == doubleListGI.Count) && (doubleListAI.Count == doubleListNI.Count))
            {
                for (int i = 0; i < doubleListAI.Count; i++)
                {
                    result = _primitiveMath.CalculateSignalAfterLoss(result, doubleListAI[i]);
                    result = _primitiveMath.CalculateSignalAfterGain(result, doubleListGI[i]);
                    result = SignalsAddition(result, doubleListNI[i]);
                }
                Console.WriteLine($"PNoiseRx dBm = {result}");
            }
            else
            {
                Console.WriteLine("debug: arrays count not the same during CalculatePRx()");
            }
            return result;
        }

        /*
        public double CalculatePRx(List<double> doubleListAI, List<double> doubleListGI,
            List<double> doubleListNI, double doubleP)
        {
            for (int i = 0; i < doubleListNI.Count; i++)
                doubleListNI[i] = 0;
            double result = CalculatePRxWithNoise(doubleListAI, doubleListGI, doubleListNI, doubleP);
            Console.WriteLine($"P RX = {result}");
            return result;
        }

        public double CalculatePNoiseRx(List<double> doubleListAI, List<double> doubleListGI,
            List<double> doubleListNI, double doubleP)
        {
            double result = CalculatePRxWithNoise(doubleListAI, doubleListGI, doubleListNI, 0);
            Console.WriteLine($"PNoise RX = {result}");
            return result;
        }
        */

        public double CalculateOSNR(double signal, double noise)
        {
            //double result = _primitiveMath.ConvertFromLogToLin(signal) / _primitiveMath.ConvertFromLogToLin(noise);
            //result = _primitiveMath.ConvertFromLinToLog(result);
            double result = signal - noise;
            Console.WriteLine($"OSNR dB = {result}");
            return result;
        }

        public double SignalsAddition(double signal_1, double signal_2)
        {
            double result = _primitiveMath.ConvertFromLogToLin(signal_1) + _primitiveMath.ConvertFromLogToLin(signal_2);
            return _primitiveMath.ConvertFromLinToLog(result);
        }
    }
}
