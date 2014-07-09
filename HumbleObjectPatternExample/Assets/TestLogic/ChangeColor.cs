using Assets.TestLogic;
using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour, IChangeColor
{

	// Use this for initialization
	public void Start ()
	{
        Debug.Log("Start()");
        if (!gameObject.GetComponent("MeshRenderer")) gameObject.AddComponent("MeshRenderer");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ChangeColorPlease()
    {
        gameObject.renderer.material.color = new Color(((float)Random.Range(0, 255) / 255.0f), ((float)Random.Range(0, 255) / 255.0f), ((float)Random.Range(0, 255) / 255.0f));
    }

    public Color GetColor()
    {
        return gameObject.renderer.material.color;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}