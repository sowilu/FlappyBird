using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager inst;

    [Header("Prefabs")]
    public GameObject pipe;

    [Header("Piple placement")]
    public float minStep;
    public float maxStep;
    public float minHeight;
    public float maxHeight;

    [Header("World")]
    public float speed;
    public int chunkSize;

    float lastX = 0;
    Queue<GameObject> pipes = new Queue<GameObject>();

    private void Awake()
    {
        if (inst == null)
            inst = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        for (int i = 0; i < chunkSize; i++)
        {
            InstantiatePipe();
        }
    }

    void InstantiatePipe()
    {
        var step = Random.Range(minStep, maxStep);
        lastX += step;

        var y = Random.Range(minHeight, maxHeight);

        var p = Instantiate(pipe, transform);

        p.transform.localPosition = new Vector3(lastX, y);
        pipes.Enqueue(p);
    }

    public void LoadPipe()
    {
        Invoke(nameof(DestroyPipe), 2f);

        InstantiatePipe();
    }

    void DestroyPipe()
    {
        var p = pipes.Dequeue();
        Destroy(p);
    }
    private void Update()
    {
        transform.position += -Vector3.right * speed * Time.deltaTime;
    }
}
