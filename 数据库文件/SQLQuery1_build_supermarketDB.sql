use supermarketDB;
drop trigger if exists trig_UpdatePInventoryAfterChanged;
drop trigger if exists trig_InsertPInventoryAfterInsertProducts;
drop trigger if exists trig_AddProcntAfterInsertStro;
drop trigger if exists trig_insertStorAfterInsertPurchase;
drop trigger if exists tirg_updStorageAfterInsertSaleListDetail;
drop view if exists view_product_storage;
drop view if exists view_low_product_storage;
drop view if exists view_high_product_storage;
drop table if exists ErrorLogs;
drop table if exists SysAdmins;
drop table if exists SMMembers;
drop table if exists LoginLogs;
drop table if exists ReturnProduct;
drop table if exists ProductStorage;
drop table if exists SalesListDetail;
drop table if exists SalesList;
drop table if exists SalesPerson;
drop table if exists ProductInventory;
drop table if exists PurchaseCnt;
drop table if exists InventoryStatus;
drop table if exists Products;
drop table if exists ProductUnit;
drop table if exists ProductCategory;
--商品分类表
create table ProductCategory  --商品类别表
(
	CategoryId int identity(1,1) primary key ,--商品分类编号
	CategoryName varchar(20) not null--商品分类名称
)

--商品计量单位表
create table ProductUnit
(
	Id int identity(1,1) primary key ,
	Unit varchar(20) not null--商品计量单位
)
--商品表
create table Products
(
	ProductId varchar(50) primary key,--商品编号（商品条码）
	ProductName varchar(50) not null, --商品名称
	UnitPrice numeric(18,2) not null, --商品单价
	Unit varchar(50) not null,--计量单位(没有设置外键，需要插入的时候判断一下)
	Discount int,--折扣
	CategoryId int  references ProductCategory (CategoryId) not null --（商品分类）外键
)

--商品库存状态
create table InventoryStatus
(	
    StatusId int primary key,--库存状态
    StatusDesc varchar(50) not null--（1：正常，-1：低于库存，2：高于库存；-2：已清仓）
)
--进货记录表
create table Purchase
(
	PurchaseId int identity(100000,1) primary key, --进货记录流水号
	ProductId varchar(50) references Products(ProductId), --商品ID
	PurchasePrice numeric(18,2) not null, --进价
	PurchaseCnt int not null check(PurchaseCnt>0), --进货数量
	PurchaseTotPrice numeric(18,2) not null, --总进价
	PurchaseDate smalldatetime default(getdate()) not null --进货时间
);

--商品库存表
create table ProductInventory
(
	ProductId varchar(50) primary key,--商品编号
    TotalCount int not null,--总数量
    MinCount int not null,--最小库存
    MaxCount int not null,--最大库存
    StatusId int references InventoryStatus (StatusId) --库存状态（1：正常，-1：低于库存，2：高于库存；-2：已清仓）
)

--销售员(收银员)表
create table SalesPerson
(
	SalesPersonId int identity(10000,1) primary key,-- 自动标识
	SPName varchar(50) not null,
	LoginPwd varchar(50)  not null --最少6位  
)
--销售流水账表
create table SalesList
(  
	SerialNum varchar(50) primary key not null, --流水号(系统自动生成)
	TotalMoney numeric(10,2) not null,--购物总价钱
	RealReceive numeric(10,2) not null,--实际收款
	ReturnMoney  numeric(10,2) not null,--找零
	SalesPersonId int references SalesPerson (SalesPersonId), --销售员（外键）
	SaleDate smalldatetime  default(getdate()) not null --默认数据库服务器时间
)

--销售流水账明细
create table SalesListDetail
(
    Id int identity(1000000,1) primary key not  null,--自动标识列
    SerialNum varchar(50) references SalesList (SerialNum), --流水号（外键）
	ProductId varchar(50) not null, --商品编号（不需要外键）
	ProductName varchar(50) not null, --商品名称
	UnitPrice numeric(10,2) not null, --商品单价 
	Discount int,--折扣
	Quantity int not null,--销售数量	
    SubTotalMoney numeric(10,2)--小计金额
)


--商品入库表
create table ProductStorage
(
	StorageId int identity(100000,1) primary key,--标识列
	ProductId varchar(50) references Products (ProductId),--外键：商品编号
	AddedCount int not null,--入库数量
	CurrentTime smalldatetime default(getdate())  not null --默认数据库服务器时间
)
--退货表
use supermarketDB;
drop table if exists ReturnProduct;
create table ReturnProduct
(
	ReturnProductId int identity(10000,1) primary key,
	SerialNum varchar(50) references SalesList(SerialNum), --交易流水号
	ProductId varchar(50) references Products(ProductId), --商品编号
	rcnt int not null, --退货数量
	rMoney numeric(10,2),--退货金额
	rDate smalldatetime default(getdate()) not null
);

--登录日志表
create table LoginLogs
(
    LogId int identity(1,1) primary key, --登录流水号
	LoginId  int not null,
	SPName varchar(50),--登录人员姓名，可能是管理员登录或者是销售员登录
	ServerName varchar(100),--登录的服务器名称
	LoginTime datetime default(getdate()) not null, --默认数据库服务器时间  登录时刻
	ExitTime datetime --退出时间
)

--超市会员表
create table SMMembers
(
	MemberId int identity(100200300,1) primary key,--会员卡号
	MemberName varchar(50) not null,--会员姓名	
	Points int default(0) not null,--会员积分（消费10元，获得1个积分）
	PhoneNumber varchar(200) not null,--联系电话
	MemberAddress text not null,--联系地址
	OpenTime datetime default(getdate()),--开户时间
	MemberStatus int default(1) not null--会员卡状态（1：正常使用；0：冻结；-1：注销）
)
--管理员表
create table SysAdmins
(
	LoginId int identity(2000,1) primary key,--登录账号
	LoginPwd varchar(20),--登录密码
	AdminName varchar(20),--管理员姓名
	AdminStatus bit, --当前状态（1：启用；0：禁用）
	RoleId int --角色编号（1：超级管理员；2：一般管理员）
)

--添加级联更新
if exists(select * from sysobjects where name='fk_ProductId_PI')
alter table ProductInventory drop constraint fk_ProductId_PI

alter table ProductInventory add constraint fk_ProductId_PI foreign key (ProductId) references Products (ProductId) on update cascade

--添加商品discount默认值
if exists(select * from sysobjects where name='df_ProductDiscountDefault')
alter table Products drop constraint df_ProductDiscountDefault

alter table Products add constraint df_ProductDiscountDefault default(1.0) for Discount

--添加商品Status默认值
if exists(select * from sysobjects where name='df_ProductStatusDefault')
alter table Products drop constraint df_ProductStatusDefault

create table ErrorLogs --错误日志表
(
	ErrorId int identity(1,1) primary key,
	OccurTime datetime default(getdate()),
	ServerName varchar(50) default('记录失败'),--不能因为错误记录而中止程序或报出错误，影响用户体验
	LoginId int,
	ErrorDesc text default('未知错误')
);
--drop view if exists view_product_storage;
go
create view view_product_storage as
select tb1.ProductId as '商品编号',ProductName as '名称',UnitPrice as '单价',Unit as '计量单位',TotalCount as '库存量',Discount as '折扣'
from Products as tb1,ProductInventory as tb2
where tb1.ProductId=tb2.ProductId;

--select * from view_product_storage;
go
create view view_low_product_storage as
select tb1.ProductId as '商品编号',ProductName as '名称',UnitPrice as '单价',Unit as '计量单位',TotalCount as '库存量',MinCount as '最少库存量',MaxCount as '最多库存量'
from Products as tb1,ProductInventory as tb2
where tb1.ProductId=tb2.ProductId and TotalCount < MinCount;

go
create view view_high_product_storage as
select tb1.ProductId as '商品编号',ProductName as '名称',UnitPrice as '单价',Unit as '计量单位',TotalCount as '库存量',MinCount as '最少库存量',MaxCount as '最多库存量'
from Products as tb1,ProductInventory as tb2
where tb1.ProductId=tb2.ProductId and TotalCount > MaxCount;


-- 添加购物小票明细后，更新库存，减少响应货物的库存数量
go
create trigger tirg_updStorageAfterInsertSaleListDetail on SalesListDetail after insert as
begin
	declare @Pid varchar(50),@cnt int
	set @Pid = (select ProductId from inserted)
	set @cnt = (select Quantity from inserted)
	update ProductInventory set TotalCount=TotalCount-@cnt where ProductId=@Pid;
	if @@ERROR<>0
		begin
			rollback
		end
end

--插入进货信息的时候，同时插入入库信息
go
create trigger trig_insertStorAfterInsertPurchase on Purchase after insert as
begin
	declare @pid varchar(50),@cnt int
	set @pid = (select ProductId from inserted)
	set @cnt = (select PurchaseCnt from inserted)
	insert into ProductStorage(ProductId,AddedCount,CurrentTime) values(@pid,@cnt,default)
	if @@ERROR<>0
		begin
			rollback
		end
end

--插入入库表的时候同时更新库存量
go
create trigger trig_AddProcntAfterInsertStro on ProductStorage after insert as
begin
	declare @pid varchar(50),@cnt int
	set @pid = (select ProductId from inserted)
	set @cnt = (select AddedCount from inserted)
	update ProductInventory set TotalCount=TotalCount+@cnt where ProductId=@Pid;
	if @@ERROR<>0
		begin
			rollback
		end
end

go 
--触发器：插入新的商品之后，向库存表中插入一条该商品库存量为0的记录
create trigger trig_InsertPInventoryAfterInsertProducts on Products after insert as
begin
	declare @pid varchar(50)
	set @pid = (select ProductId from inserted)
	insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values(@pid,0,50,200,-1);
	if @@ERROR<>0
		begin
			rollback
		end
end

go 
--触发器：库存改变的时候，更新库存状态：-1过少，2过多，1正常
create trigger trig_UpdatePInventoryAfterChanged on ProductInventory after update as
begin
	declare @pid varchar(50),@cnt int,@MinCnt int,@MaxCnt int,@Status int,@PreStatus int
	set @pid = (select ProductId from inserted)
	set @cnt = (select TotalCount from inserted)
	set @MinCnt = (select MinCount from inserted)
	set @MaxCnt = (select MaxCount from inserted)
	set @PreStatus = (select StatusId from inserted)
	if(@cnt < @MinCnt)
		begin
			set @Status=-1
		end
	else if(@cnt > @MaxCnt)
		begin
			set @Status=2
		end
	else
		begin
			set @Status=1
		end
	if(@Status<>@PreStatus)
		begin
			update ProductInventory set StatusId=@Status where ProductId=@pid;
		end
	if @@ERROR<>0
		begin
			rollback
		end
end


go
--一个存储过程。注销掉所有过期的会员账号
drop proc if exists proc_del_overdul_member;
go
create proc	proc_del_overdul_member as
	delete from SMMembers where DATEDIFF(day,OpenTime,getDate())>365;

