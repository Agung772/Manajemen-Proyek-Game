using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Vector3 offset;

    float offsetY;
    private void Start()
    {
        offset = transform.localPosition;
        transform.parent = null;

        offsetY = 22;
    }
    Quaternion angleCamQt;
    string condition;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);

        float angle = target.eulerAngles.y;


        if (angle > 75 && angle < 105 && condition != "Right")
        {
            condition = "Right";
            offset = new Vector3(-8, offsetY, 0);
            angleCamQt = Quaternion.Euler(65, 90, 0);
            MapManager.instance.AngleMap("Right");
        }
        else if (angle > 165 && angle < 195 && condition != "Back")
        {
            condition = "Back";
            offset = new Vector3(0, offsetY, 8);
            angleCamQt = Quaternion.Euler(65, 180, 0);
            MapManager.instance.AngleMap("Back");
        }
        else if (angle > 255 && angle < 285 && condition != "Left")
        {
            condition = "Left";
            offset = new Vector3(8, offsetY, 0);
            angleCamQt = Quaternion.Euler(65, 270, 0);
            MapManager.instance.AngleMap("Left");
        }
        else if ((angle > 345 || angle < 15) && condition != "Forward")
        {
            condition = "Forward";
            offset = new Vector3(0, offsetY, -8);
            angleCamQt = Quaternion.Euler(65, 0, 0);
            MapManager.instance.AngleMap("Forward");
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, angleCamQt, 2 * Time.deltaTime);
    }
}
