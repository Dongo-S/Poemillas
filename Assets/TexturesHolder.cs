using System;
using System.Collections.Generic;
using UnityEngine;

using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;


[System.Serializable]
public class TextureHolder
{
    public string nameObject;
    public Renderer renderer;
  //  public Texture2D originalTexture;


    public Texture2D runtimeTexture;

    [HideInInspector]
    public Material materialGameObject;

    TextureComparer textureComparer;

    public List<string> palabras;
    public int indexMT;

    public void Start(TextureComparer textComparer)
    {
        this.textureComparer = textComparer;
        materialGameObject = renderer.materials[indexMT];
    }
    
    public string palabra = "";

    //public string Compare(Color32[] colores)
    //{
    //    // Obtenemos la textura de tiempo real
    //    runtimeTexture = ((RenderTexture)materialGameObject.mainTexture).ToTexture2D();
        
    //    // Obtenemos los colores de cada pixel en un array;
    //    Color[] textura1 = runtimeTexture.GetPixels();

    //    Color[] textura2;  //.GetPixels();
    //    Color32 tempColor1;

    //    uint[] values = new uint[colores.Length];



    //    Color prueba = Color.black;

    //    tempColor1 = textura1[0];
    //    double deltaE;

    //    var a = new Rgb { R = 149, G = 13, B = 12 };
    //    var b = new Rgb();


    //    //for (int j = 0; j < colores.Length; j++)
    //    //{
    //    //    b.R = colores[j].r;
    //    //    b.G = colores[j].g;
    //    //    b.B = colores[j].b;
    //    //    values[j] = 0;

    //    //    for (int i = 0; i < textura1.Length; i++)
    //    //    {
    //    //        tempColor1 = textura1[i];

    //    //        a.R = tempColor1.r;
    //    //        a.G = tempColor1.g;
    //    //        a.B = tempColor1.b;
    //    //        values[j] +=(uint)a.Compare(b, new Cie1976Comparison());
    //    //    }
    //    //    //Debug.Log("Value: " + values[j] + "\nColor " + colores[j]);
    //    //}

    //    //textureComparer.StartForBucle(a, b, values, textura1, tempColor1, palabras, (string pa) =>
    //    //{
    //    //    palabra = pa;
    //    //});

    //    //Debug.Log("Palabra " + palabra);
    //    //textureComparer.StartForBucle(a, b, values, textura1, tempColor1, palabras, MetodoPalabra);



    //    return palabra;

    //    //textureComparer.StartForBucle(a, b, values, textura1, tempColor1, palabras, MetodoPalabra);
    //    //uint low = uint.MaxValue;

    //    //for (int i = 0; i < values.Length; i++)
    //    //{
    //    //    if (values[i]< low)
    //    //        low = values[i];
    //    //}

    //    //for (int i = 0; i < values.Length; i++)
    //    //{
    //    //    if (values[i] == low)
    //    //    {
    //    //       // Debug.LogError("Palabra" + palabras[i]);
    //    //        return palabras[i];
    //    //    }
    //    //}

    //    //return palabras[0];  

    //    //    a.R = tempColor1.r;
    //    //    a.G = tempColor1.g;
    //    //    a.B = tempColor1.b;

    //    //    deltaE = a.Compare(b, new Cie1976Comparison());
    //}

    void MetodoPalabra(string pa)
    {
        this.palabra = pa;
        Debug.Log( pa);
    }



}
