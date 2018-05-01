-- =========================================
-- Create FileTable template
-- =========================================
USE AuditControlSystemDB
GO

IF OBJECT_ID('��������', 'U') IS NOT NULL
  DROP TABLE ��������
GO

CREATE TABLE �������� AS FILETABLE
  --WITH
  --(
  --  FILETABLE_DIRECTORY = 'sample_filetable',
  --  FILETABLE_COLLATE_FILENAME = database_default
  --)
GO
