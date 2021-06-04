## 主键

```sql
--删除主键
alter table 表名 drop constraint 主键名

--添加主键
alter table 表名 add constraint 主键名 primary key(字段名1,字段名2……)

--添加非聚集索引的主键
alter table 表名 add constraint 主键名 primary key NONCLUSTERED(字段名1,字段名2……)
```

## 字段

```sql
--新增字段： 
ALTER TABLE [表名] ADD [字段名] NVARCHAR (50) NULL

--删除字段： 
ALTER TABLE [表名] DROP COLUMN [字段名]

--修改字段： 
ALTER TABLE [表名] ALTER COLUMN [字段名] NVARCHAR (50) NULL
```

## 表

```sql
--判断表的存在: 
select * from sysobjects where id = object_id(N\'[dbo].[tablename]\') and OBJECTPROPERTY(id, N\'IsUserTable\') = 1

--某个表的结构:                                            
select * from syscolumns where id = object_id(N\'[dbo].[你的表名]\') and OBJECTPROPERTY(id, N\'IsUserTable\') = 1
```