using UnityEngine;
using Physics2D.Entity;
using Physics2D.Utils;

namespace Physics2D.Test
{

    public class Test2DIntersect : MonoBehaviour
    {
        public GameObject AABBGO1;
        public GameObject AABBGO2;
        public GameObject SphereGO1;
        public GameObject SphereGO2;


        AABBEntity aabb1;
        AABBEntity aabb2;
        SphereEntity sphere1;
        SphereEntity sphere2;

        public void Awake()
        {

        }

        public void Init() {
            //Init
            aabb1 = new AABBEntity();
            aabb1.size = new Vector2((float)AABBGO1.transform.localScale.x / 2, (float)AABBGO1.transform.localScale.y / 2);
            aabb1.pos = AABBGO1.transform.position;
            aabb1.minPos = aabb1.pos - aabb1.size;
            aabb1.maxPos = aabb1.pos + aabb1.size;

            aabb2 = new AABBEntity();
            aabb2.size = new Vector2((float)AABBGO2.transform.localScale.x / 2, (float)AABBGO2.transform.localScale.y / 2);
            aabb2.pos = AABBGO2.transform.position;
            aabb2.minPos = aabb2.pos - aabb2.size;
            aabb2.maxPos = aabb2.pos + aabb2.size;

            sphere1 = new SphereEntity();
            sphere1.pos = SphereGO1.transform.position;
            sphere1.radius = (float)SphereGO1.transform.localScale.x;

            sphere2 = new SphereEntity();
            sphere2.pos = SphereGO2.transform.position;
            sphere2.radius = (float)SphereGO2.transform.localScale.x;
        }

        public void OnDrawGizmos()
        {
            Init();
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
            Gizmos.DrawWireCube(AABBGO2.transform.position, AABBGO2.transform.localScale);
            Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
            Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);

            if (Intersect2DUtils.IntersectSphere_AABB(aabb1, sphere1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
            }

            if (Intersect2DUtils.IntersectSphere_AABB(aabb1, sphere2))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            }

            if (Intersect2DUtils.IntersectAABB_AABB(aabb1, aabb2))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(AABBGO1.transform.position, AABBGO1.transform.localScale);
                Gizmos.DrawWireCube(AABBGO2.transform.position, AABBGO2.transform.localScale);
            }

            if (Intersect2DUtils.IntersectSphere_Sphere(sphere2, sphere1))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(SphereGO1.transform.position, SphereGO1.transform.localScale.x);
                Gizmos.DrawWireSphere(SphereGO2.transform.position, SphereGO2.transform.localScale.x);
            }
        }


    }
}
