using System;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public static CameraControll instance;
    [HideInInspector]
    [Header("Script")]
    TextAnimation textAnimation;
    [Header("References")]
    [SerializeField] public Camera mainCamera;
    [SerializeField] public Camera[] cameraList;
    [SerializeField] GameObject[] map;
    [Header("Configuration")]
    public int indexCamera = 0;
    public int indexMap = 0;
    public bool isChangeCam = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        textAnimation = TextAnimation.instance;
    }

    public void ChangeCamera()
    {
        if (isChangeCam)
        {
            if (indexCamera < cameraList.Length)
            {
                cameraList[indexCamera].gameObject.SetActive(false);

                indexCamera++;

                if (cameraList[indexCamera].tag == "CameraMap2")
                {
                    ChangeMap();
                }

                cameraList[indexCamera].gameObject.SetActive(true);

                Dialog.activeDialog = true;

                StartCoroutine(textAnimation.AnimationTextDelay(textAnimation.delay, false));
            }
        }
    }
    void ChangeMap()
    {
        if (indexMap < map.Length)
        {
            map[indexMap].SetActive(false);

            indexMap++;

            map[indexMap].SetActive(true);
        }
    }
}
