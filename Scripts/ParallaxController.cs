using UnityEngine;

namespace Shmup
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] Transform[] backgrounds; //Array background layers
        [SerializeField] float smoothing = 10.0f;//smooth parralax effect
        [SerializeField] float multiplier = 15.0f;//parallax effect increments per layer

        Transform cam; //Reference main camera
        Vector3 previousCamPos; //Position of the camera in the previous frame

        void Awake() => cam = Camera.main.transform;

        void Start() => previousCamPos = cam.position;

        void Update()
        {
            //Iterate through each background layer
            for (var i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);
                
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}