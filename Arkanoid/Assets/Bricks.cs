using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public static int brickCount;

    // Start is called before the first frame update
    void Start()
    {
        brickCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        brickCount = transform.childCount;
    }
}
