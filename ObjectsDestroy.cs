using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDestroy : MonoBehaviour
{
    private AudioScript _audio;
    public Sprite _damagesprite;
    private int fallDamage;

    void Start()
    {
        _audio = GetComponent<AudioScript>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (Mathf.Abs(other.relativeVelocity.y) > 2f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _damagesprite;
        }
        if (Mathf.Abs(other.relativeVelocity.y) > 10f)
        {
            Destroy(this.gameObject);
            _audio.PigHurt();
        }
    }
}