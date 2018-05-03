--CREATE VIEW [dbo].[SertificatesView]
--	AS SELECT SubdivisionName, StandartName, SertificateDate, SertificateShelfLife 
--	FROM Sertificates
--	INNER JOIN Subdivisions on Subdivisions.SubdivisionId = Sertificates.SubdivisionId
--	INNER JOIN Standarts on Standarts.StandartId = Sertificates.StandartId

--CREATE VIEW [dbo].[ApplicationsView]
--	AS SELECT UserLastName, UserName, UserMiddleName, StandartName, ApplicationDateTime, ApplicationContent, ApplicationFile
--	FROM Applications
--	INNER JOIN Users on Users.UserId = Applications.UserId
--	INNER JOIN Standarts on Standarts.StandartId = Applications.StandartId

--CREATE VIEW [dbo].[NewsView]
--	AS SELECT AdminLastName, AdminName, AdminMiddleName, NewsTitle, NewsContent, NewsDateTime
--	FROM Newss
--	INNER JOIN Admins on Admins.AdminId = Newss.AdminId

--CREATE VIEW [dbo].[AdjustmentView]
--	AS SELECT UserLastName, UserName, UserMiddleName, SubdivisionName, AdminLastName, AdminName, AdminMiddleName, StandartName, AdjustmentDateTime, AdjustmentContent, AdjustmentFile
--	FROM Adjustments
--	INNER JOIN Users on Users.UserId = Adjustments.UserId
--	INNER JOIN Applications on Applications.ApplicationId = Adjustments.ApplicationId
--	INNER JOIN Standarts on Standarts.StandartId = Applications.StandartId
--	INNER JOIN Admins on Admins.AdminId = Adjustments.AdminId
--	INNER JOIN Subdivisions on Subdivisions.SubdivisionId = Users.SubdivisionId

--CREATE VIEW [dbo].[UsersView]
--	AS SELECT UserLastName, UserName, UserMiddleName, UserEmail, UserPhone, SubdivisionName
--	FROM Users
--	INNER JOIN Subdivisions on Subdivisions.SubdivisionId = Users.SubdivisionId