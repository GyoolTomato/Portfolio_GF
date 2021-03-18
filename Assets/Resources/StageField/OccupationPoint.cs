using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_StageField;
using Assets.Scene_StageField.Board.Controller;

namespace Assets.Resources.StageField
{
    public class OccupationPoint : MonoBehaviour
    {
        public enum E_PointType
        {
            MainPoint,
            HeliPortPoint,
            NormalPoint,
            End,
        }

        public enum E_Owner
        {
            Player,
            Enemy,
            Neutrality,
            End,
        }

        public E_PointType m_pointType;
        public E_Owner m_owner;
        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private PointController m_pointController;

        public List<OccupationPoint> m_linkedPoints;
        private GameObject m_lineDrawer;

        private void Awake()
        {
            m_lineDrawer = UnityEngine.Resources.Load<GameObject>("StageField/LineDrawer");
        }

        // Start is called before the first frame update
        void Start()
        {
            m_stageFieldManager = GameObject.Find("Manager").GetComponent<StageFieldManager>();
            m_touchController = m_stageFieldManager.GetBoardManager().GetTouchController();
            m_pointController = m_stageFieldManager.GetBoardManager().GetPointController();

            foreach (var item in m_linkedPoints)
            {                
                var temp = GameObject.Instantiate(m_lineDrawer, transform.position, Quaternion.identity);
                temp.transform.parent = transform;

                var tempScript = temp.GetComponent<LineDrawer>();
                tempScript.SetValue(item);
            }

            UpdateOwnerColor();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_touchController.IsClick() && m_touchController.GetClickObject() == gameObject)
            {
                m_pointController.ClickOccupationPoint(this);
            }
        }

        public E_PointType GetPointType()
        {
            return m_pointType;
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

        public List<OccupationPoint> GetLinkedPoints()
        {
            return m_linkedPoints;
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