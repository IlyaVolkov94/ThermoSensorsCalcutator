using Automation;

namespace ThermoDetectorsCommandLine
{
    internal static class ThermoDetector
    {
        private static ResistanceTemperatureDetectorPlatinumPt pt50 = new(50);
        private static ResistanceTemperatureDetectorPlatinumPt pt100 = new(100);
        private static ResistanceTemperatureDetectorPlatinumPt pt1000 = new(1000);
        private static ResistanceTemperatureDetectorPlatinumP p50 = new(50);
        private static ResistanceTemperatureDetectorPlatinumP p100 = new(100);
        private static ResistanceTemperatureDetectorPlatinumP p1000 = new(1000);
        private static ResistanceTemperatureDetectorCopper cu50 = new(50);
        private static ResistanceTemperatureDetectorCopper cu100 = new(100);
        private static ThermocoupleTypeK typeK = new();
        private static ThermocoupleTypeL typeL = new();
        private static ThermocoupleTypeN typeN = new();
        private static ThermocoupleTypeJ typeJ = new();
        private static ThermocoupleTypeS typeS = new();

        internal static ResistanceTemperatureDetector[] resistanceTemperatureDetectors = new ResistanceTemperatureDetector[]
        {
            pt50,
            pt100,
            pt1000,
            p50,
            p100,
            p1000,
            cu50,
            cu100
        };

        internal static Thermocouple[] thermocouples = new Thermocouple[]
        {
            typeK,
            typeL,
            typeN,
            typeJ,
            typeS
        };

        internal static string GetThermocoupleName(Thermocouple thermocouple)
        {
            var str = thermocouple.GetName().ToLower();
            string[] subStrings = str.Split(" ");
            return subStrings[1];

        }

        private static void CalculateThermocoupleDetector(Thermocouple thermocouple, string[] userSubStrings)
        {
            if (userSubStrings[1] == "getvol")
            {
                var result = thermocouple.GetVoltage((double.Parse(userSubStrings[2]), double.Parse(userSubStrings[3])));
                Console.WriteLine($"{Math.Round(result, 3)} mV");
            }
            else if (userSubStrings[1] == "gettem")
            {
                var result = thermocouple.GetTemperature((double.Parse(userSubStrings[2]), double.Parse(userSubStrings[3])));
                Console.WriteLine($"{Math.Round(result, 2)} °C");
            }
            else
            {
                Console.WriteLine("Некорректная команда");
            }
        }

        private static void CalculateResistanceDetector(ResistanceTemperatureDetector detector, string[] userSubStrings)
        {
            if (userSubStrings[1] == "getres")
            {
                var result = detector.GetResistance(double.Parse(userSubStrings[2]));
                Console.WriteLine($"\t{Math.Round(result, 2)} Omh");
            }
            else if (userSubStrings[1] == "gettem")
            {
                var result = detector.GetTemperature(double.Parse((userSubStrings[2])));
                Console.WriteLine($"\t{Math.Round(result, 2)} °C");
            }
            else
            {
                Console.WriteLine("Некорректная команда");
            }
        }

        internal static void CalculateDetector(ResistanceTemperatureDetector[] temperatureDetectors, Thermocouple[] thermocouples, string[] userSubStrings)
        {
            foreach (var s in temperatureDetectors)
            {
                if (userSubStrings[0] == s.GetName().ToLower())
                {
                    ThermoDetector.CalculateResistanceDetector(s, userSubStrings);
                    return;
                }
            }
            foreach (var s in thermocouples)
            {
                if (userSubStrings[0] == ThermoDetector.GetThermocoupleName(s).ToLower())
                {
                    ThermoDetector.CalculateThermocoupleDetector(s, userSubStrings);
                    return;
                }
            }
            Console.WriteLine("Некорректный тип датчика");
        }
    }
}
