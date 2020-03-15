using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rigidbody2D.velocity = MathfExtentions.DegreeToVector2(Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
