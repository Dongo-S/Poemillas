using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;
using UnityEngine.UI;


public class TextureComparer : MonoBehaviour
{
    public List<TextureHolder> gameObjects;

    public Color32[] colores;
    public Color32 vacio;
    public Color vacioBit;

    public GameObject ala1;
    public GameObject ala2;
    public GameObject polilla;
    public GameObject cursor;

    public float angulo1;
    public float angulo2;

    public GameObject contenedorUI;
    public GameObject contenedorHaiku;

    public TMPro.TextMeshProUGUI textoHaiku;

    public Image fillAmount;
    public float scaleAmountEnd = 0.8f;
    [TextArea(4, 5)]
    public string haiku;
    //public List<string> palabras;

    [SerializeField] DataScenesValues values;

    public Vector3 to = new Vector3(0.3f, 0.5f, 0f);

    public bool comparando = false;
    //public Renderer rabbitGameObject;
    //[SerializeField] Material rabbitMaterial;

    private void Awake()
    {
        values.storyHasBeenSeenRuntime = true;
    }

    //private void OnValidate()
    //{
    //    rabbitMaterial = rabbitGameObject.sharedMaterial;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //rabbitMaterial = rabbitGameObject.material;
        //rabbit = (Texture2D)rabbitMaterial.mainTexture;
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].Start(this);
        }

    }


    public void StartAnimation()
    {
        LeanTween.rotateLocal(ala1, new Vector3(0f, 0f, angulo1), 0.05f).setLoopPingPong(-1);
        LeanTween.rotateLocal(ala2, new Vector3(0f, 0f, angulo2), 0.05f).setLoopPingPong(-1);

    }


    [ContextMenu("Compare")]
    public void Compare()
    {

        if (comparando)
            return;


        comparando = true;
        //Debug.Log(rabbitMaterial.mainTexture);
        //Debug.Log(rabbitMaterial.mainTexture.GetType());

        //rabbitRuntimeTexture = ((RenderTexture)rabbitMaterial.mainTexture).ToTexture2D();

        contenedorUI.SetActive(false);

        //for (int i = 0; i < gameObjects.Count; i++)
        //{
        //    gameObjects[i].Compare(colores);
        //}

        fillAmount.transform.parent.gameObject.SetActive(true);

        StartCoroutine(MostrarHaiku());

        //}
    }



    // Update is called once per frame


    string[] palabrasFinal;
    IEnumerator MostrarHaiku()
    {
        yield return new WaitForEndOfFrame();

        palabrasFinal = new string[gameObjects.Count];

        //for (int i = 0; i < palabrasFinal.Length; i++)
        //{
        //    palabrasFinal[i] = "";
        //}

        //Debug.LogError(gameObjects.Count);
        for (int i = 0; i < gameObjects.Count; i++)
        {
            //palabrasFinal[i] = gameObjects[i].Compare(colores);

            yield return StartCoroutine(Compare(gameObjects[i]));

            
            palabrasFinal[i] = gameObjects[i].palabra;
            yield return null;
        }
        SetText();
        //textoHaiku.text = string.Format(haiku, palabras);

        // Iniciar Animación
        StartAnimation();
    }


    IEnumerator Compare(TextureHolder textureHolder)
    {
        ///System.GC.Collect();
        //Texture2D prueba = ScaleTexture((Texture2D)textureHolder.materialGameObject.mainTexture, 128, 128);
        //prueba.GetPixels();
        // Obtenemos la textura de tiempo real
        textureHolder.runtimeTexture = ((RenderTexture)textureHolder.materialGameObject.mainTexture).ToTexture2D();

        //textureHolder.runtimeTexture = ScaleTexture(textureHolder.runtimeTexture, 128, 128);

        Color32[] textura1 = textureHolder.runtimeTexture.GetPixels32(); ;
        Color32 tempColor1;

        int[] values = new int[colores.Length];


        tempColor1 = textura1[0];

        var a = new Rgb { R = 149, G = 13, B = 12 };
        var b = new Rgb();

        yield return StartCoroutine(BucleFor(a, b, values, textura1, tempColor1, textureHolder.palabras, textureHolder));

        // Debug.LogError(textureHolder.nameObject);
    }


    void SetText()
    {
        //for (int i = 0; i < palabrasFinal.Length; i++)
        //{
        //    Debug.LogError(palabrasFinal[i]);
        //}


        LeanTween.move(polilla, to, 5f);
        LeanTween.scale(polilla, Vector3.one * scaleAmountEnd, 0.5f);
        textoHaiku.text = string.Format(haiku, palabrasFinal);
        contenedorHaiku.SetActive(true);
        fillAmount.transform.parent.gameObject.SetActive(false);
        cursor.SetActive(false);
    }


    //public void StartForBucle(Rgb a, Rgb b, uint[] values, Color[] textura1, Color32 tempColor1, List<string> palabras,  System.Action<string> callbackOnFinish)
    //{
    //    StartCoroutine(BucleFor(a, b, values, textura1, tempColor1, palabras, callbackOnFinish));       
    //}

    IEnumerator BucleFor(Rgb a, Rgb b, int[] values, Color32[] textura1, Color32 tempColor1, List<string> palabras, TextureHolder textureHold)
    {
        var negro = new Rgb { R = 0, G = 0, B = 0 };

       // int[,] values2 = new int[3, 4];


        for (int i = 0; i < values.Length; i++)
        {
            values[i] = 0;
        }


        for (int i = 0; i < textura1.Length; i++)
        {
            tempColor1 = textura1[i];

            a.R = tempColor1.r;
            a.G = tempColor1.g;
            a.B = tempColor1.b;

            if (i % 10000 == 0)
            {

                // Debug.Log("Esperando...");
                fillAmount.fillAmount = i / (float)textura1.Length;
                //Debug.Log((float)i / textura1.Length * 3);
                yield return null;
            }

            if ((int)a.Compare(negro, new Cie1976Comparison()) == 0)
            {
                //Debug.Log("Negro");
                continue;
            }



            //for (int k = 0; k < 3; k++)
            //{
                for (int j = 0; j < 3; j++)
                {
                    b.R = colores[j].r;
                    b.G = colores[j].g;
                    b.B = colores[j].b;

                    values[j] += (int)a.Compare(b, new Cie1976Comparison());

                }
            //}

            //Debug.Log("Value: " + values[j] + "\nColor " + colores[j]);
        }


        //el valor mas pequeño significa que es más cercano al Color original


        //for (int i = 0; i < values.Length; i++)
        //{
        //    if (values[i] < low)
        //        low = values[i];
        //}

        int low = Mathf.Max(values);

        ////values2[0, 3] = Mathf.Min(values2[0, 0], values2[0, 1], values2[0, 2]);
        ////values2[1, 3] = Mathf.Min(values2[1, 0], values2[1, 1], values2[1, 2]);
        ////values2[2, 3] = Mathf.Min(values2[2, 0], values2[2, 1], values2[2, 2]);

        ////low = Mathf.Min(values2[0, 3], values2[1, 3], values2[2, 3]);
        ////for (int k = 0; k < 3; k++)
        ////{
        ////    if (low == values2[k, 3])
        ////    {
        ////        Debug.Log("<color=yellow>" + k + "</color>" +
        ////        "\nPalabra " + palabras[0] + " Values " + values2[0, 3] + "\t" + values2[1, 0] + "\t" + values2[2, 2] +
        ////        "\nPalabra " + palabras[1] + " Values " + values2[1, 3] + "\t" + values2[1, 0] + "\t" + values2[2, 2] +
        ////        "\nPalabra " + palabras[2] + " Values " + values2[2, 3] + "\t" + values2[1, 0] + "\t" + values2[2, 2]);

        ////        textureHold.palabra = palabras[k];
        ////        break;
        ////    }

        ////}

        //Random.InitState((int)(low*Random.value));
        
        textureHold.palabra = palabras[Random.Range(0,3)];

        //for (int i = 0; i < values.Length; i++)
        //{
        //    if (values[i] == low)
        //    {
        //        Debug.Log("<color=yellow>" + i + "</color>" +
        //        "\nPalabra " + palabras[0] + " Values " + values[0] + 
        //        "\nPalabra " + palabras[1] + " Values " + values[1] +
        //        "\nPalabra " + palabras[2] + " Values " + values[2]);

        //        textureHold.palabra = palabras[i];
        //        break;
        //        //SetText("a");
        //    }
        //}


    }
    private Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
{
    Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, true);
    Color[] rpixels = result.GetPixels(0);
    float incX = (1.0f / (float)targetWidth);
    float incY = (1.0f / (float)targetHeight);
    for (int px = 0; px < rpixels.Length; px++)
    {
        rpixels[px] = source.GetPixelBilinear(incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor(px / targetWidth)));
    }
    result.SetPixels(rpixels, 0);
    result.Apply();
    System.GC.Collect();
    return result;
}

Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
{
    RenderTexture rt = new RenderTexture(targetX, targetY, 24);
    RenderTexture.active = rt;
    Graphics.Blit(texture2D, rt);
    Texture2D result = new Texture2D(targetX, targetY);
    result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
    result.Apply();
    return result;
}
}



public static class ExtentionsMethods
{
    public static Texture2D ToTexture2D(this Texture texture)
    {
        return Texture2D.CreateExternalTexture(
            texture.width,
            texture.height,
            TextureFormat.RGB24,
            false, false,
            texture.GetNativeTexturePtr());
    }

    public static Texture2D ToTexture2D(this RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }


    public static float CompareColorRGB(this Color color, Color other)
    {
        float distance = Mathf.Pow((other.r - color.r), 2) + Mathf.Pow((other.g - color.g), 2) + Mathf.Pow((other.b - color.b), 2);

        return distance;
    }
}