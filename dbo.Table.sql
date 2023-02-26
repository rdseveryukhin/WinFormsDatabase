CREATE TABLE [dbo].[Members] (
    [member_id]  INT             IDENTITY (1, 1) NOT NULL,
    [last_name]  VARCHAR (20)    NULL,
    [first_name] VARCHAR (20)    NULL,
    [age]        INT             NULL,
    [city]       VARCHAR (20)    NULL,
    [occupation] VARCHAR (20)    NULL,
    [salary]     INT             NULL,
    PRIMARY KEY CLUSTERED ([member_id] ASC)
);

