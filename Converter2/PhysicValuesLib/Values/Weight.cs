namespace PhysicValuesLib.Values;

internal class Weight : AnyValue
{
    public Weight()
    {
        ValueName = "Вес";

        CoefficientsAndMeasuresList = new Dictionary<string, double>()
        {
            { "Грамм",       0.001  },
            { "Килограмм",   1      },
            { "Центнер",     100    },
            { "Тонна",       1000   },
        };
    }
}
