using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles", fileName = "New Collectible")]
public class SoCollectible : ScriptableObject
{
    [SerializeField] private string CollectibleName;
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite OutlineSprite;
    [SerializeField] private bool respawn;

    public string GetCollectible()
    {
        return CollectibleName;
    }

}
