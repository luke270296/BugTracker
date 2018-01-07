CREATE TABLE [dbo].[Table]
(
	[BugID] INT NOT NULL PRIMARY KEY, 
    [TesterID] INT NOT NULL, 
    [TesterName] NCHAR(50) NOT NULL, 
    [Application] NCHAR(100) NOT NULL, 
    [ClassName] NCHAR(25) NOT NULL, 
    [LineNo] INT NOT NULL, 
    [ErrorDescription] NCHAR(150) NOT NULL, 
    [Source] NCHAR(150) NOT NULL, 
    [Status] NCHAR(15) NOT NULL
)
