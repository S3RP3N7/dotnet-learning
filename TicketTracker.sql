/* ============================================================
   TicketTracker.sql
   Phase 2 SQL exercises for the Ticket Tracker project.

   Enum values stored as INT (order matters, it must match C#):
     Priority: 0 = P1, 1 = P2, 2 = P3, 3 = P4
     Status:   0 = Open, 1 = InProgress, 2 = Resolved, 3 = Closed
   ============================================================ */

/* ---------- 1. Create the database ---------- */
IF DB_ID('Sandbox') IS NULL
    CREATE DATABASE Sandbox;
GO

USE Sandbox;
GO

/* ---------- 2. Create the tables ---------- */
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users
    (
        Id   INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.Tickets', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tickets
    (
        Id            INT IDENTITY(1,1) PRIMARY KEY,
        Title         NVARCHAR(200) NOT NULL,
        UsersAffected INT NOT NULL,
        Priority      INT NOT NULL,
        Status        INT NOT NULL
    );
END
GO

/* Add the link from a ticket to a user, only if it doesn't exist yet */
IF COL_LENGTH('dbo.Tickets', 'AssignedUserId') IS NULL
    ALTER TABLE dbo.Tickets ADD AssignedUserId INT NULL;
GO

/* ---------- 3. Insert sample data ---------- */
/* Run this section ONCE, or you will get duplicate rows. */
INSERT INTO dbo.Tickets (Title, UsersAffected, [Priority], [Status])
VALUES ('Screen doesn''t work', 3, 3, 0);

INSERT INTO dbo.Tickets (Title, UsersAffected, [Priority], [Status])
VALUES ('Mouse broken', 1, 3, 0);

INSERT INTO dbo.Tickets (Title, UsersAffected, [Priority], [Status])
VALUES ('Server down', 400, 0, 0);

INSERT INTO dbo.Users ([Name])
VALUES ('Paul');

INSERT INTO dbo.Users ([Name])
VALUES ('Mark');
GO

/* ---------- 4. Queries ---------- */

/* Open tickets (Status 0), with the columns named and a stable order */
SELECT Id, Title, [Priority]
FROM dbo.Tickets
WHERE [Status] = 0
ORDER BY [Priority];

/* Close a ticket by Id (Status 3 = Closed) */
UPDATE dbo.Tickets
SET [Status] = 3   -- Closed
WHERE Id = 2;

/* Tickets per priority (same idea as GroupBy in C#:
   [Priority] is group.Key, COUNT(*) is group.Count()) */
SELECT [Priority], COUNT(*) AS TicketCount
FROM dbo.Tickets
GROUP BY [Priority]
ORDER BY [Priority];

/* ---------- 5. Joins ---------- */

/* Assign a ticket to a user (example: ticket 3 to user 1) */
UPDATE dbo.Tickets
SET AssignedUserId = 1
WHERE Id = 3;

/* INNER JOIN: only tickets that HAVE an assigned user */
SELECT t.Id, t.Title, u.[Name] AS AssignedTo
FROM dbo.Tickets AS t
INNER JOIN dbo.Users AS u ON u.Id = t.AssignedUserId;

/* LEFT JOIN: ALL tickets, with the user's name where there is one (NULL if not) */
SELECT t.Id, t.Title, u.[Name] AS AssignedTo
FROM dbo.Tickets AS t
LEFT JOIN dbo.Users AS u ON u.Id = t.AssignedUserId;

/* LEFT JOIN + IS NULL: tickets with NO assigned user.
   Always IS NULL, never = NULL (NULL means unknown, so = NULL matches nothing). */
SELECT t.Id, t.Title
FROM dbo.Tickets AS t
LEFT JOIN dbo.Users AS u ON u.Id = t.AssignedUserId
WHERE u.Id IS NULL;
