// Console application for calculating temperature sensors
using Automation;
using System.Text.RegularExpressions;
using ThermoDetectorsCommandLine;

Instruction instruction = new();
Console.WriteLine(instruction.GetInstruction());


ResistanceTemperatureDetectorPlatinumPt pt50 = new(50);
ResistanceTemperatureDetectorPlatinumPt pt100 = new(100);
ResistanceTemperatureDetectorPlatinumPt pt1000 = new(1000);
ResistanceTemperatureDetectorPlatinumP P50 = new(50);
ResistanceTemperatureDetectorPlatinumP p100 = new(100);
ResistanceTemperatureDetectorPlatinumP p1000 = new(1000);
ResistanceTemperatureDetectorCopper cu50 = new(50);
ResistanceTemperatureDetectorCopper cu100 = new(100);
ThermocoupleTypeK typeK = new();
ThermocoupleTypeL typeL = new();
ThermocoupleTypeN typeN = new();
ThermocoupleTypeJ typeJ = new();
ThermocoupleTypeS typeS = new();
const string pattern = @"[^a-z-0-9\,\-]+";

while (true)
{
    Console.Write("\nВвод:\t");
    var userString = (Console.ReadLine()!);
    string[] userSubString = Regex.Split(userString, pattern);
    if (userSubString[0] == "q")
    {
        break;
    }

    // Создать класс, который будет универсально работать со всеми сопротивлениями и, по возможности, термопарами. Потому что, код ниже будет с ними работать по подобию.
    if (userSubString[0] == pt100.GetName())        
    {
        if (userSubString[1] == "resist")
        {
            var result = pt100.GetResistance(double.Parse(userSubString[2]));
            Console.WriteLine($"\t{Math.Round(result, 2)} Omh");
        }
        else if (userSubString[1]=="temp")
        {
            var result = pt100.GetTemperature(double.Parse((userSubString[2])));
            Console.WriteLine($"\t{Math.Round(result,2)} °C");
        }
        else
        {
            Console.WriteLine("Некорректная команда");
        }
    }
}