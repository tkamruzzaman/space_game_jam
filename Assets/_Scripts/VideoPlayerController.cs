using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private string videoUrl = "https://youtu.be/gKbwYo575sQ";
    [SerializeField] private VideoPlayer videoPlayer;

    private bool isVideoReady;

    [SerializeField] private Canvas videoCanvas;
    [SerializeField] private Button skipButton;

    void Awake()
    {
        videoCanvas.gameObject.SetActive(false);

        if(videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();
        if(videoPlayer){
            videoPlayer.url = videoUrl;
            videoPlayer.playOnAwake = false;
            videoPlayer.Prepare();

            videoPlayer.prepareCompleted += OnVideoPrepared;
        }

        skipButton.onClick.AddListener(() => { 
            videoPlayer.Stop(); 
            videoCanvas.gameObject.SetActive(false);
        });
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        isVideoReady = true;
        //Debug.Log("Video is prepared and ready to play.");
        //videoCanvas.gameObject.SetActive(true);
        //PlayVideo();
    }

    public void PlayVideo( )
    {
        if (isVideoReady)
        {
            videoPlayer.Play();
        }
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }
}

