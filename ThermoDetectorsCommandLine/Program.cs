// Console application for calculating temperature sensors
using Automation;
using ThermoDetectorsCommandLine;

Instruction instruction = new();
Console.WriteLine(instruction.GetInstruction());
bool quitFlag = true;
while (quitFlag)
{
    Console.Write("Ввод:\t");
    var userString = Console.ReadLine()!.ToLower().Trim();
    if (userString=="q")
        quitFlag = false;
}