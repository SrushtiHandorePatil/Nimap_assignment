select * from dbo.Categories;

drop table Categories
create  table Categories(
id int primary key identity not null,
categoryname varchar(100),
active char(1) default 'Y'
);



create table products(
id int primary key identity not null,
productname varchar(200),
categoryid int,
active char(1) default 'Y'
)

select * from products

select p.id,p.productname, p.categoryid, ct.categoryname from products p join Categories ct on p.categoryid = ct.id
select p.id,p.productname, p.categoryid, ct.categoryname from products p join Categories ct on p.categoryid = ct.id where ct.active='Y' and p.active='Y'
