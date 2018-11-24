using Assets.Scripts.GameMechanic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class EnemyHealth:MonoBehaviour
    {
        public Transform OffsetTransform;
        public RectTransform Transform;
        public Slider Slider;
        public Canvas Canvas;
        public GameUnit GameUnit;

        public void Start()
        {
            Transform = GetComponent<RectTransform>();
        }


        public void LateUpdate()
        {
            Vector3 screenPos = UnityEngine.Camera.main.WorldToScreenPoint(OffsetTransform.position);
            Vector2 movePos;

            Slider.gameObject.SetActive(screenPos.z > 0);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.transform as RectTransform, screenPos, Canvas.worldCamera, out movePos);
            Transform.position = Canvas.transform.TransformPoint(movePos);

            Slider.value = GameUnit.Health / GameUnit.MaxHealth;

            if (GameUnit.Health <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}