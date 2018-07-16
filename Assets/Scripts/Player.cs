using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool isWalkingAnim = false;
    GameObject animObj = null;
    public GameObject player;
    public float Speed = 0.5f;
    public float Hight = 5f;
    public bool isOnGround = false;
    public float JumpForce=10;
    public Rigidbody2D rb;
    public bool DoubleJump=false;
    public bool IsWalking = false;
    public bool HaveSkill = false;
    public bool HaveShock = false;


    public GameObject Bullet;
    public Transform Hand;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D)&& !HaveShock)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A)&&!HaveShock)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.J)&&HaveSkill)
        {
            GameObject obj = Instantiate(Bullet,Hand) as GameObject;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                isOnGround = false;
                rb.AddForce(transform.up * JumpForce);
                DoubleJump = true;
            }
            OnWalkingAnimPlay();
    }
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            //Debug.Log("onground");
            isOnGround = true;
        }
        if (other.gameObject.tag == "Xiangjing"|| other.gameObject.tag == "Banli")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Baoxiang")
        {
            HaveSkill = true;
        }
        if (other.gameObject.tag == "Wall")
        {
           
            HaveShock = true;
        }

    }
    public void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Wall")
        {

            HaveShock = false;
        }
    }
    public void OnWalkingAnimPlay()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.Space) && isOnGround))
        {
            isWalkingAnim = true;
           // Debug.Log("DOWN");
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || (Input.GetKey(KeyCode.Space) && !isOnGround))
        {
            isWalkingAnim = false;
            //Debug.Log("UP");
        }
        if (isWalkingAnim)
        {
            //播放动画

            //加入播放动画组件
            //animObj.AddComponent<UISpriteAnimation>();
            //设置播放动画速度
            //1-60之间数值越大，播放速度越快
            UISpriteAnimation uiAnim = animObj.GetComponent<UISpriteAnimation>();
            uiAnim.framesPerSecond = 15;
        }
        else
        {
            //停止动画
            UISpriteAnimation uiAnim = animObj.GetComponent<UISpriteAnimation>();
            uiAnim.framesPerSecond = 0;
            //销毁uispriteanimation组件
            //动画停止后设置精灵默认的帧
            UISprite runui = animObj.GetComponent<UISprite>();
            string name = runui.atlas.spriteList[0].name;
            runui.spriteName = name;
        }
    }
}
