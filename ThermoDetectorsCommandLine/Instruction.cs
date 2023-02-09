
using System.Text;

namespace ThermoDetectorsCommandLine;

internal class Instruction
{
    readonly StringBuilder instruction = new();
    internal string GetInstruction()
    {
        instruction.AppendLine("Привет, пользователь!");
        instruction.AppendLine("Для расчета введите тип датчика, команду и значение:");
        instruction.AppendLine("\tcu50 getres 120,1");
        instruction.AppendLine("\t100p getres 120,1");
        instruction.AppendLine("\tk getvol 120,1 25");
        instruction.AppendLine("Для термопар необходимо ввести температуру холодного спая");
        instruction.AppendLine("Список команд:");
        instruction.AppendLine("\tgetres - для расчета сопротивления");
        instruction.AppendLine("\tgettem - для расчета температуры");
        instruction.AppendLine("\tgetvol - для расчета выходного напряжения термопары");
        instruction.AppendLine("\tq - выход");
        return instruction.ToString();
    }
}