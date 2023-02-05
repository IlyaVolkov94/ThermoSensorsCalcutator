// Console application for calculating temperature sensors
using Automation;
using ThermoDetectorsCommandLine;

Instruction instruction = new();
Console.WriteLine(instruction.GetInstruction());
bool quitFlag = true;
while (quitFlag)
{
    Console.Write("Ввод:\t");
    UserInput userString = new (Console.ReadLine()!);
    string[] result = userString.Split();
    foreach(string s in result)
    Console.WriteLine(s);
}