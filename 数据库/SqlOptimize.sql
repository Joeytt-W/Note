SELECT
substring (a.name,0,20) as [数据库名],
[连接数] = (SELECT COUNT(*)
FROM master..sysprocesses b
WHERE
a.dbid = b.dbid),
[阻塞进程] = (SELECT COUNT(*)
FROM master..sysprocesses b
WHERE
a.dbid = b.dbid AND
blocked <> 0),
[总内存] = ISNULL((SELECT SUM(memusage)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0),
[总IO] = ISNULL((SELECT SUM(physical_io)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0),
[总CPU] = ISNULL((SELECT SUM(cpu)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0),
[总等待时间] = ISNULL((SELECT SUM(waittime)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0)
FROM master.dbo.sysdatabases a WITH (nolock)
WHERE 
DatabasePropertyEx(a.name,'Status') = 'ONLINE'
ORDER BY [数据库名]
;


--查询正在执行的语句
SELECT   spid,
         blocked,
         DB_NAME(sp.dbid) AS DBName,
         program_name,
         waitresource,
         lastwaittype,
         sp.loginame,
         sp.hostname,
         a.[Text] AS [TextData],
         SUBSTRING(A.text, sp.stmt_start / 2,
         (CASE WHEN sp.stmt_end = -1 THEN DATALENGTH(A.text) ELSE sp.stmt_end
         END - sp.stmt_start) / 2) AS [current_cmd]
FROM     sys.sysprocesses AS sp OUTER APPLY sys.dm_exec_sql_text (sp.sql_handle) AS A
WHERE    spid > 50   


--======================================================
--查连接情况
select * from sys.sysprocesses  where dbid=DB_ID('dbname')



--查询锁语句
select t1.resource_type                                [资源锁定类型]
     , DB_NAME(resource_database_id)                as 数据库名
     , t1.resource_associated_entity_id                锁定对象
     , t1.request_mode                              as 等待者请求的锁定模式
     , t1.request_session_id                           等待者SID
     , t2.wait_duration_ms                             等待时间
     , (select TEXT
        from sys.dm_exec_requests r
               cross apply
             sys.dm_exec_sql_text(r.sql_handle)
        where r.session_id = t1.request_session_id) as 等待者要执行的SQL
     , t2.blocking_session_id                          [锁定者SID]
     , (select TEXT
        from sys.sysprocesses p
               cross apply
             sys.dm_exec_sql_text(p.sql_handle)
        where p.spid = t2.blocking_session_id
)                                                      锁定者执行语句
from sys.dm_tran_locks t1,
     sys.dm_os_waiting_tasks t2
where t1.lock_owner_address = t2.resource_address

----关注：扫描密度 [最佳计数:实际计数]， 逻辑扫描碎片
----当你发现，扫描密度行，最佳计数和实际计数的比例已经严重失调，逻辑扫描碎片占了非常大的百分比，每页平
----均可用字节数非常大时，就说明你的索引需要重新整理一下了
DBCC showcontig('tablename')

 
----然后执行，--重建索引
DBCC DBREINDEX('tablename') 

----查锁表进程
select   request_session_id   spid,OBJECT_NAME(resource_associated_entity_id) tableName   
from   sys.dm_tran_locks where resource_type='OBJECT'
----kill 
DECLARE @spid  int 
Set @spid  = 63 --锁表进程
declare @sql varchar(1000)
set @sql='kill '+cast(@spid  as varchar)
exec(@sql)
----======================================================
----查连接情况
select * from sys.sysprocesses  where dbid=DB_ID('dbname')

