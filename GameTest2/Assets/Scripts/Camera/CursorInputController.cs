using UnityEngine;

namespace Fayet.Tracking
{
    public class CursorInputController : MonoBehaviour {
        
        [SerializeField] private GameObject go;
        private ICursorable trackObj;


        private void Awake() {
            if(!go.TryGetComponent<ICursorable>(out trackObj))
                throw new System.Exception("Game Object don`t have ICursorable interface");
        }
        private void Update() {
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");

            trackObj.TrackCursor(horizontal, vertical);
        }



    }
    
        
    
}