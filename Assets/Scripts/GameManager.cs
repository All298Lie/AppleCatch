using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] ItemGenerator itemGenerator;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI pointText;

    float time = 30.0f;

    int point;

    public bool IsTimeOut { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("이미 게임매니저가 존재합니다.");
            Destroy(gameObject);
        }

        this.IsTimeOut = false;
    }

    void Update()
    {
        if (this.time > 0.0f)
        {
            this.time = Mathf.Max(time - Time.deltaTime, 0.0f);

            this.timeText.text = this.time.ToString("0.0");

            UpdateDifficult();
        }
        else
        {
            this.IsTimeOut = true;
        }
    }

    private void UpdateDifficult()
    {
        if (this.time < 4)
        {
            this.itemGenerator.SetParameter(0.3f, -0.06f, 0);
        }
        else if (this.time < 12)
        {
            this.itemGenerator.SetParameter(0.5f, -0.05f, 6);
        }
        else if (this.time < 23)
        {
            this.itemGenerator.SetParameter(0.8f, -0.04f, 4);
        }
        else if (this.time < 30)
        {
            this.itemGenerator.SetParameter(1.0f, -0.03f, 2);
        }
    }

    public void GetBomb()
    {
        this.point = this.point / 2;

        UpdatePoint();
    }

    public void GetApple()
    {
        this.point = this.point + 100;

        UpdatePoint();
    }

    public void UpdatePoint()
    {
        this.pointText.text = $"{this.point} Point";
    }
}
