CREATE TABLE [dbo].[rolesPersons_db] (
    [roles_persons] INT           IDENTITY (1, 1) NOT NULL,
    [other_auth]    NVARCHAR (25) NULL,
    [role]          NVARCHAR (25) NULL
);
