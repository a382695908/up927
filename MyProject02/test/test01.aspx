<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test01.aspx.cs" Inherits="MyProject02.test.test01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>无标题页</title>
<link href="/test/css/test01.css" rel="stylesheet" type="text/css" />
<script src="/test/js/jquerym.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">

<div style="width:100%; background:#e5e5e5;">
    <div style="width:960px; height:40px;margin:0px auto;">
        <div class="f14_ff6e00" style="line-height:40px; float:left;">服务热线：4000-533-777</div>
        <div class="topRight fl4_333">
            <a href="#">活动专区</a>
            <a href="#">注册</a>
            <a href="#">登陆</a>
        </div>
    </div>
</div>

<div style="width:100%;">
    <div style="width:960px; height:80px; margin:0px auto; padding-top:10px;">
        <div style="float:left;">
            <a href="#"><img src="/test/images/logo.png" style="border:none;"/></a>
            <img src="/test/images/logo1.png"/>
        </div>
        <div class="topRight1">
            <span><a href="#">首页</a></span>
            <span><a href="#" onmouseover="$('#topXL01').show()" onmouseout="$('#topXL01').hide()">我要投资</a> </span>
            <span><a href="#" onmouseover="$('#topXL02').show()" onmouseout="$('#topXL02').hide()">我要借款</a> </span>
            <span><a href="#">关于我们</a> </span>
            <span><a href="#">我的账户</a></span>
            <div id="topXL01" class="topXL01" style="margin-left:60px;" onmouseover="$('#topXL01').show()" onmouseout="$('#topXL01').hide()">
                <dl><a href="#">我要投资</a></dl> 
                <dl><a href="#">我要借款</a></dl> 
                <dl><a href="#">关于我们</a></dl> 
                <dl><a href="#">我的账户</a></dl>
            </div>
            <div id="topXL02" class="topXL01" style="margin-left:160px;" onmouseover="$('#topXL02').show()" onmouseout="$('#topXL02').hide()">
                <dl><a href="#">我要投资1</a></dl> 
                <dl><a href="#">我要借款1</a></dl> 
                <dl><a href="#">关于我们1</a></dl> 
                <dl><a href="#">我的账户1</a></dl>
            </div>
        </div>
    </div>
</div>

<div style="height:360px; background:url('/test/images/bbd_banner20150113_05.jpg')">
    <div style="z-index:1; position:absolute; padding:10px;  margin-top:30px; right:20%; width:289px; background:url('/test/images/ind_banbg01.png')">
        <div style="font-size:20px;margin-top:10px;" align="center">贝贝贷年化收益率</div>
        <div style=" line-height:40px; margin-top:10px; color:#ca2626; font-size:36px; text-align:center;">11%-14%</div>
        <div style=" line-height:40px; margin-top:10px;  text-align:center;"><span style="color:#ca2626;">30</span> 倍活期存款收益 <span style="color:#ca2626;">4</span> 倍定期存款收益</div>
        <div class="ind_btn01" align="center"><a href="#">立即注册</a></div>
        <div style="float:right; margin-top:10px; font-size:14px;">已有账户？<span class="fl4_333"><a href="">立即登录</a></span></div>
    </div>
</div>

<div style="border-bottom:#c7c7c7 1px solid; line-height:40px; ">
    <div style="margin:0 auto; width:960px;clear:both;" class="fl4_333">公告：<a href="#">贝贝贷05.07车辆质押标发标公告</a></div> 
    <div style="margin:0 auto; width:960px; line-height:45px;">
        <div style="background:url('/test/images/ind_bobaobg01.png') no-repeat left center; padding-left:25px; float:left; margin-top:2px;">数据播报:</div>
        <div style="float:left; margin-left:50px;"><span class="f24_06b4e9">3372</span> 名累计注册人数</div>
        <div style="float:left; margin-left:50px;"><span class="f24_06b4e9">530000.00 </span> 元本月成交额</div>
        <div style="float:left; margin-left:50px;"><span class="f24_06b4e9">28313000.00 </span> 28313000.00 </div>
        <div style="clear:both;"></div>
    </div>
</div>


<div style="margin:0 auto; width:960px; padding-top:20px;">
    <div style="float:left; width:260px; border-right:#d6d6d6 1px dashed;">
        <div class="ind_aq" style="float:left;"></div>
        <div style="float:left; margin-left:15px; width:55%">
            <div class="f18_333">安全</div>
            <div class="fl4_333" style="margin-top:15px;">不动产抵押，千万风险金，全额债权收购</div>
        </div>
    </div>
    <div style="float:left; width:260px; border-right:#d6d6d6 1px dashed; margin-left:10px;">
        <div class="ind_wj" style="float:left;"></div>
        <div style="float:left; margin-left:15px; width:55%">
            <div class="f18_333">稳健</div>
            <div class="fl4_333" style="margin-top:15px;">倡导低成本融资、低利率投资</div>
        </div>
    </div>
    <div style="float:left; width:260px; border-right:#d6d6d6 1px dashed; margin-left:10px;">
        <div class="ind_gf" style="float:left;"></div>
        <div style="float:left; margin-left:15px; width:55%">
            <div class="f18_333">规范</div>
            <div class="fl4_333" style="margin-top:15px;">专业团队、程序合规、过程透明、标准评级</div>
        </div>
    </div>
    <div style="clear:both;"></div>
</div>

<div style="width:960px;margin:30px auto;">
    <div style="float:left; width:60%;">
        <div style=" background:#ccced8; width:100%; height:30px; padding-left:10px; padding-right:10px; line-height:30px;">
            <span style="float:left;">精选P2P理财</span>
            <span style="float:right;" class="fl8_333"><a href="#">更多</a></span>
        </div>
        <div style=" background:#fff; width:100%;">
            <div class="ind_mainInfo">
                <div class="ind_tj_b"></div>
                <div class="fl6_333" style="text-align:center; line-height:30px;"><a href="#">“500抵1000”贝贝贷新版上线</a></div>
                <div style="margin-left:35px; float:left; width:150px;"><span class="f34_06b4e9">12.53</span><span class="f24_06b4e9">%</span></div>
                <div style="float:left; padding-top:18px;">6个月</div>
                <div style="clear:both;"></div>
                <div class="fl4_333" style="margin-left:35px; float:left; width:140px;">年利率</div>
                <div class="fl4_333" style="float:left; ">借款期限</div>
                <div class="fl4_333" style="clear:both;margin-left:34px; margin-top:40px;">借款金额：20000 元</div>
                <div class="fl4_333" style="margin-left:34px; margin-top:10px;">剩余金额：0 元</div>
                <div style="margin-left:65px; margin-top:10px;">
                    <dl style="border:#ffc300 1px solid; width:120px; height:4px;float:left;">
                        <dd style="width:50%; height:4px; text-align:center; background:#ffc300; margin:0;"></dd>
                    </dl>
                    <div style="float:left; margin-top:8px; margin-left:10px; font-size:14px;">20%</div>
                </div>
                <div class="ind_btn_loan" style="margin-left:65px; margin-top:50px;color:#fff; line-height:38px; cursor:pointer;"><a href="#"><div class="ind_btn02" style="padding-left:40px;">马上投标</div></a></div>
            </div>
            
            <div class="ind_mainInfo">
                <div class="ind_tj_j"></div>
                <div class="fl6_333" style="text-align:center; line-height:30px;"><a href="#">美容院周转汽车质押</a></div>
                <div style="margin-left:35px; float:left; width:150px;"><span class="f34_06b4e9">18</span><span class="f24_06b4e9">%</span></div>
                <div style="float:left; padding-top:18px;">6个月</div>
                <div style="clear:both;"></div>
                <div class="fl4_333" style="margin-left:35px; float:left; width:140px;">年利率</div>
                <div class="fl4_333" style="float:left; ">借款期限</div>
                <div class="fl4_333" style="clear:both;margin-left:34px; margin-top:40px;">借款金额：20000 元</div>
                <div class="fl4_333" style="margin-left:34px; margin-top:10px;">剩余金额：0 元</div>
                <div style="margin-left:65px; margin-top:10px;">
                    <dl style="border:#ffc300 1px solid; width:120px; height:4px;float:left;">
                        <dd style="width:50%; height:4px; text-align:center; background:#ffc300; margin:0;"></dd>
                    </dl>
                    <div style="float:left; margin-top:8px; margin-left:10px; font-size:14px;">20%</div>
                </div>
                <div class="ind_btn_loan" style="margin-left:65px; margin-top:50px;color:#fff; line-height:38px; cursor:pointer;"><a href="#"><div class="ind_btn02" style="padding-left:40px;">马上投标</div></a></div>
            </div>
            
            <div style="clear:both;"></div>
        </div>
        
        
    </div>
    
    <div style="float:right; width:35%;">
        <div style="background:#ccced8; width:100%; height:30px;line-height:30px; padding-left:10px; padding-right:10px;">
            <span style="float:left;">公告</span>
            <span class="fl8_333" style="float:right;"><a href="#">更多</a></span>
        </div>
        <div>
            <ul style="line-height:30px;">
                <li class="fl4_333"><a href="#">互联网+金融+机会=兼职贝贝贷！</a><span style="float:right;">04-27</span></li>
                <li class="fl4_333"><a href="#">贝贝贷新增推广链接15天有效期功能</a><span style="float:right;">04-27</span></li>
                <li class="fl4_333"><a href="#">互联网+金融+机会=兼职贝贝贷！</a><span style="float:right;">04-27</span></li>
                <li class="fl4_333"><a href="#">贝贝贷新增推广链接15天有效期功能</a><span style="float:right;">04-27</span></li>
                <li class="fl4_333"><a href="#">互联网+金融+机会=兼职贝贝贷！</a><span style="float:right;">04-27</span></li>
            </ul>
        </div>
        <div style="margin-left:10px; margin-top:10px;">
            <embed id="flashfirebug_1427789961977" width="320" height="130" wmode="Opaque" src="/test/images/beibei.swf" name="flashfirebug_1427789961977" allowscriptaccess="always" allowfullscreen="true" allownetworking="all">
        </div>
    </div>
    <div style="clear:both;"></div>
</div>

<div style="width:960px;margin:30px auto;">
    <div style="float:left; width:60%;">
        <div style="background:#ccced8; width:100%; height:30px; padding-left:10px; padding-right:10px; line-height:30px;">
            <span style="float:left;">投资列表</span>
            <span style="float:right;" class="fl8_333"><a href="#">更多</a></span>
        </div>
        <div style="width:100%;padding-right:10px; line-height:30px;">
            <div style=" background:url('/test/images/15classbiaobg01.png') no-repeat -55px; padding-top:40px;padding-right:10px; width:85px; height:85px; float:left;"></div>
            <div style="float:left;">
                <dl style="line-height:40px;">
                    <dt class="fl8_333"><a href="#">服装进货周转</a></dt>
                    <dt class="fl8_333">借款金额：300000 元 年利率：13% 借款期限：3个月 </dt>
                </dl>
            </div>
            <div style="float:left;">
                <div style="margin-top:30px; margin-left:5px;">
                    <dl style="border:#ffc300 1px solid; width:55px; height:4px; float:left;">
                        <dd style="width:20%; height:4px; color:#ffc300;"></dd>
                    </dl>
                    <div class="fl4_333" style="float:left; margin-top:2px; margin-left:5px;">20%</div>
                </div>
            </div>
        </div>
    </div>
</div>

</form>
</body>
</html>
