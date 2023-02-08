// Console application for calculating temperature sensors
using Automation;
using System.Text.RegularExpressions;
using ThermoDetectorsCommandLine;

Instruction instruction = new();
Console.WriteLine(instruction.GetInstruction());

ResistanceTemperatureDetectorPlatinumPt pt50 = new(50);
ResistanceTemperatureDetectorPlatinumPt pt100 = new(100);
ResistanceTemperatureDetectorPlatinumPt pt1000 = new(1000);
ResistanceTemperatureDetectorPlatinumP p50 = new(50);
ResistanceTemperatureDetectorPlatinumP p100 = new(100);
ResistanceTemperatureDetectorPlatinumP p1000 = new(1000);
ResistanceTemperatureDetectorCopper cu50 = new(50);
ResistanceTemperatureDetectorCopper cu100 = new(100);
ThermocoupleTypeK typeK = new();
ThermocoupleTypeL typeL = new();
ThermocoupleTypeN typeN = new();
ThermocoupleTypeJ typeJ = new();
ThermocoupleTypeS typeS = new();
ResistanceTemperatureDetector[] resistanceTemperatureDetectors = new ResistanceTemperatureDetector[]
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
Thermocouple[] thermocouples = new Thermocouple[]
{
    typeK, 
    typeL,
    typeN, 
    typeJ,
    typeS
};
const string pattern = @"[^a-z-0-9\,\-]+";

while (true)
{
    Console.Write("\nВвод:\t");
    var userString = (Console.ReadLine()!.ToLower());
    string[] userSubStrings = Regex.Split(userString, pattern);
    
    if (userSubStrings[0] == "q")
    {
        break;
    }
    CalculateDetector(resistanceTemperatureDetectors, thermocouples, userSubStrings);

}

static void CalculateDetector(ResistanceTemperatureDetector[] temperatureDetectors, Thermocouple[] thermocouples, string[] userSubStrings)
{
    foreach (var s in temperatureDetectors)
    {
        if (userSubStrings[0] == s.GetName().ToLower())
        {
            CalculateResistanceDetector (s, userSubStrings);
            return;
        }
    }
    foreach (var s in thermocouples)
    {
        if (userSubStrings[0]== GetThermocoupleName(s).ToLower()) 
        {
            CalculateThermocoupleDetector (s, userSubStrings);
            return;
        }
    }
    Console.WriteLine("Некорректный тип датчика");
}

static string GetThermocoupleName(Thermocouple thermocouple)
{
    var str = thermocouple.GetName().ToLower();
    string[] subStrings = str.Split(" ");
    return subStrings[1];

}

static void CalculateThermocoupleDetector(Thermocouple thermocouple, string[] userSubStrings)
{
    if (userSubStrings[1]=="getvol")
    {
        var result = thermocouple.GetVoltage((double.Parse(userSubStrings[2]), double.Parse(userSubStrings[3])));
        Console.WriteLine($"{Math.Round(result, 3)} mV");
    }
    else if (userSubStrings[1]=="gettem")
    {
        var result = thermocouple.GetTemperature((double.Parse(userSubStrings[2]), double.Parse(userSubStrings[3])));
        Console.WriteLine($"{Math.Round(result, 2)} °C");
    }
    else
    {
        Console.WriteLine("Некорректная команда");
    }
}

static void CalculateResistanceDetector(ResistanceTemperatureDetector detector, string[] userSubStrings)
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