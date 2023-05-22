using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bannstab : MonoBehaviour
{
    public GameObject Flame1;
    public GameObject Flame2;
    public GameObject Line;
    public GameObject[] flamesOfCandles;
    private bool candlesAt0Activated = false;
    private bool candlesAt1Activated = false;
    private bool candlesAt2Activated = false;
    private bool candlesAt3Activated = false;
    private bool candlesAt4ctivated = false;
    private Vector3 candle0 = new Vector3(-1, 0, (float)-0.65);
    private Vector3 candle1 = new Vector3((float)-1.04, 0, (float)0.6);
    private Vector3 candle2 = new Vector3((float)0.2, 0, (float)1.105);
    private Vector3 candle3 = new Vector3(1, 0, (float)0.1);
    private Vector3 candle4 = new Vector3((float)0.3, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        Flame1.SetActive(false);
        Flame2.SetActive(false);
        Vector3[] positions = new Vector3[6];
        for( int i = 0; i < positions.Length; i++)
        {
            positions[i] = candle0;
        }
        Line.GetComponent<LineRenderer>().SetPositions(positions);
    }

    // Update is called once per frame
    void Update()
    {
        if (candlesAt0Active() && !candlesAt0Activated)
        {
            candlesAt0Activated = true;
            Debug.Log("All candles on position 0 lit");
        }
        if (candlesAt1Active() && !candlesAt1Activated)
        {
            candlesAt1Activated = true;
            Debug.Log("All candles on position 1 lit");
        }
        if (candlesAt2Active() && !candlesAt2Activated)
        {
            candlesAt2Activated = true;
            Debug.Log("All candles on position 2 lit");
        }
        if (candlesAt3Active() && !candlesAt3Activated)
        {
            candlesAt3Activated = true;
            Debug.Log("All candles on position 3 lit");
        }
        if (candlesAt4Active() && !candlesAt4ctivated)
        {
            candlesAt4ctivated = true;
            Debug.Log("All candles on position 4 lit");
        }
    }

    public void pullTrigger()
    {
        Flame1.SetActive(true);
        Flame2.SetActive(true);
    }

    public void releaseTrigger()
    {
        Flame1.SetActive(false);
        Flame2.SetActive(false);
    }

    private bool candlesAt0Active()
    {
        if (flamesOfCandles[0].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[1].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[2].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[3].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool candlesAt1Active()
    {
        if (flamesOfCandles[4].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[5].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[6].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[7].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool candlesAt2Active()
    {
        if (flamesOfCandles[8].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[9].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[10].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[11].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool candlesAt3Active()
    {
        if (flamesOfCandles[12].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[13].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[14].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[15].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool candlesAt4Active()
    {
        if (flamesOfCandles[16].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[17].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[18].transform.GetChild(1).gameObject.activeInHierarchy && flamesOfCandles[19].transform.GetChild(1).gameObject.activeInHierarchy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
