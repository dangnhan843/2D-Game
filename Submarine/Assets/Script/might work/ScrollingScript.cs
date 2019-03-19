using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ScrollingScript : MonoBehaviour
{

    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);

    float timer;
    float destroyTime = 90.0f;

    void Start()
    {
       
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            speed = new Vector2(0, 0);
        }
        else
        {
            Vector3 movement = new Vector3(
                speed.x * direction.x,
                speed.y * direction.y,
                0);

            movement *= Time.deltaTime;
            transform.Translate(movement);
        }

        
    }
}
public static class rendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}