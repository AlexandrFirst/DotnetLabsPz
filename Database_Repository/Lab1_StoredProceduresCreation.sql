USE [Lab1DB]
GO
/****** Object:  StoredProcedure [dbo].[get]    Script Date: 28.10.2021 1:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[get] (@entityIdentifier as INT, @tableName AS NVARCHAR(20))
AS
IF @tableName = 'Workers'
BEGIN
	SELECT * FROM Workers
	WHERE WorkerId = @entityIdentifier
END;
ELSE IF @tableName = 'Owners'
BEGIN
	SELECT * FROM Owners
	WHERE OwnerId = @entityIdentifier
END;
ELSE IF @tableName = 'Finders'
BEGIN
	SELECT * FROM Finders
	WHERE FinderId = @entityIdentifier
END;
ELSE IF @tableName = 'Findings'
BEGIN
	SELECT * FROM Findings
	WHERE FindingId = @entityIdentifier
END;
ELSE IF @tableName = 'Keywords'
BEGIN
	SELECT * FROM Keywords
	WHERE KeywordId = @entityIdentifier
END;



USE [Lab1DB]
GO
/****** Object:  StoredProcedure [dbo].[getActionByDate]    Script Date: 28.10.2021 1:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[getActionByDate]
(
@year AS VARCHAR(4) = NULL,
@month AS VARCHAR(2) = NULL,
@day AS VARCHAR(2) = NULL,
@tableName AS NVARCHAR(20)
)
AS
BEGIN
DECLARE @REGEX AS NVARCHAR(30) = '%';
IF @year IS NOT NULL
	BEGIN
		SET @REGEX += @year + '-';
	END
ELSE
	BEGIN
		SET @REGEX += '[0-9][0-9][0-9][0-9]-'
	END
IF @month IS NOT NULL
	BEGIN
		SET @REGEX += @month + '-'
	END
ELSE
	BEGIN
		SET @REGEX += '[0-9][0-9]-'
	END
IF @day IS NOT NULL
	BEGIN
		SET @REGEX += @day
	END
ELSE
	BEGIN
		SET @REGEX += '[0-9][0-9]'
	END
IF @tableName = 'Obtainings'
	BEGIN
		SELECT * FROM Obtainings 
		WHERE ActTime LIKE @REGEX
	END
	ELSE
	BEGIN
		SELECT * FROM Extradictions 
		WHERE ActTime LIKE @REGEX
	END
END



USE [Lab1DB]
GO
/****** Object:  StoredProcedure [dbo].[getALL]    Script Date: 28.10.2021 1:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[getALL] (@tableName AS NVARCHAR(20))
AS
IF @tableName = 'Workers'
BEGIN
	SELECT * FROM Workers
END
ELSE IF @tableName = 'Obtainings'
BEGIN
	SELECT * FROM Obtainings
END
ELSE IF @tableName = 'Extradictions'
BEGIN
	SELECT * FROM Extradictions
END
ELSE IF @tableName = 'Owners'
BEGIN
	SELECT * FROM Owners
END
ELSE IF @tableName = 'Findings'
BEGIN
	SELECT * FROM Findings
END
ELSE IF @tableName = 'Finders'
BEGIN
	SELECT * FROM Finders
END
ELSE IF @tableName = 'Keywords'
BEGIN
	SELECT * FROM Keywords
END




USE [Lab1DB]
GO
/****** Object:  StoredProcedure [dbo].[insertIntoExtradictions]    Script Date: 28.10.2021 1:43:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[insertIntoExtradictions] 
(@OwnerIdentifier AS INT, 
@FindingIdentifier AS INT,
@WorkerIdentifier AS INT,
@DateOfAct AS VARCHAR(11))
AS
BEGIN
	SELECT * FROM Extradictions WHERE FindingId = @FindingIdentifier
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Extradictions (FindingId, OwnerId, WorkerId, ActTime)
		VALUES(@FindingIdentifier, @OwnerIdentifier, @WorkerIdentifier, @DateOfAct)
	END
END



USE [Lab1DB]
GO
/****** Object:  StoredProcedure [dbo].[insertIntoObtainings]    Script Date: 28.10.2021 1:44:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[insertIntoObtainings]
(
@WorkerIdentifier AS INT,
@FinderIdentifier AS INT,
@FindingIdentifier AS INT,
@DateOfAct AS VARCHAR(11)
)
AS
BEGIN
	SELECT * FROM Obtainings WHERE FindingId = @FindingIdentifier
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Obtainings (WorkerId, FindingId, FinderId, ActTime)
		VALUES (@WorkerIdentifier ,@FindingIdentifier, @FinderIdentifier , @DateOfAct)
	END
END




CREATE PROCEDURE getAllKeywordsByFinding 
( @FindingIdentifier AS INT )
AS
BEGIN
  SELECT Word FROM Keywords k
  INNER JOIN FindingsKeywords fk ON k.KeywordId = fk.KeywordId
  INNER JOIN Findings f ON fk.FindingId = f.FindingId
  WHERE f.FindingId = @FindingIdentifier
END

CREATE FUNCTION getNumberOfWorkerActions
(@WorkerIdentifier AS INT)
RETURNS INT
AS
BEGIN
  DECLARE @ObtainingsCount AS INT = (SELECT COUNT(*) FROM Obtainings WHERE WorkerId = @WorkerIdentifier)
  DECLARE @ExtradictionsCount AS INT = (SELECT COUNT(*) FROM Extradictions WHERE WorkerId = @WorkerIdentifier)
  RETURN @ObtainingsCount + @ExtradictionsCount;
END