using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class CellMesh : MonoBehaviour {
    
    private Cell cell;
    private Mesh mesh;
    private float cellSize;

    private void Awake() {
        cell = transform.parent.GetComponent<Cell>();

        Debug.Log("Hello!");
    }

    
    
    private void Start() {
        //cellSize = cell.GetSize();
        
        CreateMesh();
    }

    private void CreateMesh() {
        mesh = GetComponent<MeshFilter>().mesh = new Mesh {
            name = "Hex Mesh"
        };

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        
        vertices.Add(Vector3.zero);
        vertices.Add(new Vector3(0f, 0f,cellSize / 2));
        vertices.Add(new Vector3(Mathf.Cos(Mathf.Deg2Rad * 30f) * cellSize / 2, 0f,cellSize / 4));
        vertices.Add(new Vector3(Mathf.Cos(Mathf.Deg2Rad * 30f) * cellSize / 2, 0f,-cellSize / 4));
        vertices.Add(new Vector3(0f, 0f,-cellSize / 2));
        vertices.Add(new Vector3(-Mathf.Cos(Mathf.Deg2Rad * 30f) * cellSize / 2, 0f,-cellSize / 4));
        vertices.Add(new Vector3(-Mathf.Cos(Mathf.Deg2Rad * 30f) * cellSize / 2, 0f,cellSize / 4));
        
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);
        
        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(3);
        
        triangles.Add(0);
        triangles.Add(3);
        triangles.Add(4);
        
        triangles.Add(0);
        triangles.Add(4);
        triangles.Add(5);
        
        triangles.Add(0);
        triangles.Add(5);
        triangles.Add(6);
        
        triangles.Add(0);
        triangles.Add(6);
        triangles.Add(1);

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        
        mesh.RecalculateNormals();
        
        if (transform.parent.TryGetComponent(out MeshCollider col)) {
            col.sharedMesh = mesh;
        }
    }
}
