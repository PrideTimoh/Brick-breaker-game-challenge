using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{

    public int brickValue;
    private GameMan theGM;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameMan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBrick()
    {
        theGM.AddScore(brickValue);
        Destroy(gameObject);
    }
}
