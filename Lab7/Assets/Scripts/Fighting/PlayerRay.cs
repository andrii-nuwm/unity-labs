using UnityEngine;

namespace Fighting
{

    public class PlayerRay : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        [SerializeField] private int damageValue;
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0) == false)
                return;
                
            Ray ray = new Ray(camera.position, camera.forward);
            Debug.DrawRay(camera.position, camera.forward * 100, Color.yellow);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if(enemy != null)
                {
                    Debug.Log("Hit enemy");
                    enemy.Damage(damageValue);
                }
            }
        }
        
    }
}