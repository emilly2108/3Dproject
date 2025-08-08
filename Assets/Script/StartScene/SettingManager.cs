using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPrefab;

    private void Start()
    {
        Instantiate(settingsPrefab);
    }
}
