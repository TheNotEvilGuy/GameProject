using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private GameObject player;
    private Vector3 velocity = Vector3.zero;
    private bool fixedCamera = false;

    public float moveSpeed = 5f;
    public float smoothTime = 35f;
    
    private void OnEnable()
    {
        fixedCamera = 0 != PlayerPrefs.GetInt("fixedCamera", 0);
    }

    private void FixedUpdate()
    {
        if (player && !fixedCamera)
        {
            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            Vector2 n = Vector2.Lerp(transform.position, dir, smoothTime);
            Vector3 edit = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x + n.x, player.transform.position.y + n.y, transform.position.z), ref velocity, smoothTime * Time.deltaTime);
            //Vector3 roundPos = new Vector3(RoundToNearestPixel(edit.x, GetComponent<Camera>()), RoundToNearestPixel(edit.y, GetComponent<Camera>()), transform.position.z);
            //transform.position = new Vector3(roundPos.x, roundPos.y, transform.position.z);
            transform.position = new Vector3(edit.x, edit.y, transform.position.z);
        }
    }

    private void LateUpdate()
    {
        fixedCamera = 0 != PlayerPrefs.GetInt("fixedCamera", 0);
        if (player && fixedCamera)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    private static float RoundToNearestPixel(float unityUnits, Camera view)
    {
        float valueInPixels = (Screen.height / (view.orthographicSize * 2)) * unityUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float adjustedUnityUnits = valueInPixels / (Screen.height / (view.orthographicSize * 2));
        return adjustedUnityUnits;
    }

    public void SetPlayer(GameObject thePlayer)
    {
        player = thePlayer;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
