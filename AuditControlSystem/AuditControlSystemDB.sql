-- =========================================
-- Create FileTable template
-- =========================================
USE AuditControlSystemDB
GO

IF OBJECT_ID('Документ', 'U') IS NOT NULL
  DROP TABLE Документ
GO

CREATE TABLE Документ AS FILETABLE
  --WITH
  --(
  --  FILETABLE_DIRECTORY = 'sample_filetable',
  --  FILETABLE_COLLATE_FILENAME = database_default
  --)
GO
