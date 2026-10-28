using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeScreen : MonoBehaviour
{
    // ** NOTE ** //
    // startTime = 5;
    // activeTimer = true;
    public static TimeScreen instance;
    [HideInInspector]
    [Header("Script")]
    CameraControll cameraControll;
    TextAnimation textAnimation;
    [Header("References")]
    [SerializeField] Image fadeInOutTrans;

    [Header("Configuration")]
    public bool isDelayScene;
    public bool isCanClick;
    public float timeDelayScene;
    public float speedFadeInOut;
    public float startTime;
    public bool activeTimer;
    public bool activeFadeInOut;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cameraControll = CameraControll.instance;
        textAnimation = TextAnimation.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTimer)
        {
            if (startTime > 0)
            {
                startTime -= Time.deltaTime;

                DisplayTime(startTime);
            }
            else
            {
                StartCoroutine(FadeInOutTransition(activeFadeInOut, 0));
            }
        }
        else
        {
            DetectionInput();
        }

        if (isDelayScene)
        {
            StartCoroutine(FadeInOutTransition(activeFadeInOut, timeDelayScene));
        }
    }

    void DisplayTime(float time)
    {
        time += 1;

        float seconds = Mathf.FloorToInt(time % 60);
    }

    public IEnumerator FadeInOutTransition(bool activeTrans, float timeDelayScene)
    {
        Color color = fadeInOutTrans.color;

        if (color.a <= 1 && activeTrans != true)
        {
            color.a += speedFadeInOut;

            fadeInOutTrans.color = color;
        }
        else if (color.a > 0 && activeTrans)
        {
            if (timeDelayScene > 0)
            {
                isDelayScene = false;

                yield return new WaitForSeconds(timeDelayScene);

                this.timeDelayScene = 0;

                isDelayScene = true;
            }
            color.a -= speedFadeInOut;

            fadeInOutTrans.color = color;

            if (color.a >= 0f && color.a <= 0.01f)
            {
                activeTimer = false;
                activeFadeInOut = false;
                isDelayScene = false;

                startTime = 0f;
            }
        }
        else
        {
            activeFadeInOut = true;

            startTime = 1f;

            cameraControll.ChangeCamera();
        }
    }

    void DetectionInput()
    {
        if (Input.GetMouseButtonDown(0) && isCanClick)
        {
            StartCoroutine(textAnimation.AnimationTextDelay(textAnimation.delay, true));
        }
    }
}
