using UnityEngine;

namespace DesertStormZombies.Items 
{
    [RequireComponent(typeof(MeshFilter))]
    public abstract class Item : MonoBehaviour
    {
        private Mesh mesh;

        protected virtual void Start()
        {
            mesh = GetComponent<MeshFilter>().mesh;
        }
    }
}