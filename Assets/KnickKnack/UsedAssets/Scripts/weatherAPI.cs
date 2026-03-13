using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class weatherAPI : MonoBehaviour
{
    [Header("OpenWeather")]
    [SerializeField] private string apiKey = "YOUR_KEY"; // don't commit this
    [SerializeField] private string city = "Rome";
    [SerializeField] private string countryCode = "IT";
    [SerializeField] private bool useMetric = true;
    [SerializeField] private float refreshSeconds = 600f; // 10 minutes

    private TMP_Text tmp;

    void Start()
    {
        tmp = GetComponent<TMP_Text>();
        if (tmp != null) tmp.text = "Loading…";

        // start after 2 seconds, then repeat
        InvokeRepeating(nameof(GetDataFromWeb), 2f, refreshSeconds);
    }

    void GetDataFromWeb()
    {
        StartCoroutine(GetRequest(BuildUrl()));
    }

    string BuildUrl()
    {
        string units = useMetric ? "metric" : "imperial";
        return $"https://api.openweathermap.org/data/2.5/weather?q={city},{countryCode}&appid={apiKey}&units={units}";
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.timeout = 10;
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                if (tmp != null) tmp.text = $"Error\n{webRequest.error}";
                yield break;
            }

            string json = webRequest.downloadHandler.text;

            // Very simple parsing (similar to Professor Aurisano's idea)
            // temp
            int startTemp = json.IndexOf("\"temp\":", 0);
            if (startTemp < 0) { tmp.text = "Temp not found"; yield break; }

            int endTemp = json.IndexOf(",", startTemp);
            string tempStr = json.Substring(startTemp + 7, endTemp - (startTemp + 7));
            float temp = float.Parse(tempStr, System.Globalization.CultureInfo.InvariantCulture);

            // description
            int startDesc = json.IndexOf("\"description\":\"", 0);
            string desc = "N/A";
            if (startDesc >= 0)
            {
                int endDesc = json.IndexOf("\"", startDesc + 15);
                desc = json.Substring(startDesc + 15, endDesc - (startDesc + 15));
            }

            string unit = useMetric ? "°C" : "°F";
            if (tmp != null)
                tmp.text = $"{temp:0.#}{unit}\n{CapFirst(desc)}";
        }
    }

    private string CapFirst(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return char.ToUpper(s[0]) + s.Substring(1);
    }
}
