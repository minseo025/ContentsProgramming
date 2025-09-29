using UnityEngine;

public class TemperatureHeight : MonoBehaviour
{
    // 온도 변수 (Inspector에서 조절 가능)
    public float temperature = 20.0f; // 온도
    public float maxHeight = 5.0f;  // 최대 높이
    private Transform myTransform;
    
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
         // 온도를 높이로 변환
        float height = (temperature / 50.0f) * maxHeight;
        
        // Y축(세로) 크기만 변경
        myTransform.localScale = new Vector3(1f, height, 1f);
        
        // 결과 출력
        Debug.Log("온도에 따른 높이 설정 완료: " + height);
        //Debug.Log("온도 " + temperature + "도 → 높이 " + height);
    }
}