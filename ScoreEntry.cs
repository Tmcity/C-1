﻿namespace Score;

public class ScoreEntry
{
    public struct grades
    {
        public string Name;
        public int Score;
    }

    public static List<grades> n = new List<grades>();

    public static void Add(string name, int m)
    {
        n.Add(new grades { Name = name, Score = m });
    }

    public static int GitScore(string name)
    {
        int score = 0;
        foreach (grades i in n)
        {
            if (i.Name == name)
            {
                score = i.Score;
                break;
            }
        }
        return score;
    }
}