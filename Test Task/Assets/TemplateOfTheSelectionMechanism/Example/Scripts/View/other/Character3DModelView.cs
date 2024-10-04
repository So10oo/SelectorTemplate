using UnityEngine;

namespace SelectionTemplate.Example
{
    public class Character3DModelView : MonoBehaviour, IView<GameObject>
    {
        [SerializeField] Transform parent;

        GameObject objectView;
        public void ViewData(GameObject gameObject)
        {
            if (objectView != null)
                Destroy(objectView);
            objectView = Instantiate(gameObject, parent);
        }
    }
}