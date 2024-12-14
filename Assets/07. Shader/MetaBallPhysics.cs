using UnityEngine;

public class MetaBallManager : MonoBehaviour
{
    public Material raymarchingMaterial; // Das Material, das den Raymarching-Shader verwendet
    public ComputeShader raymarchingShader; // Der Compute Shader für das Raymarching

    private RenderTexture renderTexture; // Render-Textur zur Speicherung des Ergebnisses

    private void Start()
    {
        // Erstelle eine Render-Textur für die Ausgabe des Compute Shaders
        renderTexture = new RenderTexture(1024, 1024, 0);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        // Weisen Sie der Material-Instanz die berechnete Textur zu
        raymarchingMaterial.SetTexture("_RaymarchingTex", renderTexture);
    }

    private void Update()
    {
        // Führe den Compute Shader aus
        int kernelHandle = raymarchingShader.FindKernel("CSMain");
        raymarchingShader.SetTexture(kernelHandle, "Result", renderTexture);

        // Dispatch den Compute Shader
        raymarchingShader.Dispatch(kernelHandle, Mathf.CeilToInt(renderTexture.width / 8.0f), Mathf.CeilToInt(renderTexture.height / 8.0f), 1);
    }
}
