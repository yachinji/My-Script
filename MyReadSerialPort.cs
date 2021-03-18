using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class MyReadSerialPort : MonoBehaviour
{

    public string COMPORT = "COM2";
    
    SerialPort serial;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (serial != null)
        {

            if (serial.IsOpen)
            {

                try
                {

                    char read = (char)serial.ReadChar();
                    Debug.Log("Receive (" + serial.PortName + ") : " + read);

                }
                catch (System.Exception e)
                {

                    //Debug.LogError("MySerialPort > Update : " + e.Message);

                }

            }

        }

    }

    private void OnEnable()
    {

        if (serial == null)
        {

            try
            {

                Debug.Log("Opening serialport ...");

                serial = new SerialPort(COMPORT, 115200);
                serial.ReadTimeout = 5;
                serial.WriteTimeout = 5;
                serial.Open();

                if (serial.IsOpen)
                {
                    Debug.Log("Open serialport success : " + serial.PortName);
                }
                else
                {
                    Debug.Log("Open serialport fail");
                    serial.Close();
                }

            }
            catch (System.Exception e)
            {

                Debug.LogError("Init serial port : " + e.Message);

            }

        }

    }

    private void OnDisable()
    {

        if (serial != null)
        {

            try
            {

                serial.Close();
                serial.Dispose();

            }
            catch (System.Exception e)
            {

                Debug.LogError("Release serial port : " + e.Message);

            }

        }

    }

}