SELECT
substring (a.name,0,20) as [���ݿ���],
[������] = (SELECT COUNT(*)
FROM master..sysprocesses b
WHERE
a.dbid = b.dbid),
[��������] = (SELECT COUNT(*)
FROM master..sysprocesses b
WHERE
a.dbid = b.dbid AND
blocked <> 0),
[���ڴ�] = ISNULL((SELECT SUM(memusage)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0),
[��IO] = ISNULL((SELECT SUM(physical_io)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0),
[��CPU] = ISNULL((SELECT SUM(cpu)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0),
[�ܵȴ�ʱ��] = ISNULL((SELECT SUM(waittime)
FROM
master..sysprocesses b
WHERE
a.dbid = b.dbid),0)
FROM master.dbo.sysdatabases a WITH (nolock)
WHERE 
DatabasePropertyEx(a.name,'Status') = 'ONLINE'
ORDER BY [���ݿ���]
;


--��ѯ����ִ�е����
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
--���������
select * from sys.sysprocesses  where dbid=DB_ID('dbname')



--��ѯ�����
select t1.resource_type                                [��Դ��������]
     , DB_NAME(resource_database_id)                as ���ݿ���
     , t1.resource_associated_entity_id                ��������
     , t1.request_mode                              as �ȴ������������ģʽ
     , t1.request_session_id                           �ȴ���SID
     , t2.wait_duration_ms                             �ȴ�ʱ��
     , (select TEXT
        from sys.dm_exec_requests r
               cross apply
             sys.dm_exec_sql_text(r.sql_handle)
        where r.session_id = t1.request_session_id) as �ȴ���Ҫִ�е�SQL
     , t2.blocking_session_id                          [������SID]
     , (select TEXT
        from sys.sysprocesses p
               cross apply
             sys.dm_exec_sql_text(p.sql_handle)
        where p.spid = t2.blocking_session_id
)                                                      ������ִ�����
from sys.dm_tran_locks t1,
     sys.dm_os_waiting_tasks t2
where t1.lock_owner_address = t2.resource_address

----��ע��ɨ���ܶ� [��Ѽ���:ʵ�ʼ���]�� �߼�ɨ����Ƭ
----���㷢�֣�ɨ���ܶ��У���Ѽ�����ʵ�ʼ����ı����Ѿ�����ʧ�����߼�ɨ����Ƭռ�˷ǳ���İٷֱȣ�ÿҳƽ
----�������ֽ����ǳ���ʱ����˵�����������Ҫ��������һ����
DBCC showcontig('tablename')

 
----Ȼ��ִ�У�--�ؽ�����
DBCC DBREINDEX('tablename') 

----���������
select   request_session_id   spid,OBJECT_NAME(resource_associated_entity_id) tableName   
from   sys.dm_tran_locks where resource_type='OBJECT'
----kill 
DECLARE @spid  int 
Set @spid  = 63 --�������
declare @sql varchar(1000)
set @sql='kill '+cast(@spid  as varchar)
exec(@sql)
----======================================================
----���������
select * from sys.sysprocesses  where dbid=DB_ID('dbname')

