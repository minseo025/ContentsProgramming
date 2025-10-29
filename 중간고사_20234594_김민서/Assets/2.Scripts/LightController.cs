using UnityEngine;
using TMPro;

public class LightController : MonoBehaviour
{
    // 연결할 대상들
    public Renderer lightBulb;          // Sphere(LightBulb)의 Renderer
    public TextMeshProUGUI statusText;  // StatusText
    public GameObject infoPanel;        // InfoPanel

    void Start()
    {
        // 초기 상태 = 어두움
        SetDark();
    }

    public void SetDark()
    {
        if (lightBulb != null) lightBulb.material.color = Color.gray;
        if (statusText != null) statusText.text = "밝기: 어두움";
        if (infoPanel != null) infoPanel.SetActive(false);
    }

    public void SetBright()
    {
        if (lightBulb != null) lightBulb.material.color = Color.white;
        if (statusText != null) statusText.text = "밝기: 밝음";
        if (infoPanel != null) infoPanel.SetActive(true);
    }
}
