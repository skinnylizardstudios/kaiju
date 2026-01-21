using UnityEngine;

public static class EarthGolemAppearanceProgression
{
    public struct ProgressionStage
    {
        public int MinLevel;
        public int MaxLevel;
        public float FistGirthMultiplier;
    }

    public struct AppearanceData
    {
        public string StageName;
        public float FistGirthMultiplier;
    }

    public static ProgressionStage GetProgressionStage(int level)
    {
        return new ProgressionStage { MinLevel = 1, MaxLevel = 9999, FistGirthMultiplier = 1.0f };
    }

    public static int GetProgressionTier(int level)
    {
        return Mathf.Max(1, (level - 1) / 10 + 1);
    }

    public static AppearanceData GetLevelAppearance(int level)
    {
        int tier = GetProgressionTier(level);
        return new AppearanceData
        {
            StageName = tier switch
            {
                1 => "Young Golem",
                2 => "Hardened Golem",
                3 => "Mighty Golem",
                4 => "Colossal Golem",
                _ => "Ancient Golem"
            },
            FistGirthMultiplier = 1.0f + (tier * 0.2f)
        };
    }
}