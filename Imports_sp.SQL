SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppowTSChangeBuyerSelectListSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppowTSChangeBuyerSelectListSearch]
GO
 
CREATE PROCEDURE [dbo].[sppowTSChangeBuyerSelectListSearch]
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @KeyWord VarChar(250),
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
    DECLARE @KeyWord1 VarChar(260)
    SET @KeyWord1 = '%' + LOWER(@KeyWord) + '%'
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,TSID Int NOT NULL
  )
  INSERT INTO #PageIndex (TSID)
  SELECT [POW_TechnicalSpecifications].[TSID] FROM [POW_TechnicalSpecifications]
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [POW_TechnicalSpecifications].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [POW_TSStates] AS [POW_TSStates2]
    ON [POW_TechnicalSpecifications].[StatusID] = [POW_TSStates2].[StatusID]
  LEFT OUTER JOIN [POW_TSTypes] AS [POW_TSTypes3]
    ON [POW_TechnicalSpecifications].[TSTypeID] = [POW_TSTypes3].[TSTypeID]
 WHERE  
   ( 
         STR(ISNULL([POW_TechnicalSpecifications].[TSID], 0)) LIKE @KeyWord1
     OR STR(ISNULL([POW_TechnicalSpecifications].[TSTypeID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([POW_TechnicalSpecifications].[TSDescription],'')) LIKE @KeyWord1
     OR LOWER(ISNULL([POW_TechnicalSpecifications].[AdditionalEMailIDs],'')) LIKE @KeyWord1
     OR STR(ISNULL([POW_TechnicalSpecifications].[StatusID], 0)) LIKE @KeyWord1
     OR LOWER(ISNULL([POW_TechnicalSpecifications].[CreatedBy],'')) LIKE @KeyWord1
   ) 
  ORDER BY
     CASE @OrderBy WHEN 'TSID' THEN [POW_TechnicalSpecifications].[TSID] END,
     CASE @OrderBy WHEN 'TSID DESC' THEN [POW_TechnicalSpecifications].[TSID] END DESC,
     CASE @OrderBy WHEN 'TSTypeID' THEN [POW_TechnicalSpecifications].[TSTypeID] END,
     CASE @OrderBy WHEN 'TSTypeID DESC' THEN [POW_TechnicalSpecifications].[TSTypeID] END DESC,
     CASE @OrderBy WHEN 'TSDescription' THEN [POW_TechnicalSpecifications].[TSDescription] END,
     CASE @OrderBy WHEN 'TSDescription DESC' THEN [POW_TechnicalSpecifications].[TSDescription] END DESC,
     CASE @OrderBy WHEN 'AdditionalEMailIDs' THEN [POW_TechnicalSpecifications].[AdditionalEMailIDs] END,
     CASE @OrderBy WHEN 'AdditionalEMailIDs DESC' THEN [POW_TechnicalSpecifications].[AdditionalEMailIDs] END DESC,
     CASE @OrderBy WHEN 'StatusID' THEN [POW_TechnicalSpecifications].[StatusID] END,
     CASE @OrderBy WHEN 'StatusID DESC' THEN [POW_TechnicalSpecifications].[StatusID] END DESC,
     CASE @OrderBy WHEN 'CreatedOn' THEN [POW_TechnicalSpecifications].[CreatedOn] END,
     CASE @OrderBy WHEN 'CreatedOn DESC' THEN [POW_TechnicalSpecifications].[CreatedOn] END DESC,
     CASE @OrderBy WHEN 'CreatedBy' THEN [POW_TechnicalSpecifications].[CreatedBy] END,
     CASE @OrderBy WHEN 'CreatedBy DESC' THEN [POW_TechnicalSpecifications].[CreatedBy] END DESC,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName' THEN [aspnet_Users1].[UserFullName] END,
     CASE @OrderBy WHEN 'aspnet_Users1_UserFullName DESC' THEN [aspnet_Users1].[UserFullName] END DESC,
     CASE @OrderBy WHEN 'POW_TSStates2_Description' THEN [POW_TSStates2].[Description] END,
     CASE @OrderBy WHEN 'POW_TSStates2_Description DESC' THEN [POW_TSStates2].[Description] END DESC,
     CASE @OrderBy WHEN 'POW_TSTypes3_Description' THEN [POW_TSTypes3].[Description] END,
     CASE @OrderBy WHEN 'POW_TSTypes3_Description DESC' THEN [POW_TSTypes3].[Description] END DESC 

    SET @RecordCount = @@RowCount

  SELECT
    [POW_TechnicalSpecifications].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [POW_TSStates2].[Description] AS POW_TSStates2_Description,
    [POW_TSTypes3].[Description] AS POW_TSTypes3_Description 
  FROM [POW_TechnicalSpecifications] 
      INNER JOIN #PageIndex
          ON [POW_TechnicalSpecifications].[TSID] = #PageIndex.TSID
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [POW_TechnicalSpecifications].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [POW_TSStates] AS [POW_TSStates2]
    ON [POW_TechnicalSpecifications].[StatusID] = [POW_TSStates2].[StatusID]
  LEFT OUTER JOIN [POW_TSTypes] AS [POW_TSTypes3]
    ON [POW_TechnicalSpecifications].[TSTypeID] = [POW_TSTypes3].[TSTypeID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sppowTSChangeBuyerSelectListFilteres]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sppowTSChangeBuyerSelectListFilteres]
GO
 
CREATE PROCEDURE [dbo].[sppowTSChangeBuyerSelectListFilteres]
  @Filter_StatusID Int,
  @Filter_CreatedBy NVarChar(8),
  @LoginID NVarChar(8),
  @StartRowIndex int,
  @MaximumRows int,
  @OrderBy NVarChar(50),
  @RecordCount Int = 0 OUTPUT
  AS
  BEGIN
  DECLARE @LGSQL VarChar(8000)
  CREATE TABLE #PageIndex (
  IndexID INT IDENTITY (1, 1) NOT NULL
 ,TSID Int NOT NULL
  )
  SET @LGSQL = 'INSERT INTO #PageIndex (' 
  SET @LGSQL = @LGSQL + 'TSID'
  SET @LGSQL = @LGSQL + ')'
  SET @LGSQL = @LGSQL + ' SELECT '
  SET @LGSQL = @LGSQL + '[POW_TechnicalSpecifications].[TSID]'
  SET @LGSQL = @LGSQL + ' FROM [POW_TechnicalSpecifications] '
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]'
  SET @LGSQL = @LGSQL + '    ON [POW_TechnicalSpecifications].[CreatedBy] = [aspnet_users1].[LoginID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [POW_TSStates] AS [POW_TSStates2]'
  SET @LGSQL = @LGSQL + '    ON [POW_TechnicalSpecifications].[StatusID] = [POW_TSStates2].[StatusID]'
  SET @LGSQL = @LGSQL + '  LEFT OUTER JOIN [POW_TSTypes] AS [POW_TSTypes3]'
  SET @LGSQL = @LGSQL + '    ON [POW_TechnicalSpecifications].[TSTypeID] = [POW_TSTypes3].[TSTypeID]'
  SET @LGSQL = @LGSQL + '  WHERE 1 = 1 '
  IF (@Filter_StatusID > 0) 
    SET @LGSQL = @LGSQL + ' AND [POW_TechnicalSpecifications].[StatusID] = ' + STR(@Filter_StatusID)
  IF (@Filter_CreatedBy > '') 
    SET @LGSQL = @LGSQL + ' AND [POW_TechnicalSpecifications].[CreatedBy] = ''' + @Filter_CreatedBy + ''''
  SET @LGSQL = @LGSQL + '  ORDER BY '
  SET @LGSQL = @LGSQL + CASE @OrderBy
                        WHEN 'TSID' THEN '[POW_TechnicalSpecifications].[TSID]'
                        WHEN 'TSID DESC' THEN '[POW_TechnicalSpecifications].[TSID] DESC'
                        WHEN 'TSTypeID' THEN '[POW_TechnicalSpecifications].[TSTypeID]'
                        WHEN 'TSTypeID DESC' THEN '[POW_TechnicalSpecifications].[TSTypeID] DESC'
                        WHEN 'TSDescription' THEN '[POW_TechnicalSpecifications].[TSDescription]'
                        WHEN 'TSDescription DESC' THEN '[POW_TechnicalSpecifications].[TSDescription] DESC'
                        WHEN 'AdditionalEMailIDs' THEN '[POW_TechnicalSpecifications].[AdditionalEMailIDs]'
                        WHEN 'AdditionalEMailIDs DESC' THEN '[POW_TechnicalSpecifications].[AdditionalEMailIDs] DESC'
                        WHEN 'StatusID' THEN '[POW_TechnicalSpecifications].[StatusID]'
                        WHEN 'StatusID DESC' THEN '[POW_TechnicalSpecifications].[StatusID] DESC'
                        WHEN 'CreatedOn' THEN '[POW_TechnicalSpecifications].[CreatedOn]'
                        WHEN 'CreatedOn DESC' THEN '[POW_TechnicalSpecifications].[CreatedOn] DESC'
                        WHEN 'CreatedBy' THEN '[POW_TechnicalSpecifications].[CreatedBy]'
                        WHEN 'CreatedBy DESC' THEN '[POW_TechnicalSpecifications].[CreatedBy] DESC'
                        WHEN 'aspnet_Users1_UserFullName' THEN '[aspnet_Users1].[UserFullName]'
                        WHEN 'aspnet_Users1_UserFullName DESC' THEN '[aspnet_Users1].[UserFullName] DESC'
                        WHEN 'POW_TSStates2_Description' THEN '[POW_TSStates2].[Description]'
                        WHEN 'POW_TSStates2_Description DESC' THEN '[POW_TSStates2].[Description] DESC'
                        WHEN 'POW_TSTypes3_Description' THEN '[POW_TSTypes3].[Description]'
                        WHEN 'POW_TSTypes3_Description DESC' THEN '[POW_TSTypes3].[Description] DESC'
                        ELSE '[POW_TechnicalSpecifications].[TSID]'
                    END
  EXEC (@LGSQL)

  SET @RecordCount = @@RowCount

  SELECT
    [POW_TechnicalSpecifications].* ,
    [aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,
    [POW_TSStates2].[Description] AS POW_TSStates2_Description,
    [POW_TSTypes3].[Description] AS POW_TSTypes3_Description 
  FROM [POW_TechnicalSpecifications] 
      INNER JOIN #PageIndex
          ON [POW_TechnicalSpecifications].[TSID] = #PageIndex.TSID
  LEFT OUTER JOIN [aspnet_users] AS [aspnet_users1]
    ON [POW_TechnicalSpecifications].[CreatedBy] = [aspnet_users1].[LoginID]
  LEFT OUTER JOIN [POW_TSStates] AS [POW_TSStates2]
    ON [POW_TechnicalSpecifications].[StatusID] = [POW_TSStates2].[StatusID]
  LEFT OUTER JOIN [POW_TSTypes] AS [POW_TSTypes3]
    ON [POW_TechnicalSpecifications].[TSTypeID] = [POW_TSTypes3].[TSTypeID]
  WHERE
        #PageIndex.IndexID > @StartRowIndex
        AND #PageIndex.IndexID < (@StartRowIndex + @MaximumRows + 1)
  ORDER BY
    #PageIndex.IndexID
  END
  GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
