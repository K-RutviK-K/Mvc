CREATE DATABASE jwtdbtwo
USE jwtdbtwo

CREATE TABLE [department]
( dptId INT PRIMARY kEY NOT NULL IDENTITY(1,1),
	dptName VARCHAR(50) NOT NULl
)

CREATE TABLE [user](
userId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
email VARCHAR(100) NOT NULL UNIQUE,
password VARCHAR(MAX),
[name] VARCHAR(50) NOT NULL,
[role] VARCHAR(10) NOT NULL CHECK ([role] IN ('admin','user')) default 'user',
[gender] VARCHAR(10) ,
[contact] INT,
[address] VARCHAR(50),
[dptId] INT FOREIGN KEY REFERENCES department(dptID)
)



INSERT INTO department VALUES
('DotNet'),
('Node'),
('System')

INSERT INTO [user]
values ('rutvik@gmail.com','123','RutviK','user','male',1234567890,'surendranagar',1),
('admin@gmail.com','123','Admin','admin','male',1234567890,'rajkot',3),
('user1@gmail.com','123','User1','user','female',1234567890,'radix',2),
('user2@gmail.com','123','User2','user','male',1234567890,'ahm',1)

select * from [user]