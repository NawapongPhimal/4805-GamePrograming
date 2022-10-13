using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float waitingTime;
    [SerializeField] private GameObject itemRespawn;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private ParticleSystem respawnParticle;

    public void RespawnCollectItem()
    {

       StartCoroutine(Respawns());

    }

    private IEnumerator Respawns()
    {

        yield return new WaitForSeconds(waitingTime);
        itemRespawn.SetActive(true);
        respawnParticle.Play();
        audioController.PlayRespawnitem();

    }
   

}