using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateOpacity : MonoBehaviour
{
	#region Variables (public)
	public float speed = 0.5f;
	#endregion

	#region Variables (protected)

	#endregion

	#region Variables (private)
    private UnityEngine.UI.Text _text;
	#endregion

	#region Getters_Setters

	#endregion

	#region Unity
	// Use this for initialization
	private void Start()
	{
        _text = GetComponent<UnityEngine.UI.Text>();
	}

	// Update is called once per frame
	private void Update()
	{
        if(_text.color.a < 255)
        {
            _text.color = (new Color(255, 255, 255, _text.color.a) + new Color(0, 0, 0, speed * Time.deltaTime));
        }
	}
	#endregion

	#region Custom

	#endregion
}