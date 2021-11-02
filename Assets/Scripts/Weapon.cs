using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //heittovoima
    public float throwForce = 10f;
    
    //heittävä-heitettävä objekti
    public GameObject throwObjPrefab;
    
    //yhteys pääkameraan / maincamera
    Camera FPSCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        // kutsutaan kameraa
        FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //ampuu kun painetaan nappulaa
        if(Input.GetButtonDown("Fire1")){
            //funktiokutsu throw() -funktioon
            Throw();
        }
        
    }

    public void Throw(){
        GameObject apple = Instantiate(throwObjPrefab, transform.position, Quaternion.identity);
        apple.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * throwForce, ForceMode.Impulse);
    }
}
