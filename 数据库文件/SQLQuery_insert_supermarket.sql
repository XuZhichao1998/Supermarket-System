use supermarketDB;
go
--管理员信息
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('xzc','许智超',1,2);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('hjw','胡家伟',1,2);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('jyy','金轶远',1,2);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('ylb','杨老板',1,1);
insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('zsf','张三风',0,2);


--收银员信息
insert into  SalesPerson(SPName,LoginPwd) values('Bob','123456');
insert into  SalesPerson(SPName,LoginPwd) values('Tom','123456');
insert into  SalesPerson(SPName,LoginPwd) values('Amy','123456');
select * from SalesPerson;
--超市会员信息---MemberId实际开发中不使用标识列而是使用刷卡录入卡号
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('郭靖',default,'173-6299-2401','襄阳',default,default);
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('黄蓉',default,'173-6299-2409','桃花岛',default,default);
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('杨过',default,'173-6299-2475','襄阳',default,default);
insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus)
values('小龙女',default,'173-6299-2551','终南山',default,default);

--商品类别
insert into ProductCategory(CategoryName) values('饮料')--1
insert into ProductCategory(CategoryName) values('副食')--2
insert into ProductCategory(CategoryName) values('面食')--3
insert into ProductCategory(CategoryName) values('肉类')--4
insert into ProductCategory(CategoryName) values('米类')--5
insert into ProductCategory(CategoryName) values('酒类')--6
insert into ProductCategory(CategoryName) values('烟类')--7
insert into ProductCategory(CategoryName) values('文具')--8
insert into ProductCategory(CategoryName) values('玩具')--9
insert into ProductCategory(CategoryName) values('日用品')--10


--商品计量单位
insert into ProductUnit values('箱')
insert into ProductUnit values('瓶')
insert into ProductUnit values('盒')
insert into ProductUnit values('本')
insert into ProductUnit values('袋')
insert into ProductUnit values('只')
insert into ProductUnit values('条')
insert into ProductUnit values('桶')
insert into ProductUnit values('打')
insert into ProductUnit values('听')
insert into ProductUnit values('罐')
insert into ProductUnit values('张')
insert into ProductUnit values('块')
insert into ProductUnit values('床')
insert into ProductUnit values('把')
insert into ProductUnit values('台')
insert into ProductUnit values('个')

--商品信息
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003001','康师傅牛肉面',40.00,'箱',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003002','康师傅打卤面',35.00,'箱',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003003','康师傅三鲜面',38.00,'箱',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003004','统一牛肉面',36.00,'箱',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003005','统一酸菜面',42.00,'箱',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003006','雪花啤酒',60.50,'箱',10,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003007','燕京啤酒',60.00,'箱',10,6)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003008','可口可乐',6.80,'瓶',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003009','百事可乐',5.80,'瓶',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003010','统一鲜橙多',5.80,'瓶',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003011','茉莉花茶',3.50,'瓶',10,1)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003012','自制蛋糕',19.80,'盒',10,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003013','中型碳素笔',10.00,'盒',10,9)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003014','云南白药牙膏',6.80,'盒',10,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003015','东北大米',80.00,'袋',10,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003016','武昌大米',100.00,'袋',10,5)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003017','高精面粉',68.50,'袋',10,3)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003018','大豆油',68.80,'桶',10,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003019','纯棉毛巾',8.80,'条',10,10)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003020','金龙鱼食用油',55.80,'桶',10,2)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003021','鲈鱼',39.90,'条',10,4)
insert into Products (ProductId,ProductName,UnitPrice,Unit,Discount,categoryId)
values('6005004003022','草鱼',35.90,'条',10,4)

--商品库存状态
insert into InventoryStatus(StatusId,StatusDesc)values(1,'正常')
insert into InventoryStatus(StatusId,StatusDesc)values(-1,'低于库存')
insert into InventoryStatus(StatusId,StatusDesc)values(2,'高于库存')
insert into InventoryStatus(StatusId,StatusDesc)values(-2,'已清仓')

--商品库存数据
--select * from view_product_storage;
update ProductInventory set TotalCount=190,MinCount=200,MaxCount=500,StatusId=1 where ProductId='6005004003001';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003001',190,200,500,1);--方便面
update ProductInventory set TotalCount=350,MinCount=200,MaxCount=500,StatusId=1 where ProductId='6005004003002';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003002',350,200,500,1);--方便面
update ProductInventory set TotalCount=230,MinCount=200,MaxCount=500,StatusId=1 where ProductId='6005004003003';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003003',230,200,500,1);--方便面
update ProductInventory set TotalCount=300,MinCount=200,MaxCount=400,StatusId=1 where ProductId='6005004003004';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003004',300,200,400,1);--方便面
update ProductInventory set TotalCount=190,MinCount=100,MaxCount=300,StatusId=1 where ProductId='6005004003005';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003005',190,100,300,1);--方便面
update ProductInventory set TotalCount=1000,MinCount=200,MaxCount=500,StatusId=2 where ProductId='6005004003006';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003006',1000,200,500,1);--啤酒
update ProductInventory set TotalCount=1000,MinCount=200,MaxCount=300,StatusId=2 where ProductId='6005004003007';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003007',1000,200,300,1);--啤酒
update ProductInventory set TotalCount=180,MinCount=200,MaxCount=300,StatusId=-1 where ProductId='6005004003008';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003008',180,200,300,1);--饮料
update ProductInventory set TotalCount=210,MinCount=200,MaxCount=300,StatusId=1 where ProductId='6005004003009';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003009',210,200,300,1);--饮料
update ProductInventory set TotalCount=150,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003010';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003010',150,100,200,1);--饮料
update ProductInventory set TotalCount=150,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003011';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003011',150,100,200,1);--饮料
update ProductInventory set TotalCount=200,MinCount=100,MaxCount=150,StatusId=2 where ProductId='6005004003012';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003012',200,100,150,2);--盒
update ProductInventory set TotalCount=80,MinCount=100,MaxCount=150,StatusId=-1 where ProductId='6005004003013';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003013',80,100,150,-1);--盒
update ProductInventory set TotalCount=50,MinCount=100,MaxCount=150,StatusId=-1 where ProductId='6005004003014';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003014',50,100,150,-1);--盒
update ProductInventory set TotalCount=180,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003015';
insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003015',180,100,200,1);--袋
update ProductInventory set TotalCount=160,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003016';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003016',160,100,200,1);--袋
update ProductInventory set TotalCount=1000,MinCount=100,MaxCount=200,StatusId=2 where ProductId='6005004003017';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003017',1000,100,200,2);--袋
update ProductInventory set TotalCount=230,MinCount=100,MaxCount=200,StatusId=2 where ProductId='6005004003018';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003018',230,100,200,2);--桶
update ProductInventory set TotalCount=150,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003019';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003019',150,100,200,1);--条
update ProductInventory set TotalCount=120,MinCount=100,MaxCount=200,StatusId=1 where ProductId='6005004003020';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003020',120,100,200,1);--桶
update ProductInventory set TotalCount=30,MinCount=10,MaxCount=100,StatusId=1 where ProductId='6005004003021';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003021',30,10,100,1);--条
update ProductInventory set TotalCount=30,MinCount=10,MaxCount=100,StatusId=1 where ProductId='6005004003022';
--insert into ProductInventory(ProductId,TotalCount,MinCount,MaxCount,StatusId) values('6005004003022',30,10,100,1);--条



