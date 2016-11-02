

CREATE TABLE [up927_f].[t_admin] (
    [id] integer IDENTITY (1,1) not null,
   [name] nvarchar(100) not null default('') ,
   [pwd] nvarchar(200) not null default('') ,
   [remark] nvarchar(200) not null default('') 
  ) ON [Primary]
 go

--[t_article]:

CREATE TABLE [up927_f].[t_article] (
   [id] integer IDENTITY (1,1) not null,
   [id_show] nvarchar(100) not null default('') ,
   [title] nvarchar(255) not null default('') ,
   [title1] nvarchar(255) not null default('') ,
   [source] nvarchar(100) not null default('') ,
   [keyword] nvarchar(255) not null default('') ,
   [daoyu] text not null default('') ,
   [content] text not null default('') ,
   [type] integer Default (0) not null ,
   [update_date] datetime not null default(getdate()) ,
   [declare_mark] integer Default (1) not null ,
   [pic] nvarchar(500) not null default('') ,
   [html] nvarchar(500) not null default('') ,
   [remark] nvarchar(500) not null default('') ,
   [huandeng1] integer Default (0) not null ,
   [huandeng1_pic] nvarchar(500) not null default('') ,
   [is_finish] integer Default (0) not null ,
   [tag] nvarchar(500) not null default('') ,
   [tag_id] nvarchar(100) not null default('') ,
   [right_type] integer Default (0) not null ,
   [ts_baidu] integer Default (0) not null ,
   [last_id] integer Default (0) not null ,
   [next_id] integer Default (0) not null 
  ) ON [Primary]
 go

--[t_article_pic]:

CREATE TABLE [up927_f].[t_article_pic] (
    [id] integer IDENTITY (1,1) not null,
   [article_id] integer Default (0) not null ,
   [pic] nvarchar(500) not null default('') ,
   [update_date] datetime not null default(getdate()) ,
   [remark] nvarchar(500) not null default('')
  ) ON [Primary]
 go

--[t_article_type]:

CREATE TABLE [up927_f].[t_article_type] (
    [id] integer IDENTITY (1,1) not null,
   [type_name] nvarchar(50) not null default('') ,
   [type_keyword] nvarchar(100) not null default('') ,
   [remark] nvarchar(100) not null default('')
  ) ON [Primary]
 go

--[t_friendlink]:

CREATE TABLE [up927_f].[t_friendlink] (
   [id] integer IDENTITY (1,1) not null,
   [link_name] nvarchar(100) not null default('') ,
   [link] nvarchar(200) not null default('') ,
   [link_order] integer Default (0) not null ,
   [update_date] datetime not null default(getdate())  
  ) ON [Primary]
 go

--[t_tag]:

CREATE TABLE [up927_f].[t_tag] (
   [id] integer IDENTITY (1,1) not null,
   [tag_name] nvarchar(50) not null default('') ,
   [article_num] integer Default (0) not null ,
   [remark] nvarchar(50) not null default('')
  ) ON [Primary]
 go

--[t_admin]:

 Alter TABLE [up927_f].[t_admin] WITH NOCHECK ADD CONSTRAINT [PK_t_admin] Primary Key Clustered ([id] )  ON [Primary] 
 go
CREATE INDEX [id] on [up927_f].[t_admin]([id] ) ON [Primary]
 go

--[t_article]:

 Alter TABLE [up927_f].[t_article] WITH NOCHECK ADD CONSTRAINT [PK_t_article] Primary Key Clustered ([id] )  ON [Primary] 
 go
CREATE INDEX [id] on [up927_f].[t_article]([id] ) ON [Primary]
 go
CREATE INDEX [id_show] on [up927_f].[t_article]([id_show] ) ON [Primary]
 go
CREATE INDEX [keyword] on [up927_f].[t_article]([keyword] ) ON [Primary]
 go
CREATE INDEX [last_id] on [up927_f].[t_article]([last_id] ) ON [Primary]
 go
CREATE INDEX [next_id] on [up927_f].[t_article]([next_id] ) ON [Primary]
 go
CREATE INDEX [tag_id] on [up927_f].[t_article]([tag_id] ) ON [Primary]
 go

--[t_article_pic]:

 Alter TABLE [up927_f].[t_article_pic] WITH NOCHECK ADD CONSTRAINT [PK_t_article_pic] Primary Key Clustered ([id] )  ON [Primary] 
 go
CREATE INDEX [article_id] on [up927_f].[t_article_pic]([article_id] ) ON [Primary]
 go
CREATE INDEX [id] on [up927_f].[t_article_pic]([id] ) ON [Primary]
 go

--[t_article_type]:

 Alter TABLE [up927_f].[t_article_type] WITH NOCHECK ADD CONSTRAINT [PK_t_article_type] Primary Key Clustered ([id] )  ON [Primary] 
 go
CREATE INDEX [id] on [up927_f].[t_article_type]([id] ) ON [Primary]
 go

--[t_friendlink]:

 Alter TABLE [up927_f].[t_friendlink] WITH NOCHECK ADD CONSTRAINT [PK_t_friendlink] Primary Key Clustered ([id] )  ON [Primary] 
 go
CREATE INDEX [id] on [up927_f].[t_friendlink]([id] ) ON [Primary]
 go

--[t_tag]:

 Alter TABLE [up927_f].[t_tag] WITH NOCHECK ADD CONSTRAINT [PK_t_tag] Primary Key Clustered ([id] )  ON [Primary] 
 go
CREATE INDEX [article_num] on [up927_f].[t_tag]([article_num] ) ON [Primary]
 go
CREATE INDEX [id] on [up927_f].[t_tag]([id] ) ON [Primary]
 go

--[t_admin]:
SET IDENTITY_INSERT [up927_f].[t_admin] ON
 go 

INSERT INTO [up927_f].[t_admin] ([id],[name],[pwd],[remark]) 
 SELECT [id],[name],[pwd],[remark] 
 FROM OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0','Data Source="D:\MyProject\MyProject02\MyProject02\acc\db1.mdb"')...[t_admin]
 go 

SET IDENTITY_INSERT [up927_f].[t_admin] Off
 go 


--[t_article]:
SET IDENTITY_INSERT [up927_f].[t_article] ON
 go 

INSERT INTO [up927_f].[t_article] ([id],[id_show],[title],[title1],[source],[keyword],[daoyu],[content],[type],[update_date],[declare_mark],[pic],[html],[remark],[huandeng1],[huandeng1_pic],[is_finish],[tag],[tag_id],[right_type],[ts_baidu],[last_id],[next_id]) 
 SELECT [id],[id_show],[title],[title1],[source],[keyword],[daoyu],[content],[type],[update_date],[declare_mark],[pic],[html],[remark],[huandeng1],[huandeng1_pic],[is_finish],[tag],[tag_id],[right_type],[ts_baidu],[last_id],[next_id] 
 FROM OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0','Data Source="D:\MyProject\MyProject02\MyProject02\acc\db1.mdb"')...[t_article]
 go 

SET IDENTITY_INSERT [up927_f].[t_article] Off
 go 


--[t_article_pic]:
SET IDENTITY_INSERT [up927_f].[t_article_pic] ON
 go 

INSERT INTO [up927_f].[t_article_pic] ([id],[article_id],[pic],[update_date],[remark]) 
 SELECT [id],[article_id],[pic],[update_date],[remark] 
 FROM OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0','Data Source="D:\MyProject\MyProject02\MyProject02\acc\db1.mdb"')...[t_article_pic]
 go 

SET IDENTITY_INSERT [up927_f].[t_article_pic] Off
 go 


--[t_article_type]:
SET IDENTITY_INSERT [up927_f].[t_article_type] ON
 go 

INSERT INTO [up927_f].[t_article_type] ([id],[type_name],[type_keyword],[remark]) 
 SELECT [id],[type_name],[type_keyword],[remark] 
 FROM OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0','Data Source="D:\MyProject\MyProject02\MyProject02\acc\db1.mdb"')...[t_article_type]
 go 

SET IDENTITY_INSERT [up927_f].[t_article_type] Off
 go 


--[t_friendlink]:
SET IDENTITY_INSERT [up927_f].[t_friendlink] ON
 go 

INSERT INTO [up927_f].[t_friendlink] ([id],[link_name],[link],[link_order],[update_date]) 
 SELECT [id],[link_name],[link],[link_order],[update_date] 
 FROM OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0','Data Source="D:\MyProject\MyProject02\MyProject02\acc\db1.mdb"')...[t_friendlink]
 go 

SET IDENTITY_INSERT [up927_f].[t_friendlink] Off
 go 


--[t_tag]:
SET IDENTITY_INSERT [up927_f].[t_tag] ON
 go 

INSERT INTO [up927_f].[t_tag] ([id],[tag_name],[article_num],[remark]) 
 SELECT [id],[tag_name],[article_num],[remark] 
 FROM OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0','Data Source="D:\MyProject\MyProject02\MyProject02\acc\db1.mdb"')...[t_tag]
 go 

SET IDENTITY_INSERT [up927_f].[t_tag] Off
 go 




--=========================================================================
--Access To SQL 数据库升迁脚本 by MiniAccess Edit V1.0 P2(V37 PaintBlue.Net 2004)
--=========================================================================


--连接字串:CONNstr="Provider=SQLOLEDB.1;Persist Security InFso=true;Data Source='(local)';Initial Catalog='up927';User ID='up927';Password='liu831120';CONNect Timeout=30"

