using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSwimmer : MonoBehaviour
{
    public float speed;
    private float edge = 15f;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 0)
        {
            transform.RotateAround(transform.position, transform.right, 180f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.x < -edge || transform.position.x > edge)
        {
            Destroy(gameObject);
        }
    }
}
