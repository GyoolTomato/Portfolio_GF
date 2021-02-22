using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scene_StageField;
using Assets.Scene_StageField.Controller;

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
        private StageFieldManager m_stageFieldManager;
        private TouchController m_touchController;
        private PointController m_pointController;
        private CharacterController m_characterController;

        public List<GameObject> m_linkedPoints;
        private GameObject m_lineDrawer;
        private GameObject m_playerPlatoon;

        private void Awake()
        {
            m_lineDrawer = UnityEngine.Resources.Load<GameObject>("StageField/LineDrawer");
            m_playerPlatoon = UnityEngine.Resources.Load<GameObject>("StageField/Player");
        }

        // Start is called before the first frame update
        void Start()
        {
            m_stageFieldManager = GameObject.Find("Manager").GetComponent<StageFieldManager>();
            m_touchController = m_stageFieldManager.GetTouchController();
            m_pointController = m_stageFieldManager.GetPointController();
            m_characterController = m_stageFieldManager.GetCharacterController();

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
            if (m_touchController.GetClickObject() == gameObject)
            {
                CallPlatoon();
                m_characterController.Move(this);
            }
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

        public List<GameObject> LinkedPoints()
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

        private void CallPlatoon()
        {
            if (GameObject.Find("Player(Clone)") == null)
            {
                var player = Instantiate(m_playerPlatoon, transform.position, Quaternion.identity);
                player.transform.parent = GameObject.Find("Map").transform;
                var playerScript = player.GetComponent<Player>();
                playerScript.SetValue(null, this);
            }
        }
    }
}