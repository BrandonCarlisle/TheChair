using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class DroneScript : MonoBehaviour
    {
        public int spawnerID = 0;

        // Start is called before the first frame update
        public GameObject eventManager;
        private EventManager events;

        private Rigidbody body;

        public GameObject tempPlayer;
        public GameObject shootPoint;
        public GameObject bullet;

        public float bulletSpeed = 20.0f;
        public float bulletTime = 10f;

        public List<GameObject> movePoints;
        public List<GameObject> initMovePoints;
        public int healthPoints = 6;
        float traverseSpeed = 3.5f;
        float moveTimer = 0f;
        float moveInterval = 2f;

        float flutter = 0.5f;
        float flutterspeed = 0.005f;
        float flutterTrack = 0.0f;
        bool flutterUp = true;

        bool moving = false;
        bool playerInRange = false;
        int moveTo = 0;

        public float shootInterval = 2f;
        float shootTimer = 0.0f;

        public bool initalMoves = false;
        int initalMoveTo = 0;

        public bool isDead = true;
        bool deathTriggered = false;

        void Start()
        {
            body = GetComponent<Rigidbody>();

            events = eventManager.GetComponent<EventManager>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "projectile")
            {
                Hit();
            }
        }

        public void Hit()
        {
            events.playSoundAt.Invoke("dronehit", 1f, gameObject.transform.position);

            healthPoints -= 1;
            if (healthPoints == 0)
                isDead = true;
        }

        void Shoot()
        {
            //if (!CheckPlayerLOS())
            //    return;

            shootPoint.transform.LookAt(tempPlayer.transform);
            GameObject bulletObj = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bulletObj.GetComponent<Rigidbody>().velocity = (shootPoint.transform.forward * bulletSpeed);

            events.playSoundAt.Invoke("laser2", .6f, gameObject.transform.position);

            Destroy(bulletObj, bulletTime);
        }

        bool CheckPlayerLOS()
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "playerHitBox")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        void CalcShoot()
        {



        }

        void Move()
        {


            if (movePoints.Count == 0)
                return;

            var movingTo = movePoints[moveTo];

            moving = true;
            float step = traverseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movingTo.transform.position, step);

            if (Vector3.Distance(transform.position, movingTo.transform.position) < 0.001f)
            {
                if (moveTo + 1 == movePoints.Count)
                    moveTo = 0;
                else
                    moveTo += 1;

                moving = false;
            }
        }

        void initalMove()
        {
            if (initMovePoints.Count == 0)
            {
                initalMoves = false;
                return;
            }
            if (moveTo == initMovePoints.Count)
            {
                initalMoves = false;
                moveTimer = moveInterval;
                return;
            }

            var movingTo = initMovePoints[moveTo];

            moving = true;
            float step = traverseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movingTo.transform.position, step);

            if (Vector3.Distance(transform.position, movingTo.transform.position) < 0.001f)
            {
                moveTo += 1;
            }

        }

        void flutterDrone()
        {
            if (flutterUp)
            {
                this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, flutterspeed, 0);
                flutterTrack += flutterspeed;

                if (flutterTrack >= flutter)
                {
                    flutterUp = false;
                }

            }
            else
            {
                this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, -flutterspeed, 0);
                flutterTrack -= flutterspeed;

                if (flutterTrack <= 0.0f)
                {
                    flutterUp = true;
                }
            }
        }


        void CheckTarget()
        {
            float dist = Vector3.Distance(tempPlayer.transform.position, transform.position);

            if (dist > 40f)
            {
                if (playerInRange)
                {
                    playerInRange = false;

                }
            }
            else
            {
                if (!playerInRange)
                {
                    events.playSoundAt.Invoke("droneAlerted", 1f, gameObject.transform.position);
                    playerInRange = true;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (isDead)
            {
                if (!deathTriggered)
                {
                    var events = eventManager.GetComponent<EventManager>();
                    events.spawnKilled.Invoke(spawnerID);

                    events.playSoundAt.Invoke("droneDeath", 1f, gameObject.transform.position);

                    body.useGravity = true;
                    deathTriggered = true;
                }
                return;
            }

            CheckTarget();


            if (initalMoves)
            {
                initalMove();
                return;
            }

            shootTimer += Time.deltaTime;

            if (!moving)
                moveTimer += Time.deltaTime;

            if (moveTimer >= moveInterval)
            {
                Move();
                if (!moving)
                    moveTimer = 0f;
            }

            flutterDrone();




            if (playerInRange)
            {
                var targetRotation = Quaternion.LookRotation(tempPlayer.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3f * Time.deltaTime);

                if (shootTimer > shootInterval)
                {
                    Shoot();
                    shootTimer = 0f;
                }
            }



        }
    }
}
