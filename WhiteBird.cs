using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBird : MonoBehaviour {

    private AudioScript _audio;
    private float _number;
    private int fallDamage;
    private GameObject _particle;
    [SerializeField]
    private GameObject _particle1;
    [SerializeField]
    private GameObject _particle2;
    [SerializeField]
    private GameObject _animation;

    void Start()
    {
        _audio = GetComponent<AudioScript>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            for (int i = 0; i < 3; i++)
            {
                NewParticle();
            }
            Instantiate(_animation, transform.position, new Quaternion(0f, 0f, 0f, 0f));
            _audio.DestroySound();
            Destroy(this.gameObject);
        }
    }

    void NewParticle()
    {
        _number = Random.Range(0f, 100f);
        Debug.Log(_number);
        if (_number < 50)
        {
            _particle = _particle1;
        }
        else
        {
            _particle = _particle2;
        }
        Instantiate(_particle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(0f, 0f, Random.Range(0f, 359f)));
    }
}
