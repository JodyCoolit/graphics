using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

    float keyboardmouseSpeed;
    float mouseSpeed;
    // Use this for initialization
    void Start () {
        keyboardmouseSpeed = 30f;
        mouseSpeed = 50;
	}
	
	// Update is called once per frame
	void Update () { 
        if (Input.GetKey(KeyCode.A))//a
        {
            transform.Translate(new Vector3(-keyboardmouseSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))//d
        {
            transform.Translate(new Vector3(keyboardmouseSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))//w
        {
            transform.Translate(new Vector3(0,0, keyboardmouseSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))//s
        {
            transform.Translate(new Vector3(0,0, -keyboardmouseSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Q))//q
        {
            transform.Rotate(0, 0, keyboardmouseSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))//e
        {
            transform.Rotate(0, 0, -keyboardmouseSpeed * Time.deltaTime);
        }

        transform.Rotate(0,Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime,0,Space.World);
        transform.Rotate(Input.GetAxis("Mouse Y") * -mouseSpeed * Time.deltaTime,0,0,Space.Self);
    }
}
