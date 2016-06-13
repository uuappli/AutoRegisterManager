using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardInterface;
using System.Data;
using System.Windows.Forms;

namespace AutoRegisterManager.Common
{
    public class CardRead : CardBase
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="parent">载体</param>
        public CardRead(object parent): base(parent) 
        {
          
        }

        /// <summary>
        /// 初始化并打开卡机
        /// </summary>
        protected override void Open()
        {
            return;
        }

        /// <summary>
        /// 写卡
        /// </summary>
        /// <param name="message"></param>
        public override void Write(CardInformationStruct message)
        {
            return;
        }

        /// <summary>
        /// 读卡
        /// </summary>
        /// <returns></returns>
        public override CardInformationStruct Read()
        {

            try
            {
                return new CardInformationStruct(FrmMain.cardInfoStruct .CardNo);
            }
            catch (Exception)
            {
                throw new Exception("读卡失败！");
            }
            
            
        }
        /// <summary>
        /// 读卡返回病人信息实体
        /// </summary>
        /// <param name="mark">区别门诊【mark="C"】或者住院【mark!="H"】或者出院【mark!="L"】</param>
        /// <param name="cardInfoStruct">卡信息</param>
        /// <param name="isZz">是否是自助打印</param>
        /// <returns>病人信息实体</returns>
        public override DataSet OpenAndGetPatiantInfo(string mark, ref  CardInformationStruct cardInfoStruct)
        {
                if (mark.ToUpper() == "R")//若为挂号,采用原有刷卡操作逻辑
                {
                    try
                    {
                        FrmMain.cardInfoStruct = this.Read();

                        //FrmMain.cardInfoStruct.CardNo = "000118247826721";//仅作测试 需要删除
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            int IS_FEECHARGING_CARD = -1;
            DataSet dsReturn = new DataSet();

          
            //判断当前卡状态
            //0 正常1 冻结2 注销
            if (cardInfoStruct.CardNo != null )
            {
                //DataSet dsCard = eCardAuthorizationFacade.getCardStatusByAccount_ID(FrmMain.cardInfoStruct.CardNo);
                //if (dsCard != null && dsCard.Tables.Count <= 0 && dsCard.Tables[0].Rows.Count <= 0)
                //{
                //    throw new Exception("卡号不存在或此卡已被注销，不能继续使用!");
                //}
                //if (dsCard.Tables[0].Rows.Count <= 0)
                //{
                //    throw new Exception("卡号不存在或此卡已被注销，不能继续使用!");
                //}
                //FrmMain.cardData = dsCard.Copy();
                //FrmMain.cardInfoStruct.CardAccountID = dsCard.Tables[0].Rows[0]["ACCOUNT_ID"].ToString();
                //string cir_sta = dsCard.Tables[0].Rows[0]["CIRCUIT_STATE"].ToString();
                //string cir_sta_auditing = dsCard.Tables[0].Rows[0]["AUDITING_STATE"].ToString();
                //FrmMain.cardInfoStruct.CardTypeID = Convert.ToInt32(dsCard.Tables[0].Rows[0]["TYPEID"]);

                //if (cir_sta == "1")
                //{
                //    throw new Exception("此卡已冻结，不能继续使用!");
                //}
                //else if (cir_sta == "2")
                //{
                //    throw new Exception("此卡已注销，不能继续使用!");
                //}
                //else if (cir_sta_auditing == "1")//当卡没有冻结或注销时，才判断是否需要审核
                //{
                //    //卡未审核
                //    throw new Exception("此卡还未审核，不能继续使用!");
                //}

                //if (mark.ToUpper() == "C" || mark.ToUpper() == "R")//门诊
                //{

                //    dsReturn = eCardAuthorizationFacade.OpenAndGetPatiantInfoByAccount_IDForClinic(FrmMain.cardInfoStruct.CardAccountID, ref IS_FEECHARGING_CARD);
                //}
                //else if (mark.ToUpper() == "H")//住院
                //{
                //    dsReturn = eCardAuthorizationFacade.OpenAndGetPatiantInfoByAccount_IDForInpatient(FrmMain.cardInfoStruct.CardAccountID, ref IS_FEECHARGING_CARD);
                //}
                //else if (mark.ToUpper() == "L")//出院
                //{
                //    dsReturn = eCardAuthorizationFacade.OpenAndGetPatiantInfoByAccount_IDForLeave(FrmMain.cardInfoStruct.CardAccountID, ref IS_FEECHARGING_CARD);
                //}
                //else
                //{
                //    throw new Exception("参数错误，不能继续使用!");
                //}
                FrmMain.cardInfoStruct.Is_FEECHARGING_CARD = IS_FEECHARGING_CARD;
                dsReturn.WriteXml(Application.StartupPath + "\\ReportXML\\CardInterface.xml");
                return dsReturn;
            }
            return null;
        }
        /// <summary>zx
        /// 关闭卡机
        /// </summary>
        protected override void Close()
        {
            return;
        }
    }
}
