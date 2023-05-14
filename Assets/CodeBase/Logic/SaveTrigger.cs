using CodeBase.Infrastructure.SaveLoad;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SaveTrigger:MonoBehaviour
    {
        private ISaveLoadService _saveLoadService;

        public BoxCollider Colider;
        
        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {    
            _saveLoadService.SaveProgress();
            Debug.Log("Progress Saved");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if(!Colider)
              return;
                
            Gizmos.color = new Color32(30,200,30,130);
            Gizmos.DrawCube(transform.position + Colider.center, Colider.size);
        }
    }
}