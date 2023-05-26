using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodiCompras : MonoBehaviour
{
  


    //public FMOD.Studio.EventInstance instance_Compras_Win = FMODUnity.RuntimeManager.CreateInstance("event:/Compras/Win");
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.LoadBank("bank:/Compras");

  
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
