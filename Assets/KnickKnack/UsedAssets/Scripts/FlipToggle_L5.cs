using UnityEngine;

public class FlipToggleL5 : MonoBehaviour
{
    [Header("Tracked object (drag your MultiTarget here)")]
    [SerializeField] private Transform trackedObject;

    [Header("Toggle targets")]
    [SerializeField] private GameObject uiFacesRoot;         // we drag the L2 faces here
    [SerializeField] private GameObject optionalToggle;      // potential GlobeSpin object if time and sanity allows

    [Header("Flip detection")]
    [Tooltip("Dot(tracked.up, worldUp). Upside down tends toward -1.")]
    [SerializeField] private float upsideDownThreshold = 0f; // < 0 means mostly upside-down
    [SerializeField] private float debounceSeconds = 0.8f;

    [SerializeField] private DayNightL4 dayNightController;
    [SerializeField] private SlowSpin globeSpin;

    private bool lastUpsideDown;
    private float lastToggleTime;

    void Start()
    {
        if (trackedObject == null) trackedObject = transform;
        lastUpsideDown = false;
        lastToggleTime = -999f;
    }

    void Update()
    {
        if (trackedObject == null) return;

        float dot = Vector3.Dot(trackedObject.up, Vector3.up);
        bool upsideDown = dot < upsideDownThreshold;

        // Toggle when transitioning into upside-down state
        if (upsideDown && !lastUpsideDown && Time.time - lastToggleTime > debounceSeconds)
        {
            Toggle();
            lastToggleTime = Time.time;
        }

        lastUpsideDown = upsideDown;
    }

    void Toggle()
    {
        if (uiFacesRoot != null)
            uiFacesRoot.SetActive(!uiFacesRoot.activeSelf);

        if (optionalToggle != null)
            optionalToggle.SetActive(!optionalToggle.activeSelf);

        if (dayNightController != null)
            dayNightController.ToggleManualOverrideInvert();

        if (globeSpin != null)
            globeSpin.enabled = !globeSpin.enabled;
    }
}