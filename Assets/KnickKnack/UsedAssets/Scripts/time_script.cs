using System;
using TMPro;
using UnityEngine;

public class timeAPI : MonoBehaviour
{
    [SerializeField] private string timeZoneId = "Europe/Rome"; // Rome / Italy

    private TMP_Text tmp;
    private TimeZoneInfo tz;

    void Start()
    {
        tmp = GetComponent<TMP_Text>();

        try
        {
            tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }
        catch
        {
            // Fallback for some Windows installs (rare)
            tz = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
        }

        InvokeRepeating(nameof(UpdateTime), 0f, 1f);
    }

    void UpdateTime()
    {
        DateTime local = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        if (tmp != null)
            tmp.text = $"{local:HH:mm:ss}\n{local:ddd, MMM d}";
    }
}