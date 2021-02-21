ASP.NET 项目。
开发工具为 Microsotf Visual Studio Community 2017 
版本 15.9.29


数据库SQL Sever版本号为:Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64)   Sep 24 2019 13:48:23   Copyright (C) 2019 Microsoft Corporation  Developer Edition (64-bit) on Windows 10 Home China 10.0 <X64> (Build 18363: ) 
数据库使用的是Windows用户验证。
数据库名称为：supermarketDB
所以数据库连接字符串为:"Data Source=localhost;Initial Catalog=supermarketDB;Integrated Security=True"

管理员登录可用的账号密码有：
姓名：许智超
密码：xzc
姓名：金轶远
密码：jyy
姓名：胡家伟
密码：hjw
姓名：杨老板
密码：ylb
其中，"杨老板"为高级管理员(经理)，可以对普通管理员进行信息修改和禁用启用。

收银员登录可用的姓名有：Tom, Bob, Amy, 密码均为:123456

用户可以通过系统自己注册会员。会员密码长度不能少于6，会员预留的手机号必须合法。

收银员可以进行收银。
会员可以登录并查看自己的积分情况和会员到期时间。

管理员可以进行：进货管理，退货管理，库存管理，员工管理(收银员信息管理),销售管理。
高级管理员(经理)还可以进行:权限管理(启用或禁用其它普通管理员)