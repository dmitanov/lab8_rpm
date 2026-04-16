using lab8_rpm.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab8_rpm.Components
{
    public class Logger : Colleague
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
