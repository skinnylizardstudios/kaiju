using UnityEngine;

/// <summary>
/// Logarithmic scaling system for Earth Golem.
/// Level 1 = 1 meter, Level 9999 = 1 kilometer
/// </summary>
public static class EarthGolemScaling
{
    private const float MIN_HEIGHT_METERS = 1f;
    private const float MAX_HEIGHT_METERS = 1000f;
    private const int MIN_LEVEL = 1;
    private const int MAX_LEVEL = 9999;
    private const float ROCK_DENSITY = 2700f; // kg/m³

    /// <summary>
    /// Get height in meters for a given level
    /// </summary>
    public static float GetHeightMeters(int level)
    {
        if (!IsValidLevel(level)) return MIN_HEIGHT_METERS;
        
        float normalized = (level - MIN_LEVEL) / (float)(MAX_LEVEL - MIN_LEVEL);
        float heightMeters = MIN_HEIGHT_METERS * Mathf.Pow(MAX_HEIGHT_METERS / MIN_HEIGHT_METERS, normalized);
        return heightMeters;
    }

    public static float GetHeightFeet(int level)
    {
        return GetHeightMeters(level) * 3.28084f;
    }

    public static float GetScaleFactor(int level)
    {
        return GetHeightMeters(level);
    }

    public static float GetMassKg(int level)
    {
        float height = GetHeightMeters(level);
        float scale = GetScaleFactor(level);
        float baseVolume = 70f / ROCK_DENSITY;
        float volumeAtLevel = baseVolume * (scale * scale * scale);
        return volumeAtLevel * ROCK_DENSITY;
    }

    public static bool IsValidLevel(int level)
    {
        return level >= MIN_LEVEL && level <= MAX_LEVEL;
    }
}