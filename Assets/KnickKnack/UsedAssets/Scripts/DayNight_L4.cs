using System;
using UnityEngine;

public class DayNightL4 : MonoBehaviour
{

    [SerializeField] private bool manualOverride = false;
    [SerializeField] private bool forcedNight = false;

    [Header("Rome time")]
    [SerializeField] private string timeZoneId = "Europe/Rome";
    [SerializeField] private int dayStartHour = 7;     // 07:00 Rome time
    [SerializeField] private int nightStartHour = 19;  // 19:00 Rome time

    [Header("Lights to control")]
    [SerializeField] private Light directionalLight;
    [SerializeField] private Light pedestalLight;   // my current Point Light
    [SerializeField] private Light dayFillLight;    // day-only fill
    [SerializeField] private Light nightGlowLight;  // night-only glow
    [SerializeField] private Light nightRimLight;   // night-only rim 

    [Header("Day look")]
    [SerializeField] private float dayDirIntensity = 1.0f;
    [SerializeField] private float dayPedestalIntensity = 1.2f;
    [SerializeField] private float dayFillIntensity = 0.8f;

    [Header("Night look")]
    [SerializeField] private float nightDirIntensity = 0.2f;
    [SerializeField] private float nightPedestalIntensity = 0.5f;
    [SerializeField] private float nightGlowIntensity = 2.5f;
    [SerializeField] private float nightRimIntensity = 1.2f; // NEW

    private TimeZoneInfo tz;
    private bool isNight;

    void Start()
    {
        tz = ResolveTimeZone(timeZoneId);
        Apply(IsNightNow());
        InvokeRepeating(nameof(Tick), 0f, 10f); // check every 10 seconds
    }

    void Tick()
    {
        bool nightNow = manualOverride ? forcedNight : IsNightNow();
        if (nightNow != isNight)
            Apply(nightNow);
    }

    bool IsNightNow()
    {
        DateTime rome = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
        int h = rome.Hour;
        return (h >= nightStartHour || h < dayStartHour);
    }

    void Apply(bool night)
    {
        isNight = night;

        if (directionalLight != null)
        {
            directionalLight.intensity = night ? nightDirIntensity : dayDirIntensity;
            directionalLight.color = night ? new Color(0.65f, 0.75f, 1.0f) : new Color(1.0f, 0.97f, 0.92f);
        }

        if (pedestalLight != null)
        {
            pedestalLight.intensity = night ? nightPedestalIntensity : dayPedestalIntensity;
            pedestalLight.color = night ? new Color(0.75f, 0.85f, 1.0f) : Color.white;
        }

        if (dayFillLight != null)
        {
            dayFillLight.gameObject.SetActive(!night);
            dayFillLight.intensity = dayFillIntensity;
        }

        if (nightGlowLight != null)
        {
            nightGlowLight.gameObject.SetActive(night);
            nightGlowLight.intensity = nightGlowIntensity;
        }

        if (nightRimLight != null)
        {
            nightRimLight.gameObject.SetActive(night);
            nightRimLight.intensity = nightRimIntensity;
        }
    }

    TimeZoneInfo ResolveTimeZone(string id)
    {
        try { return TimeZoneInfo.FindSystemTimeZoneById(id); }
        catch
        {
            // Windows fallback commonly works
            return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
        }
    }

    public void ToggleManualOverrideInvert()
    {
        // Turn override on if it was off. If already on, turn it off.
        manualOverride = !manualOverride;

        if (manualOverride)
        {
            // When override turns on, invert the current mode
            forcedNight = !isNightApplied();
        }

        // Apply immediately
        Apply(manualOverride ? forcedNight : IsNightNow());
    }

    public void SetManualOverride(bool enabled, bool night)
    {
        manualOverride = enabled;
        forcedNight = night;
        Apply(manualOverride ? forcedNight : IsNightNow());
    }

    // helper to read current applied state safely
    private bool isNightApplied()
    {
        return isNight;
    }
}