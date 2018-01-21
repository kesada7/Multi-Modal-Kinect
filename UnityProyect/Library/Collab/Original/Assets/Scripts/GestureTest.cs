using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureTest : MonoBehaviour
{
    //Declare gameobjects
    public GameObject left_hand;
    public GameObject right_hand;
    public GameObject left_shoulder;
    public GameObject right_shoulder;
    public GameObject left_hip;
    public GameObject right_hip;
    public GameObject HandCursor1;
    public GameObject greatsword;
    public GameObject Elven_Long_Bow;
    public GameObject Shield;

    public GameObject shot;
    public Transform shotSpawn;
    public GameObject arrowAim;

    bool Sword = true;

    public enum Gestures
    {
        None = 0,
        SwitchWeapon,
        TakeBow,
        RaiseOnehand,
        SwordSlash,
        DefendOnself,

    }

    Gestures gesture = Gestures.None;
    int clear = 0;
    float timer = 0;
    
    // Update is called once per frame
    void Update ()
    {
        SwitchWeapon();
        TakeBow();
        SwordSlash();
        DefendOnself();
        if (Sword == true)
        {
            greatsword.SetActive(true);
            Elven_Long_Bow.SetActive(false);
        }
        else if (Sword == false)
        {
            greatsword.SetActive(false);
            Elven_Long_Bow.SetActive(true);
        }
    }

    void SwitchWeapon()
    {
        //Initial hand positions
        if (clear == 0)
        {
            if (left_hand.transform.position.y < left_shoulder.transform.position.y
                && left_hip.transform.position.y < left_hand.transform.position.y
                && right_hand.transform.position.y < right_shoulder.transform.position.y
                && right_hip.transform.position.y < right_hand.transform.position.y
                && Vector3.Distance(left_hand.transform.position, right_hand.transform.position) > 0.8f)
            {
                Debug.Log("Hands Apart");
                //Sets the gesture to stage 2
                clear = 1;
                timer = 0;
                gesture = Gestures.SwitchWeapon;
            }
        }

        if (clear == 1 && gesture == Gestures.SwitchWeapon)
        {
            //Stage 2 hand positions
            if (left_hand.transform.position.y < left_shoulder.transform.position.y
            && left_hip.transform.position.y < left_hand.transform.position.y
            && right_hand.transform.position.y < right_shoulder.transform.position.y
            && right_hip.transform.position.y < right_hand.transform.position.y
            && Vector3.Distance(left_hand.transform.position, right_hand.transform.position) < 0.2f)
            {
                Debug.Log("Gesture 'Switch Weapon' Complete");
                if (Sword == true)
                {
                    Sword = false;
                }
                else if (Sword == false)
                {
                    Sword = true;
                }

                //Sets the gesture to stage 3 where it cannot be completed again for a short time
                clear = 2;
                timer = 0;
            }
            else
            {
                //Timer counts down and resets the gesture if the second hand position is not performed quick enough. This is to prevent gestures becoming stuck half-way completed
                timer++;
                if (timer > 100)
                {
                    clear = 0;
                    Debug.Log("Gesture 'Switch Weapon' reset due to inaction");
                }
            }
        }
        if (clear == 2 && gesture == Gestures.SwitchWeapon)
        {
            //Resets the gesture after a short time when the gesture is completed. This is to stop the gesture accidentally being performed multiple times in quick succession
            timer++;
            if (timer > 100)
            {
                clear = 0;
                gesture = Gestures.None;
                Debug.Log("Gesture 'Switch Weapon' reset after completion");
            }
        }
    }

    void TakeBow()
    {
        //Initial hand positions
        if (clear == 0 && Sword == false)
        {
            if ((left_hip.transform.position.y + 0.2f) < left_hand.transform.position.y
            && (right_hip.transform.position.y + 0.2f) < right_hand.transform.position.y
            && Vector3.Distance(left_hand.transform.position, right_hand.transform.position) < 0.15f)
            {
                Debug.Log("Draw Bow");
                arrowAim.SetActive(true);
                //Sets the gesture to stage 2
                clear = 1;
                timer = 0;
                gesture = Gestures.TakeBow;
            }
        }
        if (clear == 1 && gesture == Gestures.TakeBow && Sword == false)
        {
            //Stage 2 hand positions
            if (left_hip.transform.position.y < left_hand.transform.position.y
                //&& left_hand.transform.position.x > left_shoulder.transform.position.x // <-- this may need flipping, test on kinect
                //&& right_hand.transform.position.y < (right_shoulder.transform.position.y + 200)
                && right_hip.transform.position.y < right_hand.transform.position.y
                && Vector3.Distance(left_hand.transform.position, right_hand.transform.position) > 0.3f
                && Vector3.Distance(right_shoulder.transform.position, right_hand.transform.position) < 0.5f)
            {
                //ShootArrow();
                Debug.Log("Gesture 'Draw Bow' Complete");
                //Sets the gesture to stage 3 where it cannot be completed again for a short time
                clear = 2;
                timer = 0;
                Instantiate(shot, shotSpawn.position, shotSpawn.transform.rotation);
                arrowAim.SetActive(false);
            }
            else
            {
                //Timer counts down and resets the gesture if the second hand position is not performed quick enough. This is to prevent gestures becoming stuck half-way completed
                timer++;
                if (timer > 100)
                {
                    clear = 0;
                    Debug.Log("Gesture 'Draw Bow' reset due to inaction");
                    arrowAim.SetActive(false);
                }
            }
        }
        if (clear == 2)
        {
            //Resets the gesture after a short time when the gesture is completed. This is to stop the gesture accidentally being performed multiple times in quick succession
            timer++;
            if (timer > 100)
            {
                clear = 0;
                Debug.Log("Gesture 'Draw Bow' reset after completion");
            }
        }
    }

    void SwordSlash()
    {
        //Initial hand positions
        if (clear == 0 && Sword == true)
        {
            if (right_hand.transform.position.y > right_shoulder.transform.position.y
            && right_hand.transform.position.x < (right_shoulder.transform.position.x + 200) // <-- Value may be waaay off, test on kinect
            && right_hand.transform.position.x > (right_shoulder.transform.position.x - 200) // <-- Value may be waaay off, test on kinect
            && Vector3.Distance(right_shoulder.transform.position, right_hand.transform.position) > 0.3f)
            {
                Debug.Log("Sword Raised");
                //Sets the gesture to stage 2
                clear = 1;
                timer = 0;
                gesture = Gestures.SwordSlash;
            }
        }

        if (clear == 1 && gesture == Gestures.SwordSlash && Sword == true)
        {
            //Stage 2 hand positions
            if(right_hand.transform.position.y < right_shoulder.transform.position.y
            && right_hand.transform.position.x < (right_shoulder.transform.position.x + 200) // <-- Value may be waaay off, test on kinect
            && right_hand.transform.position.x > (right_shoulder.transform.position.x - 200) // <-- Value may be waaay off, test on kinect
            && Vector3.Distance(right_shoulder.transform.position, right_hand.transform.position) < 0.5f)
            {
                Debug.Log("Slash Complete");
                //Sets the gesture to stage 3 where it cannot be completed again for a short time
                clear = 2;
                timer = 0;
            }
            else
            {
                //Timer counts down and resets the gesture if the second hand position is not performed quick enough. This is to prevent gestures becoming stuck half-way completed
                timer++;
                if (timer > 100)
                {
                    clear = 0;
                    Debug.Log("Gesture 'Sword Slash' reset due to inaction");
                }
            }
        }
        if (clear == 2 && gesture == Gestures.SwordSlash)
        {
            //Resets the gesture after a short time when the gesture is completed. This is to stop the gesture accidentally being performed multiple times in quick succession
            timer++;
            if (timer > 100)
            {
                clear = 0;
                gesture = Gestures.None;
                Debug.Log("Gesture 'Sword Slash' reset after completion");
            }
        }
    }
    void DefendOnself()
    {
        //Initial hand positions
        if (clear == 0)
        {
            if (left_hand.transform.position.y < left_shoulder.transform.position.y
            && right_hand.transform.position.y < right_shoulder.transform.position.y
            && Vector3.Distance(left_hand.transform.position, left_hip.transform.position) < 0.2f
            && Vector3.Distance(right_hand.transform.position, right_hip.transform.position) < 0.2f)
            {
                Debug.Log("Defending1");
                //Sets the gesture to stage 2
                clear = 1;
                timer = 0;
                gesture = Gestures.DefendOnself;
            }
        }

        if (clear == 1 && gesture == Gestures.DefendOnself)
        {
            //Stage 2 hand positions
            if (left_hand.transform.position.y > left_hip.transform.position.y
            //&& left_hip.transform.position.y < left_hand.transform.position.y
            //&& left_hip.transform.position.y < left_hand.transform.position.y
            && Vector3.Distance(left_hand.transform.position, right_shoulder.transform.position) < 0.3f
            && Vector3.Distance(right_hand.transform.position, left_shoulder.transform.position) < 0.3f)
            {
                Debug.Log("Defending2");
                Shield.SetActive(true);
                //Sets the gesture to stage 3 where it cannot be completed again for a short time
                clear = 2;
                timer = 0;
            }
            else if(clear == 1)
            {
                //Timer counts down and resets the gesture if the second hand position is not performed quick enough. This is to prevent gestures becoming stuck half-way completed
                timer++;
                if (timer > 100)
                {
                    clear = 0;
                    Debug.Log("Gesture reset due to inaction");
                }
            }
        }
        if (clear == 2 && gesture == Gestures.DefendOnself)
        {
            //Resets the gesture after a short time when the gesture is completed. This is to stop the gesture accidentally being performed multiple times in quick succession
            timer++;
            if (timer > 200)
            {
                clear = 0;
                gesture = Gestures.None;
                Debug.Log("Gesture reset after completion");
                Shield.SetActive(false);
            }
        }
    }

    //void ShowArrow()
    //{
    //    arrowAim.active = true;
        
    //}
}


