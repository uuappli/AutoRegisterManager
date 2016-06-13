using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoRegisterManager.Common;
using CardInterface.D3_DLL;

namespace AutoRegisterManager
{
    public partial class FrmCardSummary : Form
    {
        public FrmCardSummary()
        {           
            InitializeComponent();

            textBox1.Text = "1、\t什么是医卡通？\r\n医卡通是我院就诊时必须使用的一种智能卡，它是代表就诊者身份、存贮患者医疗者医疗信息档案的医疗保健卡。\r\n\r\n2、\t用医卡通有哪些好处\r\n就医方便快捷：只要您在卡中存入足够的钱，您可以不用挂号交费而直接到门诊各诊室就诊、到药房取药、到检查科室检查。自助查询您的信息：您随时可以到我们设在门诊大厅内的触摸屏，查询您就医期间的所有费用清单，您还可以查询您卡中的余额。集中打印发票：您看完病后，可以到收费处一次性打印出就诊期间的所有发票，避免反复排队缴款、收据多容易丢失的弊端。完整的就诊记录：只要您拥有一张卡，医生就能查询到您历次来院就诊的用药、检查、诊断和门诊病历的详细记录，有利于医生对您的病情做出全面、准确的诊断。\r\n\r\n3、\t怎样使用医卡通通？\r\n初诊病人首先在发卡充值处购一张磁卡，然后根据您的病情预交一部分暂存款，这部分暂存款将存在您个人账户中，在就医的过程中所花费的费用计算机会自动扣除。卡中的余额您可以随时到发卡充值处取出，也可以下次留用，医院将永久保留您的账户。复诊病人直接到诊室就医。病人到诊室后，将磁卡交给大夫，大夫刷卡后计算机自动扣除挂号费和诊疗费。如果卡中的金额不足挂号费，您需到发卡充值处充值，大夫在计算机上开完检查单后，您可以直接持卡到相应的科室做检查\r\n到检查科室后，由检查科室的工作人员，根据检查申请刷卡减费，如果卡中的金额不足检查费，您需到发卡充值处充值，病人在检查科室索取检查报告单，不需要的，直接回到诊室确诊。回到诊室需要药物治疗的病人，大夫会用计算机开处方，如果有您不想要的药请当场提出。开完药后请持卡到药房直接取药，需要输液的病人，请到急诊护士站打印注射单并进行治疗。如果卡中的金额不足支付药费，您需到发卡充值处充值，充值后再回药房取药。需要做皮试的病人，请先做皮试再到药房取药。\r\n注：处方当日有效。\r\n就诊完毕，患者可以到收费处索取发票并到发卡充值处退回余款，也可以将现金存在卡中待下次复诊时使用。\r\n\r\n4、\t我是社会医疗保险病人怎么办？\r\n医疗保险病人就诊时，持医保IC卡到发卡充值处办理就诊卡权限转移手续，暂存一笔现金，然后持医院就诊卡到各诊室直接就诊，就诊完成后到收费处医保结算窗口索要发票。根据医保规定不允许病人提取现金，余款将存在卡中下次使用。\r\n\r\n5、\t卡中的钱有保障吗？\r\n我们将为每个病人设置一个账户，每个账户对应一张卡并对每一张卡进行了安全保障设置，计算机将永久保存每个账户每笔存取款情况和消费情况，您随时可以查询您的存取款情况和消费情况，计算机系统将确保您的账目清楚安全。\r\n\r\n6、\t卡中的钱可以随时存取吗？\r\n卡中的余额可以随时到发卡充值处取出，取款时请提供您的取款信息或身份证，并输入您的密码。\r\n\r\n7、\t卡丢了怎么办？\r\n卡丢失后请立即到发卡充值处办理挂失手续进行资金冻结，并补发新卡，计算机系统将恢复您原来的门诊电子病历及存取款、消费信息。\r\n";
        }

        private void FrmInCardUniversal_Load(object sender, EventArgs e)
        {
            if (this.top1.AutoClose)
            {
                this.top1.timer1.Start();
            }
        }

        private void FrmInCardUniversal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.top1.timer1.Stop();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
