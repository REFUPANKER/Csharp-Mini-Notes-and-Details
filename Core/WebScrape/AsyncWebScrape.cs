using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
namespace Capp3
{

	public class Program
	{
		public static void Main()
		{
			cwl("Program Started");
			tryCatch(() =>
			{
				NetConCHC();
				M1();
			});
			cwl("> Main - END <");
		}
		static void tryCatch(Action act)
		{
			try
			{
				act.Invoke();
			}
			catch (Exception excp)
			{
				cwl("\n-----Error-----\n\n
        At:" + act.Method.Name + "
        Reason:" + excp.Message);
				cwl("\n---------------\n");
			}
		}
		static void cwl(object msg = null)
		{
			Console.WriteLine(msg);
		}
		static bool NetConCHC()
		{
			try
			{
				using (var wcl1 = new WebClient())
				{
					wcl1.OpenRead(new Uri("https://www.google.com"));
				}
				cwl("NetConCHC : true");
				return true;
			}
			catch
			{
				cwl("NetConCHC : false");
				return false;
			}
			return false;
		}
		
     static void M1()
		{

			string filePath = Environment.CurrentDirectory + "/webhtml.txt";
			var task1 = Task.Run(async () =>
			{
				try
				{
					WebRequest rq1 = HttpWebRequest.Create("https://m.doviz.com/");
					WebResponse rp1 = await rq1.GetResponseAsync();
					StreamReader rd1 = new StreamReader(rp1.GetResponseStream());
					StreamWriter wr1 = new StreamWriter(filePath);
					await wr1.WriteAsync(await rd1.ReadToEndAsync());
					return await rd1.ReadToEndAsync();
				}
				catch (Exception excp)
				{
					cwl("M1_Error:" + excp.Message);
				}
				return null;
			});
			//cwl(task1.Result);
			Console.Clear();
			cwl("Reading web ");
			int c = 1;
			while (task1.Wait(1) == false)
			{
				System.Threading.Thread.Sleep(100);

				if (c % 3 == 0)
				{
					Console.Clear();
					Console.Write("Reading web ");
				}
				c++;
				Console.Write("[]");
			}
			cwl("");
			var task2 = Task.Run(async () =>
			{
				cwl("Reading html file");
				StreamReader rd1 = new StreamReader(filePath);
				return await rd1.ReadToEndAsync();
			});
			task1.Dispose();
			string Phtml = task2.Result;
			task2.Dispose();
			try
			{
			replayPoint:
				int i1 = Phtml.IndexOf("data-socket-key");
				if (i1 < 0)
					return;
				int i2 = Phtml.Substring(i1).IndexOf("<");
				var r1 = Phtml.Substring(i1, i2);
				var r1K = r1.Substring(r1.IndexOf(""") + 1).Replace("\"", "").Replace(" ", "");
				r1K = r1K.Substring(0, r1K.IndexOf(""")).ToUpper();
				//cwl(r1K);
				var r1V = r1.Substring(r1.LastIndexOf(">") + 1).Replace("\n", "").Replace(" ", "");
				//cwl(r1V);
				cwl("=======");
				cwl(r1K + ":" + r1V);
				Phtml = Phtml.Replace(r1, "");
				goto replayPoint;
			}
			catch (Exception excp)
			{
				cwl("M1_Error:" + excp.Message);
			}
			//cwl(Phtml);
			string[] ikv = new string[filePath.Length];
		}
	}
}
