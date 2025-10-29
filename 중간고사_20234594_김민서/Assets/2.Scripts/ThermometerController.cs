using UnityEngine;

public class ThermometerController : MonoBehaviour
{
    // 2️⃣ 변수 (요구 초기값)
    [Header("Settings")]
    [Range(0, 50)] public float temperature = 25f; // 온도(0~50)
    public float maxHeight = 3f;                   // 최대 높이(초기 3)

    [Header("References")]
    public Transform thermometerBar;               // ThermometerBar의 Transform
    public Renderer barRenderer;                   // ThermometerBar의 Renderer
    public Renderer groundRenderer;                // Ground의 Renderer

    // 내부용
    private const float minHeight = 0.1f;          // 최소 높이(요구사항)

    void Update()
    {
        // --- 높이 제어 (0~50도 → 0.1~maxHeight 매핑)
        float t01 = Mathf.Clamp01(temperature / 50f);
        float height = Mathf.Lerp(minHeight, maxHeight, t01);

        // localScale.y를 높이로 설정
        Vector3 s = thermometerBar.localScale;
        s.y = height;
        thermometerBar.localScale = s;

        // "아래 기준으로 위로 증가"하도록 바의 중심을 올려줌
        // (바의 절반 높이가 Y 위치가 되도록)
        Vector3 p = thermometerBar.position;
        p.y = height / 2f;
        thermometerBar.position = p;

        // --- 색상 제어: ThermometerBar
        if (temperature < 15f)
            barRenderer.material.color = Color.blue;     // 파란색
        else if (temperature < 30f)
            barRenderer.material.color = Color.green;    // 녹색
        else
            barRenderer.material.color = Color.red;      // 빨간색

        // --- 색상 제어: Ground
        if (temperature < 15f)
            groundRenderer.material.color = Color.white;                // 하얀색
        else if (temperature < 30f)
            groundRenderer.material.color = new Color(0.59f, 0.29f, 0f); // 갈색
        else
            groundRenderer.material.color = new Color(1f, 0.5f, 0f);     // 주황색
    }
}
