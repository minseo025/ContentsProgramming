using UnityEngine;

public class WeatherData : MonoBehaviour
{
    // 2️⃣ public 변수 (Inspector에서 보이도록 public)
    public float temperature = 25.5f;  // 온도(실수)
    public float humidity = 60f;       // 습도(실수)
    public string cityName = "서울";     // 도시 이름(문자열)

    void Start()
    {
        // 3️⃣ 체감온도 계산
        // 예시 공식: 체감온도 = 온도 - (100 - 습도) * 0.05
        float feelsLike = temperature - (100f - humidity) * 0.05f;

        // 3️⃣ Debug.Log 출력 (요구 형식과 동일하게)
        Debug.Log(cityName + "의 온도: " + temperature.ToString("F1")); // 예: "서울의 온도: 25.5"
        Debug.Log("습도: " + humidity.ToString("F0"));                   // 예: "습도: 60"
        Debug.Log("체감온도: " + feelsLike.ToString("F1"));              // 예: "체감온도: 23.5"
    }
}
