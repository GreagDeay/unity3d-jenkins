using UnityEngine;
using System.Collections;

public class TestGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "push"))
        {
            int id = Random.Range(1, 4);
            Debug.Log(id);
            GameObject.Find("Cube" + id).GetComponent<ChangeColor>().ChangeColorPlease();
        }
    }
}
