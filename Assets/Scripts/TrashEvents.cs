using System;
using UnityEngine;

public static class TrashEvents
{
    public static event Action<string> OnTrashPickedUp;
    public static event Action OnTrashDropped;

    public static event Action<int> OnScoreAdded;

    public static void ReportPickup(string tag)
    {
        OnTrashPickedUp?.Invoke(tag);
    }

    public static void ReportDrop() 
    {
        OnTrashDropped?.Invoke();
    }

    public static void ReportScore(int points) 
    {
        OnScoreAdded?.Invoke(points);
    }
}
