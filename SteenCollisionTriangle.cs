using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteenCollisionTriangle : MonoBehaviour
{
    private AudioScript _audio;
    public Sprite _damagesprite;
    private int fallDamage;
    private float _number;
    private GameObject _particle;
    [SerializeField]
    private GameObject _particle1;
    [SerializeField]
    private GameObject _particle2;
    [SerializeField]
    private GameObject _particle3;


    void Start()
    {
        _audio = GetComponent<AudioScript>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (Mathf.Abs(other.relativeVelocity.y) > 5f)
        {
            GameObject _sprite = this.gameObject.transform.GetChild(0).gameObject;
            _sprite.GetComponent<SpriteRenderer>().sprite = _damagesprite;
            NewParticle();
            Instantiate(_particle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(0f, 0f, Random.Range(0f, 359f)));
            NewParticle();
            Instantiate(_particle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(0f, 0f, Random.Range(0f, 359f)));
            NewParticle();
            Instantiate(_particle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(0f, 0f, Random.Range(0f, 359f)));
        }
        if (Mathf.Abs(other.relativeVelocity.y) > 9f)
        {
            Destroy(this.gameObject);
            _audio.DestroySound();
        }
    }
    void NewParticle()
    {
        _number = Random.Range(0f, 100f);
        Debug.Log(_number);
        if (_number < 34)
        {
            _particle = _particle1;
        }
        else if (_number < 67)
        {
            _particle = _particle2;
        }
        else
        {
            _particle = _particle3;
        }
    }
}