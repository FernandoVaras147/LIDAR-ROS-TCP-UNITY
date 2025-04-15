using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidar : MonoBehaviour
{
    public float range_max = 12f;
    public float range_min = 0.4f;
    public int samples = 360; // resolución angular (ej. 360 → 0.5° si Lidar_Angle=180)
    public float Lidar_Angle = 180f;
    public float Frequency = 5;

    public int numberOfLayers = 16;
    public float angle_min = -10f;
    public float angle_max = 10f;

    public float time_increment = 0;
    public float angle_increment;
    private float vertIncrement;

    public float[] ranges;
    public Vector3[] directions;
    public Vector3 Direction_Lidar = Vector3.forward;

    private LaserScanVisualizer[] laserScanVisualizers;
    public List<Vector3> points = new List<Vector3>();

    void Start()
    {
        int totalRays = samples * numberOfLayers;
        ranges = new float[totalRays];
        directions = new Vector3[totalRays];
        angle_increment = Lidar_Angle / samples;
        vertIncrement = (angle_max - angle_min) / (numberOfLayers - 1);
        time_increment = ((1f / Frequency) / samples) * 1000f;
    }

    public float[] Scan()
    {
        MeasureDistance();

        laserScanVisualizers = GetComponents<LaserScanVisualizer>();
        if (laserScanVisualizers != null)
        {
            foreach (var visualizer in laserScanVisualizers)
            {
                visualizer.SetSensorData(transform, directions, ranges, range_min, range_max);
            }
        }

        return GetPointArray();
    }

    private float[] GetPointArray()
    {
        float[] data = new float[points.Count * 3];
        int i = 0;

        foreach (var point in points)
        {
            data[i++] = point.z;
            data[i++] = -point.x;
            data[i++] = point.y;
        }

        return data;
    }

    private void MeasureDistance()
    {
        int totalRays = samples * numberOfLayers;
        ranges = new float[totalRays];
        directions = new Vector3[totalRays];
        points.Clear();

        Vector3 origin = transform.position;
        Vector3 dir;
        RaycastHit hit;

        for (int i = 0; i < samples; i++)
        {
            float yawAngle = i * angle_increment;

            for (int j = 0; j < numberOfLayers; j++)
            {
                int index = j + i * numberOfLayers;
                float pitchAngle = angle_min + j * vertIncrement;

                dir = Quaternion.Euler(-pitchAngle, yawAngle, 0) * Direction_Lidar;
                Vector3 worldDir = transform.rotation * dir;
                directions[index] = worldDir;

                if (Physics.Raycast(origin, worldDir, out hit, range_max))
                {
                    if (hit.distance >= range_min)
                    {
                        ranges[index] = hit.distance;
                        points.Add(worldDir * hit.distance);
                        Debug.DrawLine(origin, hit.point, Color.red, 0.1f);
                    }
                    else
                    {
                        Debug.DrawLine(origin, origin + worldDir * range_max, Color.green, 0.1f);
                    }
                }
                else
                {
                    Debug.DrawLine(origin, origin + worldDir * range_max, Color.green, 0.1f);
                }
            }
        }
    }
}
