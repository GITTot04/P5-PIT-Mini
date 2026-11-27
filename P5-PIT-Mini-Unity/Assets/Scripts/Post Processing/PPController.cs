using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private LayerMask targetLayer;   // set in Inspector


    [SerializeField] private GameObject postProcessingObject;
    [SerializeField] private Volume postProcessingVolume;
    
    [SerializeField] private Vignette vignette;
    [SerializeField] private float vignetteIntensity = 0f;
    private float maxVignetteIntensity = 0.5f;
    private float minVignetteIntensity = 0f;

    [SerializeField] private FilmGrain filmGrain;
    [SerializeField] private float filmGrainIntensity = 0f;
    private float maxFilmGrainIntensity = 0.8f;
    private float minFilmGrainIntensity = 0f;

    [SerializeField] private float lerpSpeed;



    private void Start()
    {
        postProcessingObject = GameObject.Find("Global Volume");
        postProcessingVolume = postProcessingObject.GetComponent<Volume>();
        vignette = postProcessingVolume.profile.TryGet<Vignette>(out var v) ? v : null;
        filmGrain = postProcessingVolume.profile.TryGet<FilmGrain>(out var fg) ? fg : null;

    }

    void Update()
    {
        vignette.intensity.value = vignetteIntensity;
        filmGrain.intensity.value = filmGrainIntensity;
        //VignetteClamp();

        if (cam == null) cam = Camera.main;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.SphereCast(ray, radius, out RaycastHit hit, maxDistance, targetLayer,
                               QueryTriggerInteraction.Ignore))
        {
            vignetteIntensity = Mathf.Lerp(vignetteIntensity, maxVignetteIntensity, Time.deltaTime * lerpSpeed);
            filmGrainIntensity = Mathf.Lerp(filmGrainIntensity, maxFilmGrainIntensity, Time.deltaTime * lerpSpeed);
        }
        else 
        {
            vignetteIntensity = Mathf.Lerp(vignetteIntensity, minVignetteIntensity, Time.deltaTime * lerpSpeed);
            filmGrainIntensity = Mathf.Lerp(filmGrainIntensity, minFilmGrainIntensity, Time.deltaTime * lerpSpeed);    
        }
    }




    void VignetteClamp()
    {
        if (vignette != null)
        {
            if (vignetteIntensity > maxVignetteIntensity) vignetteIntensity = maxVignetteIntensity;
            if (vignetteIntensity < minVignetteIntensity) vignetteIntensity = minVignetteIntensity;
        }
    }







    // Visualize in Scene view
    void OnDrawGizmosSelected()
    {
        if (cam == null) return;
        Gizmos.color = Color.yellow;
        Vector3 origin = cam.transform.position;
        Vector3 end = origin + cam.transform.forward * maxDistance;
        Gizmos.DrawWireSphere(origin, radius);
        Gizmos.DrawWireSphere(end, radius);
        Gizmos.DrawLine(origin, end);
    }



}
