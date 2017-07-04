﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SixVertexMesh : MonoBehaviour
{
    [SerializeField] float speed = 90f;
    Mesh mesh;


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }


    // Use this for initialization
    void Update()
    {

        MakeMeshData();

        /*
        //assign points
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(-1, -1, 0);
        vertices[1] = new Vector3(0, 0.5f, 0);
        vertices[2] = new Vector3(1, -1, 0);
        mesh.vertices = vertices;

        //assign triangles
        int[] triangles = new int[3] { 0, 1, 2};
        mesh.triangles = triangles;

        //Vector3[] normals = new Vector3[1];
        //normals[0] = Vector3.Cross(vertices[1]-vertices[0], vertices[2] - vertices[1]);
        //Vector3[] normals = new Vector3[3];
        //normals[0] = Vector3.back; normals[1] = Vector3.back; normals[2] = Vector3.back;

        GetComponent<MeshFilter>().mesh = mesh;
        */
    }
    void MakeMeshData()
    {
        Vector3[] vertices = new Vector3[] {
        new Vector3(0, yvalue.ins.yValue, 0),
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(0, 0, 1),
        new Vector3(1, 0, 1) };

        //assign triangles
        int[] triangles = new int[] { 0, 1, 2, 3, 4, 5 };


        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

    }


    #region Update function


    /*
    private void Update()

    {
        Color32[] colors = new Color32[3];
        float offset = Time.time * speed;

        colors[0] = ColorFromHue(0 + offset);
        colors[1] = ColorFromHue(120 + offset);
        colors[2] = ColorFromHue(240 + offset);

        mesh.colors32 = colors;
    }
    */
    #endregion


    #region GDC Function
    //source https://en.wikipedia.org/wiki/HSL_and_HSV#From_HSV
    Color32 ColorFromHue(float h)
    {
        h = Mathf.Repeat(h, 360f);

        h /= 60;            // sector 0 to 5
        float s = 1; float v = 1; //saturation and value is both set to max
        float c = s * v;

        //HSV to RGB conversion
        Color32 returnCol = new Color32();
        returnCol.a = 255;

        int i;
        float f, p, q, t;

        if (s == 0)
        {
            // achromatic (grey)
            returnCol.r = (byte)(v * 255);
            returnCol.g = (byte)(v * 255);
            returnCol.b = (byte)(v * 255);
            return returnCol;
        }

        i = (int)System.Math.Floor((double)h);
        f = h - i;          // factorial part of h
        p = v * (1 - s);
        q = v * (1 - s * f);
        t = v * (1 - s * (1 - f));
        switch (i)
        {
            case 0:
                returnCol.r = (byte)(v * 255);
                returnCol.g = (byte)(t * 255);
                returnCol.b = (byte)(p * 255);
                break;
            case 1:
                returnCol.r = (byte)(q * 255);
                returnCol.g = (byte)(v * 255);
                returnCol.b = (byte)(p * 255);
                break;
            case 2:
                returnCol.r = (byte)(p * 255);
                returnCol.g = (byte)(v * 255);
                returnCol.b = (byte)(t * 255);
                break;
            case 3:
                returnCol.r = (byte)(p * 255);
                returnCol.g = (byte)(q * 255);
                returnCol.b = (byte)(v * 255);
                break;
            case 4:
                returnCol.r = (byte)(t * 255);
                returnCol.g = (byte)(p * 255);
                returnCol.b = (byte)(v * 255);
                break;
            default:        // case 5:
                returnCol.r = (byte)(v * 255);
                returnCol.g = (byte)(p * 255);
                returnCol.b = (byte)(q * 255);
                break;
        }

        return returnCol;
    }

    #endregion
}

