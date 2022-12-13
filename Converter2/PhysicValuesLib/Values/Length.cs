namespace PhysicValuesLib.Values;

internal class Length : AnyValue
{
    public Length()
    {
        ValueName = "Длина";

        CoefficientsAndMeasuresList = new Dictionary<string, double>()
        {
            {   "Милиметр",     0.001  },
            {   "Сантиметр",    0.01   },
            {   "Дециметр",     0.1    },
            {   "Метр",         1      },
            {   "Километр",     1000   },
        };
    }
}