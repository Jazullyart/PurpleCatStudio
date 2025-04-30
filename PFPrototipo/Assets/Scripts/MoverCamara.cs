using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject chara;
    public Vector3 posIni;
    void Start()
    {
        //sposIni = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = posIni + chara.transform.position;
    }

}
