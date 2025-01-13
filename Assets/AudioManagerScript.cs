using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip gameOver;
    public AudioClip winner;
    public AudioClip checkPoint;
    public AudioClip soundGun;
    public AudioClip takeHit;
    public AudioClip enemyTakeHit;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void playMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void pauseMusic()
    {

        if (musicSource.isPlaying) // Chỉ dừng nếu nhạc đang phát
        {
            musicSource.Pause();
        }
    }

}
