// Console application for calculating temperature sensors

using System.Text.RegularExpressions;

namespace ThermoDetectorsCommandLine;

static class Program
{
    static string introduction = "Привет, пользователь!\nДля расчета введите тип датчика, команду и значение:"
        +"\n\tpt100 getres 120,1\n\t100p getres 120,1\n\tk getvol 120,1 25"
        +"\nДля термопар необходимо ввести температуру холодного спая Список команд:"
        +"\n\tgetres - для расчета сопротивления\n\tgettem - для расчета температуры\n\tgetvol - для расчета выходного напряжения термопары\n\tq - выход";
    static void Main()
    {
        Console.WriteLine(introduction);
        const string pattern = @"[^a-z-0-9\,\-]+";

        while (true)
        {
            Console.Write("\nВвод:\t");
            try
            {
                var userString = (Console.ReadLine()!.ToLower());
                string[] userSubStrings = Regex.Split(userString, pattern);

                if (userSubStrings[0] == "q")
                {
                    break;
                }
                ThermoDetector.CalculateDetector(ThermoDetector.resistanceTemperatureDetectors, ThermoDetector.thermocouples, userSubStrings);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Введено некорректное значение. Возможно, значение не соотвествует типу датчика?");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Введены некорректные данные. Возможно забыли указать температуру холодного спая?");
            }
            catch
            {
                Console.WriteLine("Непредвиденная ошибка");
            }
        }
    }
}