using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollectibleCoin : MonoBehaviour
{
    private const string PLATFORM_TAG = "CollectionPlatform"; 
    private Rigidbody rb;
    private bool isAttached = false;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject != null && collision.gameObject.CompareTag(PLATFORM_TAG))
        {
           
            if (!isAttached)
            {
                AttachToPlatform(collision.gameObject);
            }
        }
    }

   
    private void OnCollisionExit(Collision collision)
    {
       
        if (collision.gameObject.CompareTag(PLATFORM_TAG) && isAttached)
        {
            DetachFromPlatform();
        }
    }

    private void AttachToPlatform(GameObject platform)
    {
      
        transform.SetParent(platform.transform);

       
        rb.isKinematic = true; 
        isAttached = true;
        Debug.Log("? ë‰ÇÃè„Ç…óØÇ‹ÇËÇ‹ÇµÇΩ: " + platform.name);

        
    }

   
    private void DetachFromPlatform()
    {
       
        transform.SetParent(null);

        
        rb.isKinematic = false;

        isAttached = false;
        Debug.Log("?? ë‰Ç©ÇÁó£ÇÍÇ‹ÇµÇΩÅBçƒÇ—é©óRóéâ∫ÇµÇ‹Ç∑ÅB");
    }
}
