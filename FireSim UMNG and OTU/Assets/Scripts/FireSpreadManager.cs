using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FireSpreadManager : MonoBehaviour
{
    private List<Fire> fireList = new List<Fire>();
    public bool allFiresOut = false;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] GameObject firePrefab;
    public static FireSpreadManager Instance { get; private set; }

    [Header("Task Ui")]
    public TextMeshProUGUI taskDone;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartFire();
    }

    private void StartFire()
    {
        int selectedSpawn = Random.Range(0, spawnPoints.Count);

        GameObject newFire = Instantiate(firePrefab, spawnPoints[selectedSpawn].position, Quaternion.identity, this.gameObject.transform);
        fireList.Add(newFire.GetComponent<Fire>());
    }
    public void UpdateFires()
    {
        foreach (Fire fire in fireList)
        {
            if (fire.isLit)
            {
                return;
            }
        }
        taskDone.fontStyle = FontStyles.Strikethrough;
        allFiresOut = true;
    }

    public void SpreadFire(Transform rootPos)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // Ensure the position is on the floor
        Vector3 randomPosition = rootPos.position + randomDirection.normalized * 1f;

        RaycastHit hit;
        if (Physics.Raycast(rootPos.position, randomDirection, out hit, 1f))
        {
            randomPosition = hit.point + hit.normal * 0.1f; // Adjust position in front of obstacle
        }

        // Check if the position is grounded
        if (Physics.Raycast(randomPosition, Vector3.down, out hit, Mathf.Infinity))
        {
            randomPosition = hit.point;
        }

        GameObject newFire = Instantiate(firePrefab, randomPosition, Quaternion.identity, this.gameObject.transform);
        fireList.Add(newFire.GetComponent<Fire>());

    }
}
