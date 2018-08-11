using UnityEngine;
using System.Collections;
using System;

public class GameManifestOverrider : MonoBehaviour {

    public static event Action<string> Changed;

    public static void Set(string key, string value)
    {
        PlayerPrefs.SetString("manifest-" + key, value);
        PlayerPrefs.Save();
        if (Changed != null)
        {
            Changed(key);
        }
    }

    public static string Get(string key, string _default = "")
    {
        return PlayerPrefs.GetString("manifest-" + key, _default);
    }

    public static void Delete(string key)
    {
        PlayerPrefs.DeleteKey("manifest-" + key);
        PlayerPrefs.Save();
        if (Changed != null)
        {
            Changed(key);
        }
    }



//VESTCODE-START   
#region PKG_CODE
#if VEST_0
#elif VEST_1
    private int pkg1 = 0;
    public int GET_PKG1()
    {
        return pkg1;
    }

    public void SET_PKG_1(int p1)
    {
        pkg1 = p1;
    }

    public string ADD_PKG_1(int p1,int p2)
    {
        return (pkg1+p1+p2).ToString();
    }

    public int SUB_PKG_1(int p1)
    {
        return pkg1 - p1;
    }

    public float MUL_PKG_1(float p1)
    {
        return p1*pkg1;
    } 
#elif VEST_2
    private int pkg2 = 0;
    public int GET_PKG2()
    {
        return pkg2;
    }

    public void SET_PKG_2(int p1)
    {
        pkg2 = p1;
    }

    public string ADD_PKG_2(int p1,int p2)
    {
        return (pkg2+p1+p2).ToString();
    }

    public int SUB_PKG_2(int p1)
    {
        return pkg2 - p1;
    }

    public float MUL_PKG_2(float p1)
    {
        return p1*pkg2;
    } 
#elif VEST_3
    private int pkg3 = 0;
    public int GET_PKG3()
    {
        return pkg3;
    }

    public void SET_PKG_3(int p1)
    {
        pkg3 = p1;
    }

    public string ADD_PKG_3(int p1,int p2)
    {
        return (pkg3+p1+p2).ToString();
    }

    public int SUB_PKG_3(int p1)
    {
        return pkg3 - p1;
    }

    public float MUL_PKG_3(float p1)
    {
        return p1*pkg3;
    } 
#elif VEST_4
    private int pkg4 = 0;
    public int GET_PKG4()
    {
        return pkg4;
    }

    public void SET_PKG_4(int p1)
    {
        pkg4 = p1;
    }

    public string ADD_PKG_4(int p1,int p2)
    {
        return (pkg4+p1+p2).ToString();
    }

    public int SUB_PKG_4(int p1)
    {
        return pkg4 - p1;
    }

    public float MUL_PKG_4(float p1)
    {
        return p1*pkg4;
    } 
#elif VEST_5
    private int pkg5 = 0;
    public int GET_PKG5()
    {
        return pkg5;
    }

    public void SET_PKG_5(int p1)
    {
        pkg5 = p1;
    }

    public string ADD_PKG_5(int p1,int p2)
    {
        return (pkg5+p1+p2).ToString();
    }

    public int SUB_PKG_5(int p1)
    {
        return pkg5 - p1;
    }

    public float MUL_PKG_5(float p1)
    {
        return p1*pkg5;
    } 
#elif VEST_6
    private int pkg6 = 0;
    public int GET_PKG6()
    {
        return pkg6;
    }

    public void SET_PKG_6(int p1)
    {
        pkg6 = p1;
    }

    public string ADD_PKG_6(int p1,int p2)
    {
        return (pkg6+p1+p2).ToString();
    }

    public int SUB_PKG_6(int p1)
    {
        return pkg6 - p1;
    }

    public float MUL_PKG_6(float p1)
    {
        return p1*pkg6;
    } 
#elif VEST_7
    private int pkg7 = 0;
    public int GET_PKG7()
    {
        return pkg7;
    }

    public void SET_PKG_7(int p1)
    {
        pkg7 = p1;
    }

    public string ADD_PKG_7(int p1,int p2)
    {
        return (pkg7+p1+p2).ToString();
    }

    public int SUB_PKG_7(int p1)
    {
        return pkg7 - p1;
    }

    public float MUL_PKG_7(float p1)
    {
        return p1*pkg7;
    } 
#elif VEST_8
    private int pkg8 = 0;
    public int GET_PKG8()
    {
        return pkg8;
    }

    public void SET_PKG_8(int p1)
    {
        pkg8 = p1;
    }

    public string ADD_PKG_8(int p1,int p2)
    {
        return (pkg8+p1+p2).ToString();
    }

    public int SUB_PKG_8(int p1)
    {
        return pkg8 - p1;
    }

    public float MUL_PKG_8(float p1)
    {
        return p1*pkg8;
    } 
#elif VEST_9
    private int pkg9 = 0;
    public int GET_PKG9()
    {
        return pkg9;
    }

    public void SET_PKG_9(int p1)
    {
        pkg9 = p1;
    }

    public string ADD_PKG_9(int p1,int p2)
    {
        return (pkg9+p1+p2).ToString();
    }

    public int SUB_PKG_9(int p1)
    {
        return pkg9 - p1;
    }

    public float MUL_PKG_9(float p1)
    {
        return p1*pkg9;
    } 
#elif VEST_10
    private int pkg10 = 0;
    public int GET_PKG10()
    {
        return pkg10;
    }

    public void SET_PKG_10(int p1)
    {
        pkg10 = p1;
    }

    public string ADD_PKG_10(int p1,int p2)
    {
        return (pkg10+p1+p2).ToString();
    }

    public int SUB_PKG_10(int p1)
    {
        return pkg10 - p1;
    }

    public float MUL_PKG_10(float p1)
    {
        return p1*pkg10;
    } 
#elif VEST_11
    private int pkg11 = 0;
    public int GET_PKG11()
    {
        return pkg11;
    }

    public void SET_PKG_11(int p1)
    {
        pkg11 = p1;
    }

    public string ADD_PKG_11(int p1,int p2)
    {
        return (pkg11+p1+p2).ToString();
    }

    public int SUB_PKG_11(int p1)
    {
        return pkg11 - p1;
    }

    public float MUL_PKG_11(float p1)
    {
        return p1*pkg11;
    } 
#elif VEST_12
    private int pkg12 = 0;
    public int GET_PKG12()
    {
        return pkg12;
    }

    public void SET_PKG_12(int p1)
    {
        pkg12 = p1;
    }

    public string ADD_PKG_12(int p1,int p2)
    {
        return (pkg12+p1+p2).ToString();
    }

    public int SUB_PKG_12(int p1)
    {
        return pkg12 - p1;
    }

    public float MUL_PKG_12(float p1)
    {
        return p1*pkg12;
    } 
#elif VEST_13
    private int pkg13 = 0;
    public int GET_PKG13()
    {
        return pkg13;
    }

    public void SET_PKG_13(int p1)
    {
        pkg13 = p1;
    }

    public string ADD_PKG_13(int p1,int p2)
    {
        return (pkg13+p1+p2).ToString();
    }

    public int SUB_PKG_13(int p1)
    {
        return pkg13 - p1;
    }

    public float MUL_PKG_13(float p1)
    {
        return p1*pkg13;
    } 
#elif VEST_14
    private int pkg14 = 0;
    public int GET_PKG14()
    {
        return pkg14;
    }

    public void SET_PKG_14(int p1)
    {
        pkg14 = p1;
    }

    public string ADD_PKG_14(int p1,int p2)
    {
        return (pkg14+p1+p2).ToString();
    }

    public int SUB_PKG_14(int p1)
    {
        return pkg14 - p1;
    }

    public float MUL_PKG_14(float p1)
    {
        return p1*pkg14;
    } 
#elif VEST_15
    private int pkg15 = 0;
    public int GET_PKG15()
    {
        return pkg15;
    }

    public void SET_PKG_15(int p1)
    {
        pkg15 = p1;
    }

    public string ADD_PKG_15(int p1,int p2)
    {
        return (pkg15+p1+p2).ToString();
    }

    public int SUB_PKG_15(int p1)
    {
        return pkg15 - p1;
    }

    public float MUL_PKG_15(float p1)
    {
        return p1*pkg15;
    } 
#elif VEST_16
    private int pkg16 = 0;
    public int GET_PKG16()
    {
        return pkg16;
    }

    public void SET_PKG_16(int p1)
    {
        pkg16 = p1;
    }

    public string ADD_PKG_16(int p1,int p2)
    {
        return (pkg16+p1+p2).ToString();
    }

    public int SUB_PKG_16(int p1)
    {
        return pkg16 - p1;
    }

    public float MUL_PKG_16(float p1)
    {
        return p1*pkg16;
    } 
#elif VEST_17
    private int pkg17 = 0;
    public int GET_PKG17()
    {
        return pkg17;
    }

    public void SET_PKG_17(int p1)
    {
        pkg17 = p1;
    }

    public string ADD_PKG_17(int p1,int p2)
    {
        return (pkg17+p1+p2).ToString();
    }

    public int SUB_PKG_17(int p1)
    {
        return pkg17 - p1;
    }

    public float MUL_PKG_17(float p1)
    {
        return p1*pkg17;
    } 
#elif VEST_18
    private int pkg18 = 0;
    public int GET_PKG18()
    {
        return pkg18;
    }

    public void SET_PKG_18(int p1)
    {
        pkg18 = p1;
    }

    public string ADD_PKG_18(int p1,int p2)
    {
        return (pkg18+p1+p2).ToString();
    }

    public int SUB_PKG_18(int p1)
    {
        return pkg18 - p1;
    }

    public float MUL_PKG_18(float p1)
    {
        return p1*pkg18;
    } 
#elif VEST_19
    private int pkg19 = 0;
    public int GET_PKG19()
    {
        return pkg19;
    }

    public void SET_PKG_19(int p1)
    {
        pkg19 = p1;
    }

    public string ADD_PKG_19(int p1,int p2)
    {
        return (pkg19+p1+p2).ToString();
    }

    public int SUB_PKG_19(int p1)
    {
        return pkg19 - p1;
    }

    public float MUL_PKG_19(float p1)
    {
        return p19*pkg1;
    } 
#elif VEST_20
    private int pkg20 = 0;
    public int GET_PKG20()
    {
        return pkg20;
    }

    public void SET_PKG_20(int p1)
    {
        pkg20 = p1;
    }

    public string ADD_PKG_20(int p1,int p2)
    {
        return (pkg20+p1+p2).ToString();
    }

    public int SUB_PKG_20(int p1)
    {
        return pkg20 - p1;
    }

    public float MUL_PKG_20(float p1)
    {
        return p1*pkg20;
    } 
#endif
#endregion PKG_CODE
//VESTCODE-END
}