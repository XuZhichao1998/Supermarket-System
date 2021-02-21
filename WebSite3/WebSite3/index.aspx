<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市首页</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <script type="text/javascript" src="JavaScriptPicture.js"></script>
</head>
<body onload="initText()">
    <h1>欢迎来到海之星超市</h1>
    <p class="submit">如果您是超市管理员，请<a href="login.aspx">登录</a></p>
    <p class="submit">如果您是顾客，请<a href="custRegister.aspx">登录或注册</a></p>
    <p class="submit">如果您是收银员，请点击<a href="cashierLogin.aspx">登录</a>
    <p class="gushi">海之星超市是一家新兴的中小型超市。目前只有一家分店，但是日后会发展为连锁店。商店主要售卖的货物为食品，日用品。我们定价合理，物美价廉。
        "海之星"这个店名来源于"海洋之星"。
海洋之星，是蒙古帝国宫廷内四块巨型宝石之一，相传用于占卜与观天，出处不详，但来源说法之一是“长子西征”时从某斯拉夫小国掠夺而来。宝石质量通体碧蓝，大小“与玺相若”，产地传为列坦（今巴基斯坦西部诺贡迪地区）。据说蒙古帝国被朱元璋驱赶至长城以北后，在蒙古贵族迁徙过程中遗失，下落不详。有人自称曾在二战德军攻占基辅时在苏维埃国家银行的地下金库中见过海洋之星，但未得到证实。而电影泰坦尼克号中的“海洋之心”是以现实中噩运之钻“希望”为原型的。
    </p>
    <p class="regText">&nbsp;&nbsp;&nbsp;&nbsp;海之星超市
    <span class="wordText";
	      onmouseover="this.style.color='red';this.style.fontStyle='italic';this.style.fontSize='2em'"; 
	      onmouseout = "this.style.color='blue';this.style.fontStyle='normal';this.style.fontSize='1.1em';";
    >宽敞、明亮、温馨</span>，希望给周围小区的居民提供方便，简单的生活。希望给异地的游子和学生提供
    <span class="wordText";
          onmouseover="this.style.color='pink';this.style.fontStyle='oblique';this.style.fontFamily='LiSu';this.style.fontSize='2.5em'";
	      onmouseout = "this.style.color='blue';this.style.fontStyle='normal';this.style.fontSize='1.1em';";
    >宾至如归</span>的感觉。商店的老板是一位成功的企业家。他回到家乡开店，就是为了给乡亲们带来便捷。
    <span class="wordText"; 
          onmouseover="this.style.color='green';this.style.fontStyle='normal';this.style.fontFamily='YouYuan';this.style.fontSize='3em'";
	      onmouseout = "this.style.color='blue';this.style.fontStyle='normal';this.style.fontSize='1.1em';";>注册会员可享受95折优惠！</span>
        每消费10元可以获得1个积分。积分可以参与以后的活动。还在等什么呢？心动不如行动！
    </p>
    <p class="pic1" id = "id_1" onclick="toTop('id_1')"><img alt="shop picture1" src="image/shop1.png" width="500px" height="300px"/></p>
	<p class="pic2" id = "id_2" onclick="toTop('id_2')"><img alt="shop picture2" src="image/shop2.png" width="500px" height="300px"/></p>
	<p class="pic3" id = "id_3" onclick="toTop('id_3')"><img alt="shop picture3" src="image/shop3.png" width="500px" height="300px"/></p>
	<p class="pic4" id = "id_4" onclick="toTop('id_4')"><img alt="shop picture4" src="image/shop4.png" width="500px" height="300px"/></p>

    <p id="pText" style="position:absolute;top:600px;left:800px;font-size:1.2em;font-family:LiSu">海之星超市欢迎您</p>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
