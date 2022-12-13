using PhysicValuesLib.Values;
using System.Reflection;

namespace PhysicValuesLib;

public class ConverterManager
{
    public ConverterManager()
    {
        SetValuesList();
    }

    private static List<IValue> _physicValuesList = new List<IValue>();

    /// <summary>
    /// Метод погружает список величин из библиотеки классов
    /// </summary>
    private static void SetValuesList()
    {
        Assembly asm = Assembly.LoadFrom("PhysicValuesLib.dll");        // создание сборки из библиотеки классов
        Type[] types = asm.GetTypes();                                  // выгрузка классов в массив
        foreach (Type type in types)                                    // перебираем классы и интерфейсы
        {
            if ((type.IsInterface == false)
                && (type.IsAbstract == false)
                && (type.Name != ("AnyValue"))                          // добавил, чтобы исключить базовый класс
                && (type.GetInterface("IValue") != null))               // не добавляем абстрактные классы и интерфейсы
            {
                IValue value = (IValue)Activator.CreateInstance(type);
                _physicValuesList.Add(value);                           // подгружаем этот класс в список уроков                        
            }
        }
    }

    /// <summary>
    /// Переменная типы интерфейса IValue
    /// </summary>
    private IValue _myValue;

    /// <summary>
    /// Создает объект конкретной физ. величины
    /// </summary>
    /// <param name="valueName"></param>
    private void SetIValue(string valueName)
    {
        foreach (var value in _physicValuesList)
        {
            if (value.GetValueName() == valueName)
            {
                _myValue = value;
            }
        }
    }

    /// <summary>
    /// Метод возвращает список доступных физических величин
    /// </summary>
    /// <returns></returns>
    public List<string> GetPhysicValuesList()
    {
        List<string> physicValuesList = new List<string>();

        foreach (IValue value in _physicValuesList)
        {
            physicValuesList.Add(value.GetValueName());
        }
        return physicValuesList;
    }

    /// <summary>
    /// Метод формирует список доступных единиц измерения из словаря любой величины
    /// </summary>
    /// <param name="physicValue"></param>
    /// <returns></returns>
    public List<string> GetMeasureList(string physicValue)
    {
        SetIValue(physicValue);

        List<string> list = new List<string>();

        foreach (var str in _myValue.GetCoefficients())
        {
            list.Add(str.Key);
        }
        return list;
    }

    /// <summary>
    /// Метод осуществляет конвертацию
    /// </summary>
    /// <param name="physicValue"></param>
    /// <param name="value"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public double GetConvertedValue(
        string physicValue,
        double value,
        string from,
        string to)
    {
        SetIValue(physicValue);

        value *= _myValue.GetCoefficients()[from];
        value /= _myValue.GetCoefficients()[to];

        return value;
    }
}