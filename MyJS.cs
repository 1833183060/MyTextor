using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;
using Noesis.Javascript;

namespace MyTextor
{
    internal class MyJS
    {
        static string js;
        static JavascriptContext ctx = new JavascriptContext();
        static VsaEngine Engine =new VsaEngine();// VsaEngine.CreateEngine();
        internal static object EvalJScript(string JScript)
        {
            object Result = null;
            try
            {
                Result = Microsoft.JScript.Eval.JScriptEvaluate(JScript, Engine);
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Result;

        }

        
        
        internal static string processText(string text){
            try
            {
                FileStream fs = new FileStream("replace.js", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                js = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

            }
            ctx.SetParameter("input", text);
            ctx.Run(js);
            return null;
        }
    }
}
