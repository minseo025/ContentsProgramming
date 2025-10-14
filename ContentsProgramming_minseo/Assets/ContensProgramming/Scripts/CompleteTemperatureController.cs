using UnityEngine;

public class CompleteTemperatureController : MonoBehaviour
{
    [Header("온도 설정")]
    public float temperature = 25.0f;     // 온도
    public float maxHeight = 3.0f;        // 최대 높이
    
    [Header("디버깅")]
    public bool showDebugInfo = true;     // 디버그 정보 표시
    
    private Renderer objectRenderer;       // Renderer 컴포넌트
    private float nextDebugTime = 0f;      // 다음 디버그 출력 시간

    // 기존 값들 저장(폭/두께 유지 + 기준 위치 계산용)
    private Vector3 baseScale;
    private Vector3 baseLocalPos;
    private float bottomY;                 // 바닥의 고정 Y좌표
    
    void Start()
    {
        // Renderer 컴포넌트 가져오기
        objectRenderer = GetComponent<Renderer>();
        
        if (objectRenderer == null)
        {
            Debug.LogError("이 GameObject에는 Renderer가 없습니다!");
        }

        // 시작값 기록
        baseScale    = transform.localScale;     // 예: x=0.3, y=초기높이, z=0.1
        baseLocalPos = transform.localPosition;  // 초기 위치
        bottomY      = baseLocalPos.y - baseScale.y * 0.5f;  // 현재 높이의 절반만큼 아래가 ‘바닥’
        
        Debug.Log("온도계 시작! 초기 온도: " + temperature + "도");
    }
    
    void Update()
    {
        // 1) 온도를 높이로 변환 (0~50도 가정)
        float height = temperature / 50.0f * maxHeight;
        if (height < 0.1f) height = 0.1f;  // 최소 높이 보장

        // 2) 폭/두께는 유지하고 Y(높이)만 변경
        transform.localScale = new Vector3(baseScale.x, height, baseScale.z);

        // 3) 바닥 고정: 바닥(bottomY) + 새 높이의 절반만큼 올려 배치
        transform.localPosition = new Vector3(
            baseLocalPos.x,
            bottomY + height * 0.5f,
            baseLocalPos.z
        );

        // 4) 색상 변경
        if (objectRenderer != null)
        {
            if (temperature < 15.0f)
            {
                // 추운 날씨 - 파란색
                objectRenderer.material.color = Color.blue;
            }
            else if (temperature >= 15.0f && temperature < 30.0f)
            {
                // 적당한 날씨 - 녹색
                objectRenderer.material.color = Color.green;
            }
            else
            {
                // 더운 날씨 - 빨간색
                objectRenderer.material.color = Color.red;
            }
        }
        
        // 5) 디버그(1초마다)
        // if (showDebugInfo && Time.time >= nextDebugTime)
        // {
        //     Debug.Log("[" + gameObject.name + "] 온도: " + temperature + "도, 높이: " + height.ToString("F2"));
        //     nextDebugTime = Time.time + 1.0f;  // 1초 후 다시 출력
        // }
    }
}