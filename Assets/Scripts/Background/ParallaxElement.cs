using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startPosX, startPosY, length;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startPosY = transform.position.y;
        startPosX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosX + dist, startPosY, transform.position.z);

        if (temp > startPosX + length) startPosX += length * 2;
        else if (temp < startPosX - length) startPosX -= length * 2;
    }
}