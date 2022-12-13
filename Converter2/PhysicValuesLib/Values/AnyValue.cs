using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    internal class AnyValue : IValue
    {
        // 1. Поля
        private string _valueName = "Default";     // имя физической величины

        // словарь единиц измерения и переводных коэффициентов
        private Dictionary<string, double> _coeff = new Dictionary<string, double>()
        {
            { "Default1",    1   }
        };

        // 2. Свойства к тем же полям
        protected string ValueName { get; set; }

        protected Dictionary<string, double> CoefficientsAndMeasuresList { get; set; }


        // 3. Методы по интерфейсу IValue
        public Dictionary<string, double> GetCoefficients() => CoefficientsAndMeasuresList;

        public string GetValueName() => ValueName;
    }
}
