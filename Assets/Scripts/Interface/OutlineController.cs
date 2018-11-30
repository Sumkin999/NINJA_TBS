using cakeslice;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class OutlineController:MonoBehaviour
    {
        public Outline Outline;

        void Start()
        {
            Outline.enabled = false;
        }

        void OnMouseExit()
        {
            Outline.enabled = false;
        }

        void OnMouseOver()
        {
            Outline.enabled = true;
        }
    }
}