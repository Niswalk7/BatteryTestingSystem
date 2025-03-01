using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace BatteryTestingSystem.Utils
{
    public class SerialPortManager
    {
        private static SerialPort? _serialPort;
        private static int _baudRate = 9600;

        public static List<string> GetAvailablePorts()
        {
            return new List<string>(SerialPort.GetPortNames());
        }

        public static bool OpenPort(string portName)
        {
            try
            {
                ClosePort(); // Close any existing connection

                _serialPort = new SerialPort
                {
                    PortName = portName,
                    BaudRate = _baudRate,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    ReadTimeout = 2000,
                    WriteTimeout = 2000
                };

                _serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening port {portName}: {ex.Message}", "Serial Port Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void ClosePort()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error closing port: {ex.Message}", "Serial Port Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void SetBaudRate(int baudRate)
        {
            _baudRate = baudRate;
            
            if (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Close();
                    _serialPort.BaudRate = baudRate;
                    _serialPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error setting baud rate: {ex.Message}", "Serial Port Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string? ReadData()
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                return null;

            try
            {
                return _serialPort.ReadLine();
            }
            catch (TimeoutException)
            {
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading data: {ex.Message}", "Serial Port Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool WriteData(string data)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                return false;

            try
            {
                _serialPort.WriteLine(data);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing data: {ex.Message}", "Serial Port Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}