using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 inpDirection;
    private Rigidbody2D body;
    private GameObject objHolding;
    private float objScale;
    public LayerMask mask;
    public int walkSpeed = 5;
    public int sprintSpeed = 7;
    public float maxStamina = 2.5f; //seconds (hopefully)
    public float curStamina;
    bool sprinting = false;
    bool cooldown = false;
    [SerializeField] GameObject staminaWheel;
    [SerializeField] GameObject objPos;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        inpDirection = Vector2.up;
        curStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPaused) {

            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            direction.Normalize();

            if (direction != Vector2.zero) {
                inpDirection = direction;
            }
            
            if (Input.GetKeyDown(KeyCode.E)) {
                pickup();
            }
            if (Input.GetKey(KeyCode.E)) {
                cutCheck();
            } else {
                if (objHolding != null) {
                    holdItem(objHolding);
                }
            }

            //debug commands
            if (Input.GetKeyDown(KeyCode.M)) {
                GetComponentInChildren<Ingredient>().addValue(1);
            }
            if (Input.GetKeyDown(KeyCode.N)) {
                GetComponentInChildren<Ingredient>().addValue(-1);
            }
            if (Input.GetKeyDown(KeyCode.H)) {
                GameManager.lose();
            }
            if (Input.GetKeyDown(KeyCode.B)) {
                Debug.Log("held item name: "+GetComponentInChildren<Ingredient>().getName());
            }
            //sprinting
            
            if (Input.GetKey(KeyCode.LeftShift)) {
                if (curStamina > 0 && cooldown == false){ //sprinting
                    sprinting = true;
                    curStamina -= Time.deltaTime;
                } else {
                    cooldown = true;
                }
            } else { //not holding shift
                sprinting = false;
                if (!cooldown) {
                    curStamina += Time.deltaTime;
                    if (curStamina >= maxStamina) {
                        curStamina = maxStamina;
                    }
                }
            }
            if (cooldown) {
                sprinting = false;
                curStamina += Time.deltaTime*0.75f;
                if (curStamina >= maxStamina) {
                    curStamina = maxStamina;
                    cooldown = false;
                }
            }

            staminaWheel.transform.localScale = new Vector3(curStamina/maxStamina,curStamina/maxStamina,0);
            if (cooldown) {
                staminaWheel.GetComponent<SpriteRenderer>().color = Color.red;
            } else {
                staminaWheel.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
        
    }

    void FixedUpdate() 
    {
        if (!GameManager.isPaused) {
            
            if (sprinting == false) {
                body.velocity = direction * walkSpeed;
            } else {
                body.velocity = direction * sprintSpeed;
            }
            
            if (direction != Vector2.zero) {
                if (Input.GetAxisRaw("Horizontal") < 0) {
                    body.rotation = Vector2.Angle(Vector2.up, inpDirection);
                } else if (Input.GetAxisRaw("Horizontal") > 0) {
                    body.rotation = Vector2.Angle(Vector2.up, inpDirection) * -1;
                    
                } else {
                    if (Input.GetAxisRaw("Vertical") > 0) {
                        body.rotation = 0;
                    } else if (Input.GetAxisRaw("Vertical") < 0) {
                        body.rotation = 180;
                    }
                }
                
            }
            
        }
        
        
    }
    // void LateUpdate()
    // {
    //     // GetComponent<Collider2D>().transform.rotation = Quaternion.identity;
    // }
    void pickup() {
        RaycastHit2D hit = Physics2D.Raycast(body.position,inpDirection,3f,mask);
        Debug.DrawRay(body.position,inpDirection*3f,Color.red);
        // Debug.Log("checking for interactables");
        
        if (hit) {

            // Debug.Log("checking for spawner");
            if (hit.collider.GetComponent<IngredientSpawner>() != null) {
                // Debug.Log("Hit something: "+hit.collider.name);
                if (objHolding != null) {
                    Destroy(objHolding);
                } else {
                    objHolding = hit.collider.GetComponent<IngredientSpawner>().onInteraction();
                    if (objHolding != null) {
                        objHolding = Instantiate(objHolding, body.transform.position, body.transform.rotation);
                        holdItem(objHolding);
                    }
                    
                }
            }

            // Debug.Log("checking for table");
            else if (hit.collider.GetComponent<Table>() != null) {
                // Debug.Log("Hit something: "+hit.collider.name);
                if (objHolding != null) { // if holding something
                    bool test = hit.collider.GetComponent<Table>().placeItem(objHolding, objHolding.GetComponentInChildren<Ingredient>().getValue());
                    if (test) {
                        Destroy(objHolding);
                    }
                }
                else { //if not holding something
                    object[] list = hit.collider.GetComponent<Table>().grabItem();
                    objHolding = (GameObject) list[0];
                    holdItem(objHolding);
                    objHolding.GetComponentInChildren<Ingredient>().setValue((float) list[1]);
                    objHolding.GetComponentInChildren<Ingredient>().setState((int) list[2]);
                    // Debug.Log("pickup state:"+objHolding.GetComponentInChildren<Ingredient>().getState());
                }
            }

            else if (hit.collider.GetComponent<Passenger>() != null) {
                if (objHolding != null) {
                    // Debug.Log(objHolding.ToString());
                    bool des = hit.collider.GetComponent<Passenger>().onInteraction(objHolding);
                    if (des) {
                        Destroy(objHolding);
                    }
                }
                
            }
            if (hit.collider.GetComponent<UpgradeSlot>() != null) {//leave at the end so it is checked last to not block inputs
                hit.collider.GetComponent<UpgradeSlot>().onInteraction();
            }

        } else {
            // Debug.Log("Nothing Found");
        }
        
        
        
    }
    void holdItem(GameObject item) {
        objScale = objHolding.GetComponent<Ingredient>().getScale();

        item.transform.position = objPos.transform.position;
        // item.transform.position = new Vector3(item.transform.position.x+inpDirection.x,item.transform.position.y+inpDirection.y,0);
        item.transform.parent = objPos.transform;
        item.transform.localScale = new Vector3(objScale*100,objScale*100,0);
        // item.transform.rotation = body.transform.rotation;
    }
    public void cutCheck() {
        RaycastHit2D hit = Physics2D.Raycast(body.position,inpDirection,3f,mask);
        Debug.DrawRay(body.position,inpDirection*3f,Color.red);
        if (hit) {
            if (hit.collider.GetComponent<CuttingBoard>() != null) {
                if (objHolding != null) {
                    if (objHolding.GetComponent<Ingredient>().getCut()) {
                        objHolding.GetComponent<Ingredient>().addValue(Time.deltaTime*CuttingBoard.getSpeed());
                        hit.collider.GetComponent<CuttingBoard>().setAnimation(true);
                        hit.collider.GetComponent<CuttingBoard>().toPos(objHolding);
                        if (objHolding.GetComponent<Ingredient>().getState() > objHolding.GetComponent<Ingredient>().getMaxState()) {
                            Destroy(objHolding);
                        }
                    }
                }
            } else {
                if (objHolding != null) {
                    holdItem(objHolding);
                }
            }
        } else {
            if (objHolding != null) {
                holdItem(objHolding);
            }
        }
    }
}
