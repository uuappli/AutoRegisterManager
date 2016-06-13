using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Skynet.Framework.Common;
using System.Data;
using Skynet.Data;
using Skynet.ExceptionManagement;
using System.Data.SqlClient;

namespace AutoRegisterManager.Common
{
    public class SkyComm
    {
        public static string getvalue(string appkey)
        {
            string filename = Application.StartupPath + "\\system.config ";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filename);
            //得到顶层节点列表 
            XmlNodeList topM = xmldoc.DocumentElement.ChildNodes;
            foreach (XmlElement element in topM)
            {
                if (element.Name.ToLower() == "appsettings")
                {
                    //得到该节点的子节点 
                    XmlNodeList nodelist = element.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        try
                        {
                            for (int i = 0; i < nodelist .Count; i++)
                            {
                                try
                                {
                                    XmlElement el = (XmlElement)nodelist[i];
                                    if (el.Attributes["key"].Value == appkey)
                                    {
                                        return el.Attributes["value"].Value;
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception )
                        {
                            continue;
                        }
                    }
                }
            }
            return "";
        }
        public static void Init()
        {
            Skynet.Data.PersistenceProperty.ConnectionString = SkyComm.getvalue("connString");
            //Skynet.Data.PersistenceProperty.ConnectionString = "Database=v7_0;user id=db2Admin;password=dancinget;server=192.168.22.235";   
            Skynet.Data.PersistenceProperty.DatabaseType = DatabaseType.MSSQLServer;
            //MedicalCodeInfo.MedicalCode = SkyComm.getvalue("MedicalCode");
            UpdateSystemConfig();
            login();

            //SkyComm skyComm = new Common.SkyComm();
            //skyComm.QueryPatInfo("123");
            //skyComm.SaveRecharge("123", 100);
            //skyComm.CreatCard("123", "123", "123", "123", 100);
        }
        private static void login()
        {
            SysOperatorInfo.OperatorID = SkyComm.getvalue("OPERATORID");
            SysOperatorInfo.OperatorName = SkyComm.getvalue("OPERATORNAME");
            SysOperatorInfo.OperatorWorkkind = SkyComm.getvalue("OPERATORWORKKIND");
            SysOperatorInfo.UserID = SkyComm.getvalue("USERID");
            SysOperatorInfo.OperatorOffice = SkyComm.getvalue("OPERATOROFFICE");
            SysOperatorInfo.OperatorOfficeID = SkyComm.getvalue("OPERATOROFFICEID");
        }
        private static void UpdateSystemConfig()
        {
            //SystemConfigFacade sf = new SystemConfigFacade();
            //DataSet sysConfigData = sf.FindAll();
            //SystemConfigCollection sysConfigCollection = new SystemConfigCollection();
            //Skynet.Framework.Common.SystemConfig sysConfig = null;
            //foreach (DataRow row in sysConfigData.Tables[0].Rows)
            //{
            //    sysConfig = new Skynet.Framework.Common.SystemConfig();
            //    //配置编号
            //    sysConfig.ConfigureNo = row["CONFIGURENO"].ToString().Trim();
            //    //设置类型
            //    sysConfig.SetType = row["SETTYPE"].ToString().Trim();
            //    //设置内容
            //    sysConfig.SetContent = row["SETCONTENT"].ToString().Trim();
            //    //设置值
            //    sysConfig.DefaultValue = row["DEFAULTVALUE"].ToString().Trim();
            //    //说明
            //    sysConfig.Detail = row["DETAIL"].ToString().Trim();
            //    //可选参数
            //    sysConfig.OptionalPara = row["OPTIONALPARA"].ToString().Trim();
            //    sysConfigCollection.Add(sysConfig);
            //}
            //SystemInfo.SystemConfigs = sysConfigCollection;
        }
        /// <summary>
        /// 根据生日得到年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static string getage(string birthday)
        {
            int age = DateTime.Today.Year - Convert.ToDateTime(birthday).Year;
            if (age > 0)
            {
                return age.ToString() + "岁";
            }
            else
            {
                int month = DateTime.Today.Month - Convert.ToDateTime(birthday).Month;
                if (month > 0)
                {
                    return month.ToString() + "月";
                }
                else
                {
                    int day = DateTime.Today.Day - Convert.ToDateTime(birthday).Day;
                    if (day >= 0)
                    {
                        return day.ToString() + "天";
                    }
                }
            }
            return string.Empty;
        }

        public DataSet QueryPatInfo(string cardID)
        {
            SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
            sqlconn.Open();
            try
            {
              
                string sql = "";
                DataSet ds = new DataSet();
                sql = "SELECT * FROM VCARD_INFO WHERE CARDNO = '" + cardID + "'";
                SqlDataAdapter myDataAdapter;
                myDataAdapter = new SqlDataAdapter(sql, sqlconn);
                myDataAdapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw new LogonException(ex.Message, ex);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        public int SaveRecharge(string cardNo, decimal jinE)
        {
            SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
            sqlconn.Open();
            try
            {
                //CardCharge(@CardNo varchar(20),@JinE numeric(10,2)) @CardNo 卡号 @JinE 金额

                SqlCommand command = new SqlCommand("CardCharge", sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CardNo", SqlDbType.NVarChar);
                command.Parameters.Add("@JinE", SqlDbType.Decimal);

                command.Parameters["@CardNo"].Value = cardNo;
                command.Parameters["@JinE"].Value = jinE;

                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception e)
            {
                throw new LogonException(e.Message, e);
                //return -1;
            }
            finally
            {
                sqlconn.Close();
            }

        }

        public int CreatCard(string cardID, string xingMing, string sFZ, string diZhi, decimal JinE)
        {
            SqlConnection sqlconn = new SqlConnection(Skynet.Data.PersistenceProperty.ConnectionString);
            sqlconn.Open();
            try
            {
                //CreateCard(@CardNo varchar(12),@XingMing varchar(20),@SFZ varchar(20),@DiZhi varchar(20),@JinE Numeric(10,2)) 
                //@CardNo 卡号，@XingMing 姓名，@SFZ 身份证号码，@DiZhi 户口地址，@JinE 充值金额

                SqlCommand command = new SqlCommand("CreateCard", sqlconn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@CardNo", SqlDbType.NVarChar);
                command.Parameters.Add("@XingMing", SqlDbType.NVarChar);
                command.Parameters.Add("@SFZ", SqlDbType.NVarChar);
                command.Parameters.Add("@DiZhi", SqlDbType.NVarChar);
                command.Parameters.Add("@JinE", SqlDbType.Decimal);

                command.Parameters["@CardNo"].Value = cardID;
                command.Parameters["@XingMing"].Value = xingMing;
                command.Parameters["@SFZ"].Value = sFZ;
                command.Parameters["@DiZhi"].Value = diZhi;
                command.Parameters["@JinE"].Value = JinE;

                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception e)
            {
                throw new LogonException(e.Message, e);
                //return -1;
            }
            finally
            {
                sqlconn.Close();
            }

        }

    }
}
