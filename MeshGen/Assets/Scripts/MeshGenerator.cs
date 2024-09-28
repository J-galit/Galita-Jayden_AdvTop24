using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;

    public float scale = .3f;

    public float distanceBetweenVerts;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        

        CreateShape();
        UpdateMesh();
        
    }

    //Fractal Noise layering perlin noise.
    void CreateShape()
    {
        //List of vertices for the triangle
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        //Creates a grid of vertices
        for (int i =0, z = 0; z <= zSize; z++) 
        { 
            for (int x = 0; x <= xSize; x++)
            {
                //Randomizes the perlin noise
                float offsetX = Random.Range(1, 9999);
                float offsetZ = Random.Range(1, 9999);

                //The multiple for scale
                float xCoord = (x * 1 / scale);// + offsetX);
                float zCoord = (z * 1 / scale);//  + offsetZ);


                float y = Mathf.PerlinNoise( xCoord, zCoord) * 32f +
                          Mathf.PerlinNoise(xCoord * 2, zCoord * 2) * 16f +
                          Mathf.PerlinNoise(xCoord * 4, zCoord * 4) * 8f;

                vertices[i] = new Vector3(x * distanceBetweenVerts, y, z * distanceBetweenVerts);
                i++;
            }
        }

        //List of triangles
        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        //Turns the vertices into triangles, must be in a specified order so Unity reneders them forward.
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {


                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;

                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

    }

    void UpdateMesh()
    {
        //Clears old mesh data.
        mesh.Clear();

        //Tells the mesh its vertices and triangles.
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        GetComponent<MeshCollider>().sharedMesh = mesh;

        //Adjusts normals for lighting.
        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }


}
