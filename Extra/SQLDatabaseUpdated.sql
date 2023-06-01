SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;  


CREATE DATABASE NetflixDB







USE[NetflixDB]

CREATE TABLE Invitation (
	inviterId int IDENTITY NOT NULL,
	inviteeId int,
	PRIMARY KEY (inviterId)
);

CREATE TABLE Customer (
	CustomerId int IDENTITY UNIQUE NOT NULL,
	emailAdress varchar(40) UNIQUE NOT NULL,
	password varchar(30),
	active bit,
	loginAttempts int,
	blocked bit,
	createdDate DATE,
	PRIMARY KEY (CustomerId),
	check(emailAdress LIKE '%_@%.%')
);

CREATE INDEX CustomerIndex
ON Customer (emailAdress, password);

CREATE TABLE SubscriptionType (
	subscriptionTypeId int IDENTITY UNIQUE NOT NULL,
	name varchar(50),
	price float,
	PRIMARY KEY (subscriptionTypeId),
);

CREATE TABLE Subscription (
	subscriptionId int IDENTITY,
	customerId int,
	subscriptionTypeId int ,
	startDate DATE, 
	endDate DATE,
	PRIMARY KEY (subscriptionId),
	FOREIGN KEY (CustomerId) REFERENCES Customer(customerId),
	FOREIGN KEY (subscriptionTypeId) REFERENCES SubscriptionType(subscriptionTypeId)
);


CREATE TABLE SubtitleLanguage (
	languageId int IDENTITY,
	name varchar(50),
	PRIMARY KEY (languageId)
);

CREATE TABLE Profile ( 
	profileId int IDENTITY,
	CustomerId int,
	name varchar(50),
	profilePicture varchar(50),
	age int,
	language int,
	PRIMARY KEY(profileId),
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
	FOREIGN KEY (language) REFERENCES SubtitleLanguage(languageId)
);

CREATE TABLE ContentType (
	contentTypeId int IDENTITY,
	name varchar(50),
	PRIMARY KEY (contentTypeId)
);


CREATE TABLE Content (
	contentId int IDENTITY,
	contentTypeId int, 
	PRIMARY KEY (contentId),
	FOREIGN KEY (contentTypeId) REFERENCES ContentType(contentTypeId)
);

CREATE TABLE Series (
	serieId int IDENTITY,
	contentId int,
	title varchar(50),
	PRIMARY KEY (serieId),
	FOREIGN KEY (contentId) REFERENCES Content(contentId)
);

CREATE INDEX SeriesIndex
ON Series (contentId, title);

CREATE TABLE Season (
	seasonId int IDENTITY, 
	serieId int,
	title varchar(50),
	seasonNumber int,
	PRIMARY KEY (seasonId),
	FOREIGN KEY (serieId) REFERENCES Series(serieId)
);	

CREATE TABLE Episode (
	episodeId int IDENTITY,
	seasonId int,
	contentId int, 
	title varchar(50),
	episodeNumber int,
	creditStartTime int,
	PRIMARY KEY (episodeId),
	FOREIGN KEY (seasonId) REFERENCES Season(seasonId),
	FOREIGN KEY (contentId) REFERENCES Content(contentId)
);

CREATE TABLE Quality (
	qualityId int IDENTITY,
	name varchar(30),
	PRIMARY KEY (qualityId)
);

CREATE TABLE Movie (
	movieId int IDENTITY, 
	contentId int,
	title varchar(50), 
	qualityId int,
	creditStartTime int,
	PRIMARY KEY (movieId),
	FOREIGN KEY (contentId) REFERENCES Content(contentId),
	FOREIGN KEY (qualityId) REFERENCES Quality(qualityId)
);

CREATE TABLE contentWatched (
	profileId int,
	contentId int,
	timesWatched int,
	FOREIGN KEY (profileId) REFERENCES Profile(profileId)
);

CREATE INDEX ContentIndex
ON contentWatched (contentId, timesWatched);

CREATE TABLE watchTime (
	watchTimeId int IDENTITY,
	profileId int,
	contentId int,
	timeStamp int ,
	watchDate DATE,
	languageContent int,
	PRIMARY KEY (watchTimeId),
	FOREIGN KEY (profileId) REFERENCES Profile(profileId)
);

CREATE TABLE watchList (
	profileId int,
	contentId int,
	FOREIGN KEY (profileId) REFERENCES Profile(profileId),
	FOREIGN KEY (contentId) REFERENCES Content(contentId)
);


CREATE TABLE SubtitleLanguageContent (
	languageContentId int IDENTITY,
	languageId int,
	contentId int,
	FOREIGN KEY (languageId) REFERENCES SubtitleLanguage(languageId),
	FOREIGN KEY (contentId) REFERENCES Content(contentId)
)

CREATE TABLE KijkwijzerContent (
	kijkwijzerId int IDENTITY,
	contentId int,
	PRIMARY KEY (kijkwijzerId)
);

CREATE TABLE Kijkwijzer ( 
	kijkwijzerId int IDENTITY, 
	name varchar(50),
	PRIMARY KEY (kijkwijzerId),
	FOREIGN KEY (kijkwijzerId) REFERENCES KijkwijzerContent(kijkwijzerId) 
);

CREATE TABLE Preference (
	profileId int, 
	kijkwijzerId int,
	FOREIGN KEY (profileId) REFERENCES Profile(profileId),
	FOREIGN KEY (kijkwijzerId) REFERENCES Kijkwijzer(kijkwijzerId) ON DELETE SET NULL
);

GO

-- Views:
-- 1 (Haalt emailadressen op waarbij de gebruiker een HD abonnement heeft en het abonnement afloopt binnen 90 dagen):


CREATE VIEW getEndingSubs as
SELECT emailAdress FROM Customer 
INNER JOIN Subscription ON Subscription.customerId = Customer.customerId
INNER JOIN SubscriptionType ON SubscriptionType.subscriptionTypeId = Subscription.subscriptionTypeId
WHERE DATEDIFF(DAY, GETDATE(), Subscription.endDate) < 90
AND SubscriptionType.name = 'Free';

GO 
-- Views:
-- 2 (Laat zien hoeveel films en series er zijn per content type):


CREATE VIEW ContentTypeCount AS
SELECT ContentType.name, COUNT(*) AS Amount
FROM Content
INNER JOIN ContentType ON ContentType.contentTypeId = Content.contentTypeId
GROUP BY ContentType.name

GO 
--Triggers:
--1 (Wanneer er een film wordt verwijderd):
CREATE TRIGGER ProfileDeleted 
ON Movie
FOR DELETE
AS
print'The movie has been deleted'

GO 
--Triggers
--2(Nadat er een film title is toegevoegd)
CREATE TRIGGER EpisodeAdded 
ON Episode
FOR INSERT
AS
print'The episode has been added'

GO
-- Stored Procedure
-- 1 (Standaard procedure om een nieuwe film toe te voegen):
CREATE PROCEDURE InsertNewMovie
		@title				VARCHAR(50) = null,
		@qualityId			int			= null,
		@creditStartTime	int			= null

AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Movie(
		title, 
		qualityId,
		creditStartTime
	)
	VALUES
		(
			@title,
			@qualityId,
			@creditStartTime
		);

END

GO
-- Triggers
-- 2 (Verwijdert een bepaalde serie in alle gerelateerde tabellen):
CREATE PROCEDURE DeleteSeries
		@title VARCHAR(50) = null

AS 
BEGIN
	SET NOCOUNT ON

	DELETE FROM Episode
	WHERE SeasonId = (SELECT seasonId
						FROM Series
						WHERE serieId = (SELECT serieId 
						FROM Series
						WHERE title = @title));
	
	DELETE FROM Season
	WHERE serieId = (SELECT serieId 
					  FROM Series
					  WHERE title = @title);

	DELETE FROM Content
	WHERE contentId = (SELECT contentId
						FROM Series
						WHERE serieId = (SELECT serieId 
										 FROM Series
										 WHERE title = @title));

	DELETE FROM Series
	WHERE serieId = (SELECT serieId 
					FROM Series
					WHERE title = @title);

END

