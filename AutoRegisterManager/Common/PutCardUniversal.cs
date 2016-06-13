using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRegisterManager.SdkService;
using System.Data;
using Skynet.Framework.Common;
using Skynet.LoggingService;
using System.IO;
using System.Windows.Forms;

namespace AutoRegisterManager.Common
{
    /// <summary>
    /// 发卡
    /// 作者：李新华
    /// DATE：2013.1.10
    /// </summary>
    public class PutCardUniversal
    {
        K101SendCard k101 = new K101SendCard();

        public void OutCard(int sqadd, int blockAddr, IDCardInfo userInfo, decimal sumChargeMoney)
        {
            try
            {
                //PatientInfoFacade pfacade = new PatientInfoFacade();
                //string ConditionStr = " AND A.IDENTITYNAME='身份证' AND A.IDENTITYCARD='" + FrmMain.userInfo.Number.Trim() + "' AND B.CIRCUIT_STATE=0 ";
                //DataSet pdata = pfacade.FindCardPatientinfoByCondition(ConditionStr);
                //if (pdata!=null && pdata.Tables[0].Rows.Count > 0)
                //{
                //    MyMsg.MsgInfo("发卡失败！ 证件【" + FrmMain.userInfo.Number + "】已经办理了卡业务，请先到窗口注销后再继续办理！");
                //    return;
                //}

                //if (eLCardAuthorizationData != null)
                //{
                //    eLCardAuthorizationData.Tables[0].Rows.Clear();
                //}

                if (k101.CheckCardPosition() == false)
                {
                    MyMsg.MsgInfo("卡机状态不正确，不能继续发卡，请联系管理员!");
                    return;
                }

                string cardTemp = string.Empty;
                string cardType = SkyComm.getvalue("卡类型");

                if (cardType == "磁条卡")
                {
                    k101.MoveCard("移动到读磁卡位");
                    if (k101.MoveCard("移动到读磁卡位") == false)
                    {
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("卡片传动失败，不能继续发卡，请联系管理员!");
                        return;
                    }

                    cardTemp = k101.ReadCard();
                    if (cardTemp == string.Empty)
                    {
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("磁卡数据错误，或是空卡，不能继续发卡，请联系管理员!");
                        return;
                    }

                    FrmMain.cardInfoStruct.CardNo = cardTemp;
                    string sql = "SELECT * FROM T_PRECARD WHERE CARDID = '" + cardTemp + "'";
                    //DataSet dsPre = new QuerySolutionFacade().ExecCustomQuery(sql);
                    //if (dsPre.Tables[0].Rows.Count <= 0)
                    //{
                    //    k101.MoveCard("回收卡片");
                    //    MyMsg.MsgInfo("卡片数据非法，请重试发卡，或联系管理员!");
                    //    return;
                    //}

                    //ConditionStr = " AND B.CARDID='" + cardTemp + "' AND (B.CIRCUIT_STATE=0 OR B.CIRCUIT_STATE=1) ";
                    //pdata = pfacade.FindCardPatientinfoByCondition(ConditionStr);
                    //if (pdata != null && pdata.Tables[0].Rows.Count > 0)
                    //{
                    //    k101.MoveCard("回收卡片");
                    //    MyMsg.MsgInfo("发卡失败！ 卡片损坏，请重试发卡！");
                    //    return;
                    //}
                }

                string CardNo = cardTemp;

                SkyComm skyComm = new SkyComm();
                skyComm.CreatCard(CardNo, FrmMain.userInfo.Name, FrmMain.userInfo.Number, FrmMain.userInfo.Address, sumChargeMoney);
              

                bool isSuccess = true;
                if (cardType == "IC卡")
                {
                    k101.MoveCard("传动到IC卡位");
                    if (k101.MoveCard("传动到IC卡位") == false)
                    {
                        k101.MoveCard("回收卡片");
                        MyMsg.MsgInfo("卡片传动失败，不能继续发卡，请通过补办卡重新发卡!");
                        return;
                    }

                    //写卡，如果失败则重试
                    int state = -1;
                    while (0 != state)
                    {
                        state = k101.WriteCard(CardNo);

                        if (state != 0)
                        {
                            MyAlert my = new MyAlert();
                            my.Msg = "写卡失败，是否重试?";
                            my.alerttype = "确认取消";
                            if (my.ShowDialog() == DialogResult.OK)
                            {
                                state = -1;
                            }
                            else
                            {
                                state = 0;
                            }
                            isSuccess = false;
                        }
                        else
                        {
                            isSuccess = true;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(cardTemp))
                {
                    if (isSuccess == true)
                    {
                        //吐出卡片
                        if (k101.MoveCard("传动到前端夹卡位") == false)
                        {
                            MyMsg.MsgInfo("吐卡失败！请通过补办卡重新发卡！");
                            isSuccess = false;
                        }
                        else
                        {
                            isSuccess = true;
                            MyMsg.MsgInfo("发卡成功！");
                        }
                    }

                    if (isSuccess == false)
                    {
                        k101.MoveCard("回收卡片");
                        //CardFreezeThawData eCardFreezeThawData = (CardFreezeThawData)eCardAuthorizationFacade.SelectPatientAndCardInfoByAccount_ID_FREEZE_THAW(eLCardAuthorizationData.Tables[0].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_ACCOUNT_ID].ToString());
                        //20100616 mzq
                        //if (eCardFreezeThawData.Tables[0].Rows.Count <= 0)
                        //{
                        //    MyMsg.MsgInfo("此操作没有找到所要挂失的卡信息!");
                        //    return;
                        //}
                        //eCardFreezeThawData.Tables["T_CARD_FREEZE_THAW_ATHU"].Rows[0].BeginEdit();
                        ////冻结时间
                        //eCardFreezeThawData.Tables["T_CARD_FREEZE_THAW_ATHU"].Rows[0][CardFreezeThawData.T_CARD_FREEZE_THAW_LOCKDATE] = DateTime.Now;
                        //////冻结员
                        //eCardFreezeThawData.Tables["T_CARD_FREEZE_THAW_ATHU"].Rows[0][CardFreezeThawData.T_CARD_FREEZE_THAW_LOCKOPERATOR] = SysOperatorInfo.OperatorID;
                        //eCardFreezeThawData.Tables["T_CARD_FREEZE_THAW_ATHU"].Rows[0].EndEdit();

                        //1.在中间层更新发卡表T_CARD_AUTHORIZATION的CIRCUIT_STATE为1（冻结状态）信息
                        //2.在中间层插入T_CARD_FREEZE_THAW表信息
                        //CardFreezeThawaFcade eCardFreezeThawaFcade = new CardFreezeThawaFcade();
                        //eCardFreezeThawaFcade.insertEntity(eCardFreezeThawData);

                        MyMsg.MsgInfo("写卡失败，请通过补办卡重新发卡！");

                        //this.eLCardAuthorizationData = (CardAuthorizationData)eCardAuthorizationFacade.SelectPatientAndCardInfoByCardID(eLCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_CARDID].ToString());
                    }
                }
            }
            catch (Exception err)
            {
                k101.MoveCard("回收卡片");
                MyMsg.MsgInfo("吐卡失败！请重试自助发卡！" + err.Message);
                //this.eLCardAuthorizationData.Clear();
            }

        }

        public int OutCardD1000(int sqadd, int blockAddr, IDCardInfo userInfo, decimal sumChargeMoney)
        {
            try
            {
                D1000Card d1000 = new D1000Card();
                string cardstate = d1000.CheckState();
                if (cardstate != string.Empty)
                {
                    MyMsg.MsgInfo(cardstate);
                    return -1;
                }

                if (d1000.sendcmd("DC") == false)
                {
                    MyMsg.MsgInfo("卡片传动失败，不能继续发卡，请通过补办卡重新发卡!");
                    return -1;
                }


                string CardNo = string.Empty;
                FrmInCardM100Send fi = new FrmInCardM100Send();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    CardNo = FrmMain.cardInfoStruct.CardNo;
                    SkyComm skyComm = new SkyComm();
                    try
                    {
                        skyComm.CreatCard(CardNo, FrmMain.userInfo.Name, FrmMain.userInfo.Number, FrmMain.userInfo.Address, sumChargeMoney);
                    }
                    catch
                    {
                        MyMsg.MsgInfo("卡号重复，请插入新卡后尝试重新办卡");
                        return -1;
                    }


                    //bool isSuccess = true;
                    //MyMsg.MsgInfo("办卡成功！");
                }
                else
                {
                    MyMsg.MsgInfo("发卡失败！请重试自助发卡！");
                    return -1;
                }

                return 0;
            }
            catch (Exception err)
            {
                //k101.MoveCard("回收卡片");
                MyMsg.MsgInfo("吐卡失败！请重试自助发卡！" + err.Message);
                return -1;
                //this.eLCardAuthorizationData.Clear();
            }

        }

        /// <summary>
        /// 检查此卡号是否已经发过卡
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public string check(string cardID)
        {
            //CardAuthorizationFacade eCardAuthorizationFacade = new CardAuthorizationFacade();
            //DataSet ds = eCardAuthorizationFacade.SelectPatientAndCardInfoByCardID(cardID);//this.tbxCardID.Text.Trim()
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return "该病人已发卡，不能重复发卡！";

            //}
            return string.Empty;
        }
        /// <summary>
        /// 得到卡类型
        /// </summary>
        /// <returns></returns>
        public DataRow cardType()
        {
            //CardTypesFacade cardTypesFacade = new CardTypesFacade();
            //DataSet dscardTypes = cardTypesFacade.SelectAllItems();
            //if (dscardTypes==null ||dscardTypes.Tables[0].Rows.Count == 0)
            //{
            //    MyMsg.MsgInfo("没有得到卡类型数据，请维护");
            //    return null;
            //}
            //return dscardTypes.Tables[0].Select("TYPE_NAME like '%一卡通%'")[0];//需要改动
            return null;

        }
    }
}
