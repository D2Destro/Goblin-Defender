using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour {

    public Transform towerSpot;

    private TargetManager targetManager;
    private AllyShoot allyShoot;
	// Use this for initialization
	void Start () {
        allyShoot = GetComponent<AllyShoot>();
        targetManager = GameObject.FindObjectOfType<TargetManager>().GetComponent<TargetManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(targetManager.targets.Count > 0)
        {
            allyShoot.target = targetManager.targets[0].transform;
        }
        else
        {
            allyShoot.target = null;
        }
	}

    public void Attack()
    {

    }
}
