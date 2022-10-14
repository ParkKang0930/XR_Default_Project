using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Device_Selector : MonoBehaviour
{
    public void Start_Pico()
    {
        transform.GetChild(0).GetChild(1).GetComponent<ActionBasedController>().modelPrefab = Resources.Load<Transform>("VR/Prefabs/Controller/Pico (Neo3) - L");
        transform.GetChild(0).GetChild(2).GetComponent<ActionBasedController>().modelPrefab = Resources.Load<Transform>("VR/Prefabs/Controller/Pico (Neo3) - R");
    }
    public void Start_Oculus()
    {
        transform.GetChild(0).GetChild(1).GetComponent<ActionBasedController>().modelPrefab = Resources.Load<Transform>("VR/Prefabs/Controller/Oculus (Quest 2) - L");
        transform.GetChild(0).GetChild(2).GetComponent<ActionBasedController>().modelPrefab = Resources.Load<Transform>("VR/Prefabs/Controller/Oculus (Quest 2) - R");
    }
}
