using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyShoot : MonoBehaviour {

    public float projectilePerSecond;
    public GameObject ball;
    public Transform target;
    [SerializeField] private float firepower;
    private float timestamp;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.fixedTime >= timestamp && target != null)
        {

            Shoot();


            timestamp = Time.fixedTime + 1 / projectilePerSecond;
        }
    }

    private void Shoot()
    {
        transform.LookAt(target);
        GameObject thisCannonBall = Instantiate(ball);
        thisCannonBall.transform.position = (transform.position + Vector3.up*3f) + (transform.forward * 2f);
        //thisCannonBall.GetComponent<Rigidbody>().AddRelativeForce(Camera.main.transform.forward*firepower, ForceMode.Impulse);
        thisCannonBall.GetComponent<Rigidbody>().velocity = transform.forward * firepower;
    }

    public void ShootTarget ()
    {

    }
}
