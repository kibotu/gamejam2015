using UnityEngine;

public class Idle : MonoBehaviour
{
    public float Exclude = 0.1f;
    public Vector2 MinRotation = new Vector2(-0.8f, 0.8f);
    public Vector2 MinRotSpeed = new Vector2(-5, 5);
    public Vector2 TranslationRangeX = new Vector2(-0.2f, 0.2f);
    public Vector2 TranslationRangeY = new Vector2(-0.0f, 0.0f);
    public Vector2 TranslationRangeZ = new Vector2(-0.2f, 0.2f);
    public Vector2 RotRangeX = new Vector2(-5f, 5f);
    public Vector2 RotRangeY = new Vector2(-5f, 5f);
    public Vector2 RotRangeZ = new Vector2(-5f, 5f);
    private Quaternion originalRotation;
    private Vector3 originalPosition;
    private Vector3 transSpeed;
    private Vector3 translation;
    private Vector3 rotSpeed;
    private Vector3 rotation;

    public void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // translation
        translation = new Vector3(
            Utils.Range(TranslationRangeX.x, TranslationRangeX.y, -Exclude, Exclude),
            Utils.Range(TranslationRangeY.x, TranslationRangeY.y, -Exclude, Exclude),
            Utils.Range(TranslationRangeZ.x, TranslationRangeZ.y, -Exclude, Exclude)
        );
        transSpeed = new Vector3(
            Utils.Range(MinRotSpeed.x, MinRotSpeed.y, -Exclude, Exclude),
            Utils.Range(MinRotSpeed.x, MinRotSpeed.y, -Exclude, Exclude),
            Utils.Range(MinRotSpeed.x, MinRotSpeed.y, -Exclude, Exclude)
        );

        // rotation
        rotation.x = Utils.Range(RotRangeX.x, RotRangeX.y, MinRotSpeed.x, MinRotSpeed.y);
        rotation.y = Utils.Range(RotRangeY.x, RotRangeY.y, MinRotSpeed.x, MinRotSpeed.y);
        rotation.z = Utils.Range(RotRangeZ.x, RotRangeZ.y, MinRotSpeed.x, MinRotSpeed.y);
        rotSpeed = new Vector3(
            Utils.Range(MinRotSpeed.x, MinRotSpeed.y, -Exclude, Exclude),
            Utils.Range(MinRotSpeed.x, MinRotSpeed.y, -Exclude, Exclude),
            Utils.Range(MinRotSpeed.x, MinRotSpeed.y, -Exclude, Exclude)
        );
    }

    public void Update()
    {
        transform.localRotation = originalRotation * Quaternion.Euler(
            rotation.x * Mathf.Sin(Time.time * rotSpeed.x),
            rotation.y * Mathf.Sin(Time.time * rotSpeed.y),
            rotation.z * Mathf.Sin(Time.time * rotSpeed.z)
        );

        var pos = new Vector3(
            translation.x * Mathf.Sin(Time.time * transSpeed.x),
            translation.y * Mathf.Cos(Time.time * transSpeed.y),
            translation.z * Mathf.Sin(Time.time * transSpeed.z));

        transform.position = originalPosition + pos;
    }

    public void OnDestroy()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
