

//网贷计算器JS文件(等额本息)
function GetDebx()
{
    var money=$("#txt_loanMoney").val().replace(/(^\s*)|(\s*$)/g, "");//投资金额
    var rate_year= $("#txt_rateYear").val().replace(/(^\s*)|(\s*$)/g, "") / 100; //计算年利息
    var rate_month = rate_year / 12;//月利息
    var timeLimit=$("#txt_timeLimit").val().replace(/(^\s*)|(\s*$)/g, "");
 
    var reg = /^\d+(?=\.{0,1}\d+$|$)/  //验证是否为正数
    if(money=="")
    {
        alert("请输入投资金额!");  
    }
    else if(!reg.test(money)){  
        alert("投资金额不正确!");  
    }  
    else if(rate_year=="")
    {
        alert("请输入年化利率!");  
    }
    else if(!reg.test(rate_year)){  
        alert("年化利率不正确!");  
    } 
    else if(timeLimit=="")
    {
        alert("请输入借款期限!");  
    }
    else if(!reg.test(timeLimit)){  
        alert("借款期限不正确!");  
    } 
    else
    {
        var HouseLoanObject = {};
        HouseLoanObject=CalAverageCapitalPlusInterestComm(timeLimit, money, rate_month);
        
        var LixiTotal=HouseLoanObject.Result.toFixed(2);//利息总和
        var BenxiTotal=HouseLoanObject.ResultCount.toFixed(2);//本息合计
        var RepayMonth=(BenxiTotal/12).toFixed(2);//每月还款
        
        document.getElementById("span_BenxiTotal").innerHTML=BenxiTotal+"元";
        document.getElementById("span_RepayMonth").innerHTML=RepayMonth+"元";
        document.getElementById("span_LixiTotal").innerHTML=LixiTotal+"元";
        
        document.getElementById("div_DebxResult").style.display="";
    }
}
/*
商业贷款等额本息计算通用方法
偿还本息 = （本金*月利息）*(1+月利息)^贷款期限)/((1+月利息)^贷款期限-1）
利息总额 = 偿还本息*总期数-本金
累计还款总额 = 偿还本息 * 总期数
每月月供=偿还本息
最高月付利息=本金*月利息^1
*/
/*
yearPeriad:总期数(月)
money:本金
monthInterest:月利率
*/
function CalAverageCapitalPlusInterestComm(yearPeriad, money, monthInterest) {
    /*偿还本息=(（本金*月利息）*(1+月利息)^贷款期限)/((1+月利息)^贷款期限-1）*/
    var repleyInterest = (money * monthInterest * Math.pow(1 + monthInterest, yearPeriad)) / (Math.pow(1 + monthInterest, yearPeriad) - 1);

    /*利息总额=偿还本息*总期数 - 本金*/
    var result = repleyInterest * yearPeriad - money;
    result = Math.abs(result.toFixed(2));

    /*累计还款总额=偿还本息* 总期数*/
    var resultCount = repleyInterest * yearPeriad;
    resultCount = Math.abs(resultCount.toFixed(2));

    /*每月月供=偿还本息*/
    var monthPayment = Math.abs(repleyInterest.toFixed(2));
    

    /*最高付款利息= 本金 * 月息^期次*/
    var maxPayment = money * Math.pow(monthInterest, 1);
    maxPayment = Math.abs(maxPayment.toFixed(2));
    var houseLoan = {};
    var houseLoanArray = new Array();
    for (var i = 1; i <= yearPeriad; i++) {
        var surplusPrincipal1 = money * Math.pow(1 + monthInterest, i) - repleyInterest * (Math.pow(1 + monthInterest, i) - 1) / monthInterest; /*剩余本金*/
        var surplusPrincipal2 = money * Math.pow(1 + monthInterest, i - 1) - repleyInterest * (Math.pow(1 + monthInterest, i - 1) - 1) / monthInterest; /*取上一次的本金计算每月偿还利息*/
        var repeyInt = surplusPrincipal2 * monthInterest; /*每月偿还利息*/
        var repeyPrincipal1 = Math.abs((repleyInterest - repeyInt).toFixed(2)); /*每月偿还本金*/

        var replyPrincipalIntreest = monthPayment; //偿还本息
        var replyInterest = (i != 1 ? repeyInt : maxPayment); //偿还利息
        var replyPrincipal = (i != 1 ? repeyPrincipal1 : (repleyInterest - maxPayment)); //偿还本金
        var surplusPrincipal = (i != 1 ? surplusPrincipal1 : (money - repleyInterest + maxPayment)); //剩余本金
        houseLoan = { ReplyPrincipalIntreest: replyPrincipalIntreest, ReplyInterest: replyInterest, ReplyPrincipal: replyPrincipal, SurplusPrincipal: surplusPrincipal };
        houseLoanArray.push(houseLoan);
    }
    var HouseLoanObject = {};
    HouseLoanObject.Result = result;
    HouseLoanObject.ResultCount = resultCount;
    HouseLoanObject.MonthPayment = monthPayment;
    HouseLoanObject.MaxPayment = maxPayment;
    HouseLoanObject.HouseLoan = houseLoanArray;
    return HouseLoanObject;
}
