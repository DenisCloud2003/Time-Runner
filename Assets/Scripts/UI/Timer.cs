using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public TextManager textManager;

    public float timeDuration;
    public float timer;
    private bool timerPaused;
    bool isPause;
    string text;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        TimerReset();
        timer = timeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerPaused)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
            
        }

        if (timer <= 0 &&!isPause)
        {
            isPause = true;
            OutOfTime();
        }
    }

    private void TimerReset()
    {
        timer = 0;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minute = Mathf.FloorToInt(time / 60);
        float second = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minute, second);

        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    public void PauseTimer()
    {
        timerPaused = true;
    }

    public void OutOfTime()
    {
        timer = 0;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        text = "OfT";
        textManager.TextChanger(text);
    }
}
