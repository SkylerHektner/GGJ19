using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
	#region Variables (public)
    public float speed = 1.0f;
	#endregion

	#region Variables (protected)

	#endregion

	#region Variables (private)
	private RectTransform _rTransform;
	#endregion

	#region Getters_Setters

	#endregion

	#region Unity
	// Use this for initialization
	private void Start()
	{
        _rTransform = GetComponent<RectTransform>();
	}

	// Update is called once per frame
	private void Update()
	{
        //transform.position += speed * Time.deltaTime * Vector3.right;
		_rTransform.sizeDelta += speed * Time.deltaTime * Vector2.right;
	}
	#endregion

	#region Custom

	#endregion
}