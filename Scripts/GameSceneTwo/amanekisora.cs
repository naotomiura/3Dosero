using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amanekisora : MonoBehaviour
{
    public FixedJoystick joy; // ここは入れたJoyStickの種類によって変えてください！
    public FixedJoystick Joy; // ここは入れたJoyStickの種類によって変えてください！

    public float speed; //Unity側で自由に調整して下さい
    Animator ani;

    float degStop;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.gameObject.GetComponent<Animator>(); //UnityChanについているAnimatorを取得
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        transform.Rotate(new Vector3(0, 50 * Joy.Horizontal, 0));
    }

    void Move()
    {

        float dx = joy.Horizontal; //joystickの水平方向の動きの値、-1~1の値をとります
        float dy = joy.Vertical; //joystickの垂直方向の動きの値、-1~1の値をとります

        float rad = Mathf.Atan2(dx - 0, dy - 0); //　 原点(0,0)と点（dx,dy)の距離から角度をとってくれる便利な関数

        float deg = rad * Mathf.Rad2Deg; //radianからdegreenに変換します

        this.transform.rotation = Quaternion.Euler(0, deg, 0); //Unityちゃんの向きを先ほど取得した角度に当てはめて代入します。今回はy軸方向が回転軸になります。

        if (deg != 0) //joystickの原点と(dx,dy)の２点がなす角度が０ではないとき = joystickを動かしている時
        {
            ani.SetBool("Walk", true); //wait→walkへ
            this.transform.position += this.transform.forward * speed * Time.deltaTime; //正面方向へプレイヤーを移動させ続ける

            degStop = deg; //停止前のプレイヤーの向きを保存
        }
        else //joystickの原点と(dx,dy)の２点がなす角度が０の時 = joystickが止まっている時
        {
            ani.SetBool("Walk", false); //walk→waitへ

            this.transform.rotation = Quaternion.Euler(0, degStop, 0); //停止時のプレイヤーの動きの向きを設定
        }
    }
}