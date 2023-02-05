// Console application for calculating temperature sensors
using System.Text;
using Automation;

StringBuilder instruction = new();
instruction.AppendLine("Привет, пользователь!");
instruction.AppendLine("Для расчета введите тип датчика, команду и значение:");
instruction.AppendLine("\tpt100 resistance 120,1");
instruction.AppendLine("\tk voltage 120,1 25");
instruction.AppendLine("Список команд:");
instruction.AppendLine("\tresistance - для расчета сопротивления");
instruction.AppendLine("\ttemperature - для расчета температуры");
instruction.AppendLine("\tvoltage - для расчета выходного напряжения термопары");

Console.WriteLine(instruction.ToString());
var userString = Console.ReadLine();
