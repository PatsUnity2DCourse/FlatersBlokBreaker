using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLoader : MonoBehaviour {

    [SerializeField] Sprite[] backgrounds;

	// Use this for initialization
	void Start () {
        int randomindex = Random.Range(0, backgrounds.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = backgrounds[randomindex];
    }
	
}
