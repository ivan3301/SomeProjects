CREATE TABLE [dbo].[indexShelf_db] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [index_shelf]    NVARCHAR (15)  NULL,
    [copyright_sign] NVARCHAR (15)  NULL,
    [sigla]          NVARCHAR (25)  NULL,
    [registration]   NVARCHAR (50)  NULL,
    [type]           NVARCHAR (25)  NULL,
    [publ_type]      NVARCHAR (25)  NULL,
    [num_copies]     INT            NULL,
    [num1]           NVARCHAR (25)  NULL,
    [num2]           NVARCHAR (25)  NULL,
    [inv_num]        NVARCHAR (MAX) NULL,
    [reg_num]        NVARCHAR (25)  NULL,
    [price]          FLOAT (53)     NULL
);
