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
--��Ʒ�����
create table ProductCategory  --��Ʒ����
(
	CategoryId int identity(1,1) primary key ,--��Ʒ������
	CategoryName varchar(20) not null--��Ʒ��������
)

--��Ʒ������λ��
create table ProductUnit
(
	Id int identity(1,1) primary key ,
	Unit varchar(20) not null--��Ʒ������λ
)
--��Ʒ��
create table Products
(
	ProductId varchar(50) primary key,--��Ʒ��ţ���Ʒ���룩
	ProductName varchar(50) not null, --��Ʒ����
	UnitPrice numeric(18,2) not null, --��Ʒ����
	Unit varchar(50) not null,--������λ(û�������������Ҫ�����ʱ���ж�һ��)
	Discount int,--�ۿ�
	CategoryId int  references ProductCategory (CategoryId) not null --����Ʒ���ࣩ���
)

--��Ʒ���״̬
create table InventoryStatus
(	
    StatusId int primary key,--���״̬
    StatusDesc varchar(50) not null--��1��������-1�����ڿ�棬2�����ڿ�棻-2������֣�
)
--������¼��
create table Purchase
(
	PurchaseId int identity(100000,1) primary key, --������¼��ˮ��
	ProductId varchar(50) references Products(ProductId), --��ƷID
	PurchasePrice numeric(18,2) not null, --����
	PurchaseCnt int not null check(PurchaseCnt>0), --��������
	PurchaseTotPrice numeric(18,2) not null, --�ܽ���
	PurchaseDate smalldatetime default(getdate()) not null --����ʱ��
);

--��Ʒ����
create table ProductInventory
(
	ProductId varchar(50) primary key,--��Ʒ���
    TotalCount int not null,--������
    MinCount int not null,--��С���
    MaxCount int not null,--�����
    StatusId int references InventoryStatus (StatusId) --���״̬��1��������-1�����ڿ�棬2�����ڿ�棻-2������֣�
)

--����Ա(����Ա)��
create table SalesPerson
(
	SalesPersonId int identity(10000,1) primary key,-- �Զ���ʶ
	SPName varchar(50) not null,
	LoginPwd varchar(50)  not null --����6λ  
)
--������ˮ�˱�
create table SalesList
(  
	SerialNum varchar(50) primary key not null, --��ˮ��(ϵͳ�Զ�����)
	TotalMoney numeric(10,2) not null,--�����ܼ�Ǯ
	RealReceive numeric(10,2) not null,--ʵ���տ�
	ReturnMoney  numeric(10,2) not null,--����
	SalesPersonId int references SalesPerson (SalesPersonId), --����Ա�������
	SaleDate smalldatetime  default(getdate()) not null --Ĭ�����ݿ������ʱ��
)

--������ˮ����ϸ
create table SalesListDetail
(
    Id int identity(1000000,1) primary key not  null,--�Զ���ʶ��
    SerialNum varchar(50) references SalesList (SerialNum), --��ˮ�ţ������
	ProductId varchar(50) not null, --��Ʒ��ţ�����Ҫ�����
	ProductName varchar(50) not null, --��Ʒ����
	UnitPrice numeric(10,2) not null, --��Ʒ���� 
	Discount int,--�ۿ�
	Quantity int not null,--��������	
    SubTotalMoney numeric(10,2)--С�ƽ��
)


--��Ʒ����
create table ProductStorage
(
	StorageId int identity(100000,1) primary key,--��ʶ��
	ProductId varchar(50) references Products (ProductId),--�������Ʒ���
	AddedCount int not null,--�������
	CurrentTime smalldatetime default(getdate())  not null --Ĭ�����ݿ������ʱ��
)
--�˻���
use supermarketDB;
drop table if exists ReturnProduct;
create table ReturnProduct
(
	ReturnProductId int identity(10000,1) primary key,
	SerialNum varchar(50) references SalesList(SerialNum), --������ˮ��
	ProductId varchar(50) references Products(ProductId), --��Ʒ���
	rcnt int not null, --�˻�����
	rMoney numeric(10,2),--�˻����
	rDate smalldatetime default(getdate()) not null
);

--��¼��־��
create table LoginLogs
(
    LogId int identity(1,1) primary key, --��¼��ˮ��
	LoginId  int not null,
	SPName varchar(50),--��¼��Ա�����������ǹ���Ա��¼����������Ա��¼
	ServerName varchar(100),--��¼�ķ���������
	LoginTime datetime default(getdate()) not null, --Ĭ�����ݿ������ʱ��  ��¼ʱ��
	ExitTime datetime --�˳�ʱ��
)

--���л�Ա��
create table SMMembers
(
	MemberId int identity(100200300,1) primary key,--��Ա����
	MemberName varchar(50) not null,--��Ա����	
	Points int default(0) not null,--��Ա���֣�����10Ԫ�����1�����֣�
	PhoneNumber varchar(200) not null,--��ϵ�绰
	MemberAddress text not null,--��ϵ��ַ
	OpenTime datetime default(getdate()),--����ʱ��
	MemberStatus int default(1) not null--��Ա��״̬��1������ʹ�ã�0�����᣻-1��ע����
)
--����Ա��
create table SysAdmins
(
	LoginId int identity(2000,1) primary key,--��¼�˺�
	LoginPwd varchar(20),--��¼����
	AdminName varchar(20),--����Ա����
	AdminStatus bit, --��ǰ״̬��1�����ã�0�����ã�
	RoleId int --��ɫ��ţ�1����������Ա��2��һ�����Ա��
)

--��Ӽ�������
if exists(select * from sysobjects where name='fk_ProductId_PI')
alter table ProductInventory drop constraint fk_ProductId_PI

alter table ProductInventory add constraint fk_ProductId_PI foreign key (ProductId) references Products (ProductId) on update cascade

--�����ƷdiscountĬ��ֵ
if exists(select * from sysobjects where name='df_ProductDiscountDefault')
alter table Products drop constraint df_ProductDiscountDefault

alter table Products add constraint df_ProductDiscountDefault default(1.0) for Discount

--�����ƷStatusĬ��ֵ
if exists(select * from sysobjects where name='df_ProductStatusDefault')
alter table Products drop constraint df_ProductStatusDefault

create table ErrorLogs --������־��
(
	ErrorId int identity(1,1) primary key,
	OccurTime datetime default(getdate()),
	ServerName varchar(50) default('��¼ʧ��'),--������Ϊ�����¼����ֹ����򱨳�����Ӱ���û�����
	LoginId int,
	ErrorDesc text default('δ֪����')
);
--drop view if exists view_product_storage;
go
create view view_product_storage as
select tb1.ProductId as '��Ʒ���',ProductName as '����',UnitPrice as '����',Unit as '������λ',TotalCount as '�����',Discount as '�ۿ�'
from Products as tb1,ProductInventory as tb2
where tb1.ProductId=tb2.ProductId;

--select * from view_product_storage;
go
create view view_low_product_storage as
select tb1.ProductId as '��Ʒ���',ProductName as '����',UnitPrice as '����',Unit as '������λ',TotalCount as '�����',MinCount as '���ٿ����',MaxCount as '�������'
from Products as tb1,ProductInventory as tb2
where tb1.ProductId=tb2.ProductId and TotalCount < MinCount;

go
create view view_high_product_storage as
select tb1.ProductId as '��Ʒ���',ProductName as '����',UnitPrice as '����',Unit as '������λ',TotalCount as '�����',MinCount as '���ٿ����',MaxCount as '�������'
from Products as tb1,ProductInventory as tb2
where tb1.ProductId=tb2.ProductId and TotalCount > MaxCount;


-- ��ӹ���СƱ��ϸ�󣬸��¿�棬������Ӧ����Ŀ������
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

--���������Ϣ��ʱ��ͬʱ���������Ϣ
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

--���������ʱ��ͬʱ���¿����
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
--�������������µ���Ʒ֮��������в���һ������Ʒ�����Ϊ0�ļ�¼
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
--�����������ı��ʱ�򣬸��¿��״̬��-1���٣�2���࣬1����
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
--һ���洢���̡�ע�������й��ڵĻ�Ա�˺�
drop proc if exists proc_del_overdul_member;
go
create proc	proc_del_overdul_member as
	delete from SMMembers where DATEDIFF(day,OpenTime,getDate())>365;

