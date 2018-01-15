using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {

    public Transform target;
    public Transform leftBound;
    public Transform rightBound;
    private float left;
    public float speed = 5.0f;
    private float _nextCamTimer = 0;

    void Start()
    {
        AssignBird();
    }

    // Update is called once per frame
    void Update () {
        _nextCamTimer++;
        if (_nextCamTimer > 300)
        {
            NextBird();
        }
        if (target != null)
        {
            
            left = Input.GetAxis("Horizontal");
            Transform cam = GetComponent<Transform>();
            if (left == 0)
            {
                Vector3 newPos = transform.position;
                newPos.x = target.position.x;
                newPos.x = Mathf.Clamp(newPos.x, leftBound.transform.position.x, rightBound.transform.position.x);
                transform.position = newPos;
            }
            if (left != 0)
            {
                cam.position = cam.position + (Vector3.right * speed * Time.deltaTime);
                float camX = cam.position.x;
                camX = Mathf.Clamp(camX, leftBound.transform.position.x, rightBound.transform.position.x);
                cam.position = new Vector3(camX, cam.position.y, cam.position.z);
            }
        }
	}
    public void AssignBird()
    {
        _nextCamTimer = 0;
    }
    void NextBird()
    {
        GameObject[] _targets = GameObject.FindGameObjectsWithTag("Bird");
        if (_targets.Length > 0)
        {
            target = _targets[0].transform;
        }
    }
}
