using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private SoCollectible collectibleObject;
    [SerializeField] private Respawn respawnTime;

    public CollectibleColor color;
    private void Start()
    {
        Debug.Log(collectibleObject.GetCollectible());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            respawnTime.RespawnCollectItem();
        }
    }


}
