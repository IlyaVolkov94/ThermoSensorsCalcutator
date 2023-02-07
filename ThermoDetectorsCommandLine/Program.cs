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
List<ResistanceTemperatureDetector> resistanceTemperatureDetectors = new()
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
List<Thermocouple> thermocouples = new()
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
    string[] userSubString = Regex.Split(userString, pattern);
    
    if (userSubString[0] == "q")
    {
        break;
    }
    FindDetector(resistanceTemperatureDetectors, thermocouples, userSubString);

}


static void FindDetector(List<ResistanceTemperatureDetector> arg1, List<Thermocouple> arg2, string[] userSubString)
{
    foreach (var s in arg1)
    {
        if (userSubString[0] == s.GetName().ToLower())
        {
            CalculateResistanceDetector (s, userSubString);
            return;
        }
    }
    Console.WriteLine("Некорректный тип датчика");
}

static void CalculateResistanceDetector(ResistanceTemperatureDetector detector, string[] userSubString)
{
        if (userSubString[1] == "resist")
        {
            var result = detector.GetResistance(double.Parse(userSubString[2]));
            Console.WriteLine($"\t{Math.Round(result, 2)} Omh");
        }
        else if (userSubString[1] == "temp")
        {
            var result = detector.GetTemperature(double.Parse((userSubString[2])));
            Console.WriteLine($"\t{Math.Round(result, 2)} °C");
        }
        else
        {
            Console.WriteLine("Некорректная команда");
        }
}