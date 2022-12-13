namespace PhysicValuesLib.Values;

internal class Speed : AnyValue
{
    public Speed()
    {
        ValueName = "Скорость";

        CoefficientsAndMeasuresList = new Dictionary<string, double>()
        {
            { "Метр в секунду",     1              },
            { "Метр в минуту",      0.01666666667  },
            { "Километр в секунду", 1000           },
            { "Километр в час",     0.27777777778  },
        };
    }
}