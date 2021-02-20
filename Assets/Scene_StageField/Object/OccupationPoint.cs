using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupationPoint : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
