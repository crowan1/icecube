using System.Collections.Generic;

public static class LevelProgress
{
    static HashSet<int> unlockedLevels = new HashSet<int>();

    public static bool IsLevelUnlocked(int levelIndex)
    {
        if (levelIndex <= 1) return true;
        return unlockedLevels.Contains(levelIndex);
    }

    public static void UnlockLevel(int levelIndex)
    {
        unlockedLevels.Add(levelIndex);
    }

    public static void ResetProgress()
    {
        unlockedLevels.Clear();
    }
}
