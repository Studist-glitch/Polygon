using System;
using System.Collections.Generic;
using UnityEngine;

namespace Polygon
{
    public class ControllerCollision : MonoBehaviour
    {
        [SerializeField] private ControllerPhysicalMaterial controllerPhysical;
        public List<string> ContactCollision {get; private set;} = new();
        public List<string> GroundTags;

        private void OnCollisionEnter(Collision collision)
        {
            string tag = collision.collider.tag;
            
            if (GroundTags.Contains(tag))
            {
                ContactCollision.Add(collision.collider.tag);
                controllerPhysical.PhysicMaterial(true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            ContactCollision.Remove(collision.collider.tag);
            controllerPhysical.PhysicMaterial(false);
        }
    }

    [Serializable]
    public class ControllerPhysicalMaterial
    {
        public PhysicMaterial material;

        public ControllerPhysicalMaterial(PhysicMaterial material)
        {
            this.material = material;
        }

        public void PhysicMaterial(bool IsGround)
        {
            material.frictionCombine = IsGround ? PhysicMaterialCombine.Average : PhysicMaterialCombine.Minimum;
        }
    }
}