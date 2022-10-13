using UnityEngine;

public class PlayerAnimatorEvents : MonoBehaviour
{
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private ParticleSystem walkEffect;
    public void PlayWalkSound()
    {
        audioController.PlayWalkSound();
        walkEffect.Play();
    }
}
