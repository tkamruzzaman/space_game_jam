using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            videoPlayer.playbackSpeed = 1.0f;
            videoPlayer.Prepare();

            videoPlayer.prepareCompleted += OnVideoPrepared;
            videoPlayer.loopPointReached += (VideoPlayer vp) => { OnVideoFinished(); };
        }

        skipButton.onClick.AddListener(() => { 
            SoundManager.Instance.PlayButtonClick();
            OnVideoFinished();
        });

        SceneManager.sceneLoaded += OnSceneLoaded;
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        isVideoReady = true;
        //Debug.Log("Video is prepared and ready to play.");
        //videoCanvas.gameObject.SetActive(true);
        //PlayVideo();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == SceneNavigation.Instance.GetSceneIndex(Scenes.Video))
        {
            PlayVideo();
        }
    }

    public void PlayVideo( )
    {
        videoCanvas.gameObject.SetActive(true);

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

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if(videoPlayer){
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.loopPointReached -= (VideoPlayer vp) => { OnVideoFinished(); };
        }
    }

    public void OnVideoFinished()
    {
        StopVideo();
        videoCanvas.gameObject.SetActive(false);
        SceneNavigation.Instance.LoadScene(Scenes.Game);
    }
}

