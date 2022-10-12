using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips collectItemAudioclips;
    [SerializeField] private SoAudioClips hitGroundAudioclips;
    [SerializeField] private SoAudioClips hitspikeAudioclips;
    [SerializeField] private SoAudioClips collectitemrespawnAudioclips;
    [SerializeField] private SoAudioClips jumppadAudioclips;
    [SerializeField] private SoAudioClips finishAudioclips;
    [SerializeField] private SoAudioClips deathAudioclips;


    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip());
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayCollectSound()
    {
        audioSource.PlayOneShot(collectItemAudioclips.GetAudioClip());
    }

    public void PlayHitground()
    {
        audioSource.PlayOneShot(hitGroundAudioclips.GetAudioClip());
    }

    public void PlayHitspike()
    {
        audioSource.PlayOneShot(hitspikeAudioclips.GetAudioClip());
    }

    public void PlayRespawnitem()
    {
        audioSource.PlayOneShot(collectitemrespawnAudioclips.GetAudioClip());
    }

    public void PlayJumppad()
    {
        audioSource.PlayOneShot(jumppadAudioclips.GetAudioClip());
    }

    public void PlayFinishline()
    {
        audioSource.PlayOneShot(finishAudioclips.GetAudioClip());
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathAudioclips.GetAudioClip());
    }
}
