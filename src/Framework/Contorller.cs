using System;
using System.IO;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using LPLERP.Common;
using System.Security.Principal;

namespace LPLERP.Engine
{
	sealed class Controller
	{

		public static frmContainer Container;
		public static frmMain FormMain;

		private static SplashScreen objSplash = new SplashScreen(true);
		private static string configPath = "";
		private const string XMLFileName = "DBConfig";
		
		private static Utility objUtility = new Utility();
		private static string strDomainName = "";

		public static string DBServerName = "";
		public static string DBName = "";
		public static string DBUser = "";
		public static string DBPwd = "";	

		[System.STAThread]
		static void Main() 
		{			
			objSplash.Show();
			System.Windows.Forms.Application.DoEvents();
			objSplash.Message.Text = "Loading...";
			objSplash.lblLicensedHeader.Text = "";				
			objSplash.Message.Text = "Checking Version...";
			if(!compareVersion())
			{
				Application.Exit();
				return;
			}
			objSplash.Message.Text = "Loading Database Information...";				
			loadDBInformation();
			objSplash.Message.Text = "Checking Security...";
			objSplash.Message.Refresh();

			FormMain = new frmMain();
			frmPassword FormToLogin = new frmPassword();
			
			objSplash.Close();				
			FormToLogin.ShowDialog();						

			if(User.IsLoggedIn)
			{
				Utility.showInformation("Welcome to our application...");
				FormMain.WindowState = FormWindowState.Minimized;
				//Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);					
				Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
				Application.Run(FormMain);
			}
			else
			{
				Application.Exit();
			}			
		}
		public static string DomainName
		{
			get
			{
				if (strDomainName.Length == 0)
				{
					strDomainName = getDomainName();
				}
				return strDomainName;
			}
		}
		private static string getDomainName()
		{
			try
			{
				AppDomain myDomain = Thread.GetDomain();

				myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
				WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;

				string FullUserName = myPrincipal.Identity.Name.ToString();
				string []strTemp;
				string strSplit=@"\";
				char []spliter=strSplit.ToCharArray();
				strTemp=FullUserName.Split(spliter);
				if (strTemp.Length > 0)
					return  strTemp[0];
				else
					return null;
			}
			catch
			{
				return null;
			}
		}
		private static bool compareVersion()
		{
			try
			{					
				string versionFile = "\\VersionConfig.xml";
                string versionExe = "\\LPLERP.VersionController.exe";
                string versionPDB = "\\LPLERP.VersionController.pdb";
				if(System.IO.File.Exists(System.Environment.CurrentDirectory + versionFile)
					&& System.IO.File.Exists(System.Environment.CurrentDirectory + versionExe))
				{
					DataSet ds = new DataSet();
					ds.ReadXml(System.Environment.CurrentDirectory + versionFile);				
					if(ds.Tables[0].Rows.Count > 0)
					{					
						if(System.IO.File.Exists(ds.Tables[0].Rows[0][0] + versionFile))
						{							
							if(File.GetLastWriteTime(ds.Tables[0].Rows[0][0] + versionFile).CompareTo(File.GetLastWriteTime(System.Environment.CurrentDirectory + versionFile)) <= 0)
							{
								return true;
							}
							else
							{								
								File.Copy(ds.Tables[0].Rows[0][0].ToString() + versionExe, System.Environment.CurrentDirectory + versionExe, true);
								File.Copy(ds.Tables[0].Rows[0][0].ToString() + versionExe, System.Environment.CurrentDirectory + versionPDB, true);								
								System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + versionExe);
								return false;
							}
						}					
					}
				}
				return true;
			}
			catch(Exception ex)
			{
				throw new Exception("System can't update version properly please consult with MIS department.\n" + ex.Message);
			}
		}
		#region DB Info
		public static void loadDBInformation()
		{
			try
			{
				DataSet dsDBConfig = new DataSet();

				getDbXMLFileDS(ref dsDBConfig);
				getXMLFileData(ref dsDBConfig); 				
			}
			catch
			{
				Utility.messageBox("Unable to load DB information. Please consult with MIS Department.",MessageBoxButtons.OK,MessageBoxIcon.Error );
			}
		}

		private static void getDbXMLFileDS(ref DataSet dsDBConfig)
		{
			try
			{
				configPath = System.AppDomain.CurrentDomain.BaseDirectory;                
				dsDBConfig = new DataSet();
				dsDBConfig.ReadXmlSchema (configPath + XMLFileName + ".xsd");
				dsDBConfig.ReadXml(configPath + XMLFileName + ".xml");
			}
			catch(Exception ex)
			{               
				throw ex;
			}

		}
		private static void getXMLFileData(ref DataSet dsDBConfig)
		{
			try
			{
				DataRow dr;
				if (dsDBConfig.Tables.Count >0)
				{
					for(int i=0 ;i<dsDBConfig.Tables[0].Rows.Count ; i++)
					{
						dr = dsDBConfig.Tables[0].Rows[i];

						makeRowReadable(ref dr);

						if (Convert.ToInt32(dr["IsDefault"].ToString())==1)
						{
							DBServerName=dr["ServerName"].ToString();
							DBName=dr["DatabaseName"].ToString();
							DBUser=dr["UserName"].ToString();
							DBPwd=dr["Password"].ToString();
  
							break;
						}						 
					}
				}				
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}	
	
		private static void makeRowReadable(ref DataRow drDefault)
		{
			try
			{
				//Encryption.EncryptionEngine objED = new Encryption.EncryptionEngine();
				
				Encryption objEncryption = new Encryption();
				string strUserID = "";
				if (drDefault["UserName"] != DBNull.Value )
				{
					strUserID = drDefault["UserName"].ToString();
				}

				// Data Source or Server
				if (drDefault["ServerName"] == DBNull.Value)
				{
					drDefault["ServerName"] = "(local)";
				}
				else if(drDefault["ServerName"].ToString().Length == 0)
				{
					drDefault["ServerName"] = "(local)";
				}
				else
				{
					drDefault["ServerName"] =objEncryption.DecryptWord(drDefault["ServerName"].ToString(),strUserID);
				}


				// Password  or pwd
				if (drDefault["Password"] == DBNull.Value)
				{
					drDefault["Password"]= "";
				}
				else if(drDefault["Password"].ToString().Length == 0)
				{
					drDefault["Password"]= "";
				}
				else
				{
					drDefault["Password"]= objEncryption.DecryptWord(drDefault["Password"].ToString(),strUserID);
				}

				//Initial Catalog or database
				if (drDefault["DatabaseName"] == DBNull.Value)
				{
					drDefault["DatabaseName"] = "";
				}
				else if(drDefault["DatabaseName"].ToString().Length == 0)
				{
					drDefault["DatabaseName"] = "";
				}
				else
				{
					drDefault["DatabaseName"] = objEncryption.DecryptWord(drDefault["DatabaseName"].ToString(),strUserID);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		#endregion
		#region exception handle
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
                Utility.messageBox("An error occurred please contact the adminstrator with the following information:\n\n" + e.Exception.Message, MessageBoxIcon.Information);
				if(!User.IsLoggedIn)				
					Application.Exit();
			}
			catch
			{					
				Application.Exit();				
			}
		}
		#endregion

		
	}


}
