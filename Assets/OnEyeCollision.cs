using UnityEngine;
using System.Collections;

public class OnEyeCollision : MonoBehaviour {

    public GameObject pupil;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        pupil.SetActive(false);
    }

    void OnTriggerExit(Collider other)
    {
        pupil.SetActive(true);
    }
}
