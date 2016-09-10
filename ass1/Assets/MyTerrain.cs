using UnityEngine;
using System.Collections;

public class MyTerrain : MonoBehaviour
{

    Terrain terrain;
    TerrainData terrainData;
    int resolution;
    float[,] heights;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        terrainData = terrain.terrainData;
        resolution = terrainData.heightmapWidth;//width = height = 513 by default
        heights = terrainData.GetHeights(0, 0, resolution, resolution);
        generateTerrain();
        terrain.terrainData.SetHeights(0, 0, heights);
    }

    void generateTerrain()
    {
        //init 4 corners
        heights[0, 0] = Random.Range(0, 1);
        heights[0, resolution - 1] = Random.Range(0, 1);
        heights[resolution - 1, 0] = Random.Range(0, 1);
        heights[resolution - 1, resolution - 1] = Random.Range(0, 1);

        int step = resolution;
        
        for(;step > 1;step /= 2)
        {
            int halfStep = step / 2;
            int x, y;
            float scale = step * 0.3f;
            
            for (x = halfStep; x < resolution; x += step)
                for (y = halfStep; y < resolution; y += step)
                    //calculate square mid point + random
                    heights[x, y] = square(x, y, halfStep) + 0.001f * (Random.value * 2 * scale - scale);

            for (x = 0; x < resolution; x += halfStep)
                for (y = (x + halfStep) % step; y < resolution; y += step)
                    //calculate diamond mid point + random
                    heights[x, y] = diamond(x, y, halfStep) + 0.001f * (Random.value * 2 * scale - scale);
        }
    }

    private bool boundary(int x, int y)
    {
        if (x >= 0 && x < resolution && y >= 0 && y < resolution)
            return true;

        else
            return false;
    }

    private float square(int x, int y, int step)
    {
        float average = 0.0f;
        float counter = 0.0f;

        if (boundary(x - step, y - step))
        {
            average += heights[x - step, y - step];
            counter++;
        }

        if (boundary(x - step, y + step))
        {
            average += heights[x - step, y + step];
            counter++;
        }

        if (boundary(x + step, y + step))
        {
            average += heights[x + step, y + step];
            counter++;
        }

        if (boundary(x + step, y - step))
        {
            average += heights[x + step, y - step];
            counter++;
        }

        return average / counter;
    }

    private float diamond(int x, int y, int step)
    {
        float average = 0.0f;
        float counter = 0.0f;

        if (boundary(x - step, y))
        {
            average += heights[x - step, y];
            counter++;
        }

        if (boundary(x + step, y))
        {
            average += heights[x + step, y];
            counter++;
        }

        if (boundary(x, y + step))
        {
            average += heights[x, y + step];
            counter++;
        }

        if (boundary(x, y - step))
        {
            average += heights[x, y - step];
            counter++;
        }

        return average / counter;
    }
}
