use supermarketDB;
go
--����Ա��Ϣ
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('xzc','���ǳ�',1,2);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('hjw','����ΰ',1,2);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('jyy','����Զ',1,2);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('ylb','���ϰ�',1,1);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('zsf','������',0,2);


--����Ա��Ϣ
insert into  SalesPerson(SPName,LoginPwd) values('Bob','123456');
insert into  SalesPerson(SPName,LoginPwd) values('Tom','123456');
insert into  SalesPerson(SPName,LoginPwd) values('Amy','123456');
select * from SalesPerson;
--���л�Ա��Ϣ---MemberIdʵ�ʿ����в�ʹ�ñ�ʶ�ж���ʹ��ˢ��¼�뿨��
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('����',default,'173-6299-2401','����',default,default);
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('����',default,'173-6299-2409','�һ���',default,default);
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('���',default,'173-6299-2475','����',default,default);
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('С��Ů',default,'173-6299-2551','����ɽ',default,default);

--��Ʒ���
insert into ProductCategory(CategoryName) values('����')--1
insert into ProductCategory(CategoryName) values('��ʳ')--2
insert into ProductCategory(CategoryName) values('��ʳ')--3
insert into ProductCategory(CategoryName) values('����')--4
insert into ProductCategory(CategoryName) values('����')--5
insert into ProductCategory(CategoryName) values('����')--6
insert into ProductCategory(CategoryName) values('����')--7
insert into ProductCategory(CategoryName) values('�ľ�')--8
insert into ProductCategory(CategoryName) values('���')--9
insert into ProductCategory(CategoryName) values('����Ʒ')--10


--��Ʒ������λ
insert into ProductUnit values('��')
insert into ProductUnit values('ƿ')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('ֻ')
insert into ProductUnit values('��')
insert into ProductUnit values('Ͱ')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('��')
insert into ProductUnit values('̨')
insert into ProductUnit values('��')

--��Ʒ��Ϣ
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003001','��ʦ��ţ����',40.00,'��',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003002','��ʦ����±��',35.00,'��',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003003','��ʦ��������',38.00,'��',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003004','ͳһţ����',36.00,'��',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003005','ͳһ�����',42.00,'��',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003006','ѩ��ơ��',60.50,'��',10,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003007','�ྩơ��',60.00,'��',10,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003008','�ɿڿ���',6.80,'ƿ',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003009','���¿���',5.80,'ƿ',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003010','ͳһ�ʳȶ�',5.80,'ƿ',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003011','���򻨲�',3.50,'ƿ',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003012','���Ƶ���',19.80,'��',10,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003013','����̼�ر�',10.00,'��',10,9)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003014','���ϰ�ҩ����',6.80,'��',10,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003015','��������',80.00,'��',10,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003016','�������',100.00,'��',10,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003017','�߾����',68.50,'��',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003018','����',68.80,'Ͱ',10,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003019','����ë��',8.80,'��',10,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003020','������ʳ����',55.80,'Ͱ',10,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003021','����',39.90,'��',10,4)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003022','����',35.90,'��',10,4)

--��Ʒ���״̬
insert into InventoryStatus(StatusId,StatusDesc)values(1,'����')
insert into InventoryStatus(StatusId,StatusDesc)values(-1,'���ڿ��')
insert into InventoryStatus(StatusId,StatusDesc)values(2,'���ڿ��')
insert into InventoryStatus(StatusId,StatusDesc)values(-2,'�����')

--��Ʒ�������
--select * from view_product_storage;
update ProductInventory set TotalCount=190,MinCount=200,MaxCount=500,StatusId=1 where ProductId='6005004003001';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003001',190,200,500,1);--������
update ProductInventory set TotalCount=350,MinCount=200,MaxCount=500,StatusId=1 where ProductId='6005004003002';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003002',350,200,500,1);--������
update ProductInventory set TotalCount=230,MinCount=200,MaxCount=500,StatusId=1 where ProductId='6005004003003';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003003',230,200,500,1);--������
update ProductInventory set TotalCount=300,MinCount=200,MaxCount=400,StatusId=1 where ProductId='6005004003004';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003004',300,200,400,1);--������
update ProductInventory set TotalCount=190,MinCount=100,MaxCount=300,StatusId=1 where ProductId='6005004003005';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003005',190,100,300,1);--������
update ProductInventory set TotalCount=1000,MinCount=200,MaxCount=500,StatusId=2 where ProductId='6005004003006';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003006',1000,200,500,1);--ơ��
update ProductInventory set TotalCount=1000,MinCount=200,MaxCount=300,StatusId=2 where ProductId='6005004003007';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003007',1000,200,300,1);--ơ��
update ProductInventory set TotalCount=180,MinCount=200,MaxCount=300,StatusId=-1 where ProductId='6005004003008';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003008',180,200,300,1);--����
update ProductInventory set TotalCount=210,MinCount=200,MaxCount=300,StatusId=1 where ProductId='6005004003009';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003009',210,200,300,1);--����
update ProductInventory set TotalCount=150,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003010';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003010',150,100,200,1);--����
update ProductInventory set TotalCount=150,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003011';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003011',150,100,200,1);--����
update ProductInventory set TotalCount=200,MinCount=100,MaxCount=150,StatusId=2 where ProductId='6005004003012';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003012',200,100,150,2);--��
update ProductInventory set TotalCount=80,MinCount=100,MaxCount=150,StatusId=-1 where ProductId='6005004003013';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003013',80,100,150,-1);--��
update ProductInventory set TotalCount=50,MinCount=100,MaxCount=150,StatusId=-1 where ProductId='6005004003014';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003014',50,100,150,-1);--��
update ProductInventory set TotalCount=180,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003015';
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003015',180,100,200,1);--��
update ProductInventory set TotalCount=160,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003016';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003016',160,100,200,1);--��
update ProductInventory set TotalCount=1000,MinCount=100,MaxCount=200,StatusId=2 where ProductId='6005004003017';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003017',1000,100,200,2);--��
update ProductInventory set TotalCount=230,MinCount=100,MaxCount=200,StatusId=2 where ProductId='6005004003018';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003018',230,100,200,2);--Ͱ
update ProductInventory set TotalCount=150,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003019';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003019',150,100,200,1);--��
update ProductInventory set TotalCount=120,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003020';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003020',120,100,200,1);--Ͱ
update ProductInventory set TotalCount=30,MinCount=10,MaxCount=100,StatusId=1 where ProductId='6005004003021';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003021',30,10,100,1);--��
update ProductInventory set TotalCount=30,MinCount=10,MaxCount=100,StatusId=1 where ProductId='6005004003022';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003022',30,10,100,1);--��



