using UnityEngine;

public static class SettingsManager
{
    private static string _minEnemyPlanetsCountKey = "MinEnemyPlanetsCount";
    public static int MinEnemyPlanetsCount
    {
        get
        {
            return PlayerPrefs.GetInt("MinEnemyPlanetsCount", 1);
        }

        set
        {
            if (IsEnemyPlanetsCountAcceptable(value))
            {
                PlayerPrefs.SetInt("MinEnemyPlanetsCount", value);
            }
        }
    }

    private static string _maxEnemyPlanetsCountKey = "MaxEnemyPlanetsCount";
    public static int MaxEnemyPlanetsCount
    {
        get
        {
            return PlayerPrefs.GetInt("MaxEnemyPlanetsCount", MinEnemyPlanetsCount);
        }

        set
        {
            if (IsEnemyPlanetsCountAcceptable(value) && value >= MinEnemyPlanetsCount)
            {
                PlayerPrefs.SetInt("MaxEnemyPlanetsCount", value);
            }
        }
    }

    private static bool IsEnemyPlanetsCountAcceptable(int count)
    {
        return (count >= 1 || count <= 5);
    }
}
