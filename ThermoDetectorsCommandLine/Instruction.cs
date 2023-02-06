
using System.Text;

namespace ThermoDetectorsCommandLine;

internal class Instruction
{
    readonly StringBuilder instruction = new();
    internal string GetInstruction()
    {
        instruction.AppendLine("Привет, пользователь!");
        instruction.AppendLine("Для расчета введите тип датчика, команду и значение:");
        instruction.AppendLine("\tpt100 ress 120,1");
        instruction.AppendLine("\tk volt 120,1 25");
        instruction.AppendLine("Список команд:");
        instruction.AppendLine("\tress - для расчета сопротивления");
        instruction.AppendLine("\ttemp - для расчета температуры");
        instruction.AppendLine("\tvolt - для расчета выходного напряжения термопары");
        instruction.AppendLine("\tq - выход");
        return instruction.ToString();
    }
}