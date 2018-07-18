using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour {

    private TargetManager targetManager;
	// Use this for initialization
	void Start () {
        targetManager = GetComponentInParent<TargetManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        targetManager.targets.Add(other.gameObject);
    }
}
