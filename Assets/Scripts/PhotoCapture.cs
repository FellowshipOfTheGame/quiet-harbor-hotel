using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Camera polaroidCam;
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject viewfinderInterface;

    [Header("Camera Flash")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fade")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Audio")]
    [SerializeField] private AudioSource cameraSfx;

    private Texture2D screenCapture;

    private Vector3 sidePosition = new Vector3(-783, -355, 0);
    private Vector3 defaultPosition = Vector3.zero;
    private Vector3 sideScale = new Vector3(0.4f, 0.4f);
    private Vector3 defaultScale = Vector3.one;

    private bool viewingPhoto;
    private bool isMaximized;
    private bool cameraActive;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); 
    }

    private void Update()
    {

        if (Input.GetButton("Fire2") && !isMaximized)
        {
            cameraActive = true;
            viewfinderInterface.SetActive(true);
        } else
        {
            cameraActive = false;
            viewfinderInterface.SetActive(false);
        }               

        if (Input.GetButtonDown("Fire1"))
        {
            if (!viewingPhoto && cameraActive)
            {
                polaroidCam.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height);
                StartCoroutine(CapturePhoto());
            }
            else
            {
                if (!isMaximized)
                {
                    RemovePhoto();
                }
            }
        }

        if (Input.GetButtonDown("Jump") && !cameraActive)
        {
            isMaximized = true;
            if (viewingPhoto)
            {
                MaximizePhoto(); 
            }
        }

        if (Input.GetButtonUp("Jump") && isMaximized)
        {
            isMaximized = false;
            MinimizePhoto();
        }
    }
    IEnumerator CameraFlashEffect()
    {
        cameraSfx.Play();
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    IEnumerator CapturePhoto()
    {
        StartCoroutine(CameraFlashEffect());
        RenderTexture renderTexture = polaroidCam.targetTexture;
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        RenderTexture.active = renderTexture;
        Rect regionToRead = new Rect(0, 0, renderTexture.width, renderTexture.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

        ShowPhoto();
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
        photoFrame.SetActive(true);
        fadingAnimation.Play("PhotoFadeIn");
    }
    void RemovePhoto()
    {
        viewingPhoto = false;
        isMaximized = false;
        photoFrame.SetActive(false);
        MinimizePhoto();
    }

    void MaximizePhoto()
    {
        photoFrame.GetComponent<Transform>().localScale = defaultScale;
        photoFrame.GetComponent<Transform>().localPosition = defaultPosition;
    }

    void MinimizePhoto()
    {
        photoFrame.GetComponent<Transform>().localScale = sideScale;
        photoFrame.GetComponent<Transform>().localPosition = sidePosition;
    }

}
