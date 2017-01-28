using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Jurassic;
using Jurassic.Compiler;
using Jurassic.Library;

namespace MyTextor
{
    internal class MyJS
    {
        static string js=null;
        static ScriptEngine eng = new ScriptEngine();
        internal MyJS()
        {
        }
        internal static string processText(string text){
            try
            {
                FileStream fs = new FileStream("plugins/replace.js", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                js = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

            }
            eng.SetGlobalValue("console", new Jurassic.Library.FirebugConsole(eng));
            eng.SetGlobalValue("g_input", text); 
            eng.SetGlobalValue("g_output", "");
            eng.Execute(js);
            string res =(string) eng.GetGlobalValue("g_output");
            return null;
        }
    }
}
