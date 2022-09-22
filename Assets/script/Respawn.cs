using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float waitingTime;
    [SerializeField] private GameObject itemRespawn;

    public void RespawnCollectItem()
    {

       StartCoroutine(Respawns());

    }

    private IEnumerator Respawns()
    {

        yield return new WaitForSeconds(waitingTime);
        itemRespawn.SetActive(true);

    }
   

}