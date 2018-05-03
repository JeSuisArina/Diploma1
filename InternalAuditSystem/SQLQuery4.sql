--CREATE VIEW AdjustmentView AS
--SELECT	dbo.Users.UserLastName, dbo.Users.UserName, dbo.Users.UserMiddleName, 
--		dbo.Applications.ApplicationId,
--		dbo.Standarts.StandartName, 
--		dbo.Adjustments.AdjustmentDateTime, dbo.Adjustments.AdjustmentContent, dbo.Adjustments.AdjustmentFile, dbo.Adjustments.AdjustmentId
--FROM	dbo.Adjustments INNER JOIN
--			dbo.Users ON dbo.Users.UserId = dbo.Adjustments.UserId INNER JOIN
--			dbo.Applications ON dbo.Applications.ApplicationId = dbo.Adjustments.ApplicationId INNER JOIN
--			dbo.Standarts ON dbo.Standarts.StandartId = dbo.Applications.StandartId 

