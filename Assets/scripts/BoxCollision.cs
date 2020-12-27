using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    //public Skeleton skel;
    public WaterWave WaterWave;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        void OnTriggerEnter2D(Collider2D col)
        {
            WaterWave.col=col;
            WaterWave.ground=true;
        }
        void OnTriggerExit2D()
        {
            WaterWave.ground=false;
        }
}
