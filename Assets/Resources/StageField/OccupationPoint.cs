using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.StageField
{
    public class OccupationPoint : MonoBehaviour
    {
        public enum E_Owner
        {
            Player,
            Enemy,
            Neutrality,
            End,
        }

        public E_Owner m_owner;

        public List<GameObject> m_linkedPoints;
        private GameObject m_lineDrawer;

        private void Awake()
        {
            m_lineDrawer = UnityEngine.Resources.Load<GameObject>("StageField/LineDrawer");
        }

        // Start is called before the first frame update
        void Start()
        {
            var temp = new GameObject();
            var tempScript = new LineDrawer();

            foreach (var item in m_linkedPoints)
            {
                temp = new GameObject();
                temp = GameObject.Instantiate(m_lineDrawer, transform.position, Quaternion.identity);
                temp.transform.parent = transform;

                tempScript = new LineDrawer();
                tempScript = temp.GetComponent<LineDrawer>();
                tempScript.SetValue(item);
            }

            UpdateOwnerColor();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public E_Owner Owner
        {
            get
            {
                return m_owner;
            }
            set
            {
                m_owner = value;
                UpdateOwnerColor();
            }
        }

        private void UpdateOwnerColor()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            switch (m_owner)
            {
                case E_Owner.Player:
                    spriteRenderer.color = Color.blue;
                    break;
                case E_Owner.Enemy:
                    spriteRenderer.color = Color.red;
                    break;
                case E_Owner.End:
                    break;
                default:
                    break;
            }
        }
    }
}