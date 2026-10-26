using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public static TextAnimation instance;
    [HideInInspector]
    [Header("Script")]
    Movement movement;
    CameraControll cameraControll;
    TimeScreen timeScreen;
    [Header("References")]
    [SerializeField] TMP_Text tmp_text;
    [SerializeField] TMP_Text tmp_hint;
    [Header("Configuration")]
    public float delay;
    string words;
    string textDialog;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        movement = Movement.instance;
        timeScreen = TimeScreen.instance;
        cameraControll = CameraControll.instance;
    }

    public IEnumerator AnimationTextDelay(float delay, bool isGameplay)
    {
        if (Dialog.activeDialog)
        {
            if (!isGameplay)
            {
                yield return new WaitForSeconds(2f);
            }
            tmp_text.text = "";

            textDialog = null;
            textDialog = Dialog.textDialog[Dialog.dialogPage];

            words = null;

            if (textDialog == null)
            {
                timeScreen.isCanClick = false;
                timeScreen.isDelayScene = true;
                timeScreen.timeDelayScene = 2.5f;
                movement.isPlayerPlay = false;

                Dialog.activeDialog = false;

                Dialog.dialogPage++;
            }
            else if (textDialog == "break")
            {
                timeScreen.isCanClick = false;
                timeScreen.isDelayScene = true;

                Dialog.activeDialog = true;

                StartCoroutine(AnimationTextDelay(delay, false));
            }
            else if (textDialog == "gameplay")
            {
                movement.isPlayerPlay = true;

                cameraControll.cameraList[cameraControll.cameraList.Length - 1].gameObject.SetActive(false);

                cameraControll.mainCamera.gameObject.SetActive(true);

                timeScreen.isCanClick = false;
                timeScreen.isDelayScene = false;

                Dialog.activeDialog = false;

                tmp_hint.text = Hints.hintDialog[Hints.indexHint];
                Hints.indexHint++;
            }
            else if (textDialog == "next")
            {
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(AutoCaption(isGameplay, movement.isPlayerPlay));
            }
            else
            {
                timeScreen.isCanClick = false;

                foreach (char t in textDialog)
                {
                    words += t;

                    tmp_text.text = words;

                    yield return new WaitForSeconds(delay);
                }

                timeScreen.isCanClick = true;
            }

            // === Auto Next Caption === //
            if (isGameplay && movement.isPlayerPlay)
            {
                yield return new WaitForSeconds(2f);
            }

            if (textDialog != null)
            {
                StartCoroutine(AutoCaption(isGameplay, movement.isPlayerPlay));
            }
        }
    }

    IEnumerator AutoCaption(bool isGameplay, bool isPlayerPlay)
    {
        if (!isGameplay && !isPlayerPlay)
        {
            while (Dialog.textDialog[Dialog.dialogPage] == "next")
            {
                words = null;
                textDialog = Dialog.textDialog[Dialog.dialogPage += 1];

                timeScreen.isCanClick = false;

                foreach (char t in textDialog)
                {
                    words += t;

                    tmp_text.text = words;

                    yield return new WaitForSeconds(delay);
                }

                Debug.Log(Dialog.textDialog[Dialog.dialogPage]);

                if (Dialog.textDialog[Dialog.dialogPage += 1] == "next")
                {
                    yield return new WaitForSeconds(2f);
                }
                else
                {
                    break;
                }
            }
        }
        else if (isGameplay && isPlayerPlay)
        {
            while (Dialog.textDialog[Dialog.dialogPage += 1] == "next")
            {
                words = null;
                textDialog = Dialog.textDialog[Dialog.dialogPage += 1];

                timeScreen.isCanClick = false;

                foreach (char t in textDialog)
                {
                    words += t;

                    tmp_text.text = words;

                    yield return new WaitForSeconds(delay);
                }

                if (Dialog.textDialog[Dialog.dialogPage += 1] == "next")
                {
                    yield return new WaitForSeconds(2f);
                    Dialog.dialogPage += 1;
                }
                else
                {
                    break;
                }
            }
        }
        yield return new WaitForSeconds(2f);

        tmp_text.text = "";
    }
}
