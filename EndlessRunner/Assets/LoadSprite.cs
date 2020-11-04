using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    Sprite[] sprites;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(spriteName);
        int random = Random.Range(0, sprites.Length);

        sprite.sprite = sprites[random];
    }
    
}
