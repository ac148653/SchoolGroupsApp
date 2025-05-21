USE SchoolGroupsDB; 
go 

CREATE SCHEMA StudentInvolvement; 
go 

CREATE SCHEMA GroupManagement; 
go 

CREATE SCHEMA Staff; 
go 

 

CREATE TABLE StudentInvolvement.students ( 

studentID INT IDENTITY (1, 1) PRIMARY KEY, 
lastName VARCHAR (255), 
firstName VARCHAR (255) NOT NULL, 
yearLevel SMALLINT NOT NULL, 
homeroom VARCHAR (255) NOT NULL); 

 

CREATE TABLE GroupManagement.groups ( 

groupID INT IDENTITY (1,1) PRIMARY KEY, 
groupName VARCHAR (255) NOT NULL ); 

 

CREATE TABLE StudentInvolvement.studentGroups ( 

studentGroupID INT IDENTITY (1,1) PRIMARY KEY, 
studentID INT NOT NULL, 
FOREIGN KEY (studentID) REFERENCES StudentInvolvement.students (studentID) ON DELETE CASCADE ON UPDATE CASCADE, 
groupID INT NOT NULL, 
FOREIGN KEY (groupID) REFERENCES GroupManagement.groups (groupID) ON DELETE CASCADE ON UPDATE CASCADE, 
leader BIT ); 

 

CREATE TABLE GroupManagement.tasks ( 

taskID INT IDENTITY (1,1) PRIMARY KEY, 
taskName VARCHAR (255) NOT NULL, 
pointsValue INT NOT NULL, 
groupID INT NOT NULL, 
FOREIGN KEY (groupID) REFERENCES GroupManagement.groups (groupID) ON DELETE CASCADE ON UPDATE CASCADE ); 

 

CREATE TABLE StudentInvolvement.studentTaskPoints ( 

studentTaskPointsID INT IDENTITY (1,1) PRIMARY KEY, 
studentGroupID INT NOT NULL, 
FOREIGN KEY (studentGroupID) REFERENCES StudentInvolvement.studentGroups (studentGroupID) ON DELETE NO ACTION ON UPDATE NO ACTION, 
taskID INT NOT NULL, 
FOREIGN KEY (taskID) REFERENCES GroupManagement.tasks (taskID) ON DELETE NO ACTION ON UPDATE NO ACTION, 
points INT NOT NULL ); 

 

CREATE TABLE GroupManagement.Badges ( 

badgeID INT IDENTITY (1,1) PRIMARY KEY, 
badgeLevel VARCHAR (255) NOT NULL, 
badgeName VARCHAR (255) NOT NULL ); 

 

CREATE TABLE StudentInvolvement.studentBadges ( 

studentBadgeID INT IDENTITY (1,1) PRIMARY KEY, 
studentGroupID INT NOT NULL, 
FOREIGN KEY (studentGroupID) REFERENCES StudentInvolvement.studentGroups (studentGroupID) ON DELETE CASCADE ON UPDATE CASCADE, 
badgeID INT NOT NULL,	 
FOREIGN KEY (badgeID) REFERENCES GroupManagement.badges (badgeID) ON DELETE CASCADE ON UPDATE CASCADE ); 

 

CREATE TABLE Staff.teachers ( 

teacherID INT IDENTITY (1,1) PRIMARY KEY, 
lastName VARCHAR (255), 
firstName VARCHAR (255) NOT NULL ); 

 

CREATE TABLE Staff.teacherGroups ( 

teacherGroupID INT IDENTITY (1,1) PRIMARY KEY, 
teacherID INT NOT NULL, 
FOREIGN KEY (teacherID) REFERENCES Staff.teachers (teacherID) ON DELETE CASCADE ON UPDATE CASCADE, 
groupID INT NOT NULL, 
FOREIGN KEY (groupID) REFERENCES GroupManagement.groups (groupID) ON DELETE CASCADE ON UPDATE CASCADE ); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Smith',  'Anna', 12, '12GRG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Jones', 'Liam', 11, '11PLK'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Williams', 'Olivia', 10, '10JSP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Brown', 'Aiden', 9, '9AWR'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Johnson', 'Sophia', 13, '13BJS'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lee', 'Emma', 12, '12MNG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('White', 'Mason', 11, '11BRX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Garcia', 'Charlotte', 10, '10VCR'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Miller', 'Lucas', 9, '9FTL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Davis', 'Isabella', 13, '13KHG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Martinez', 'Ethan', 12, '12VRT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Hernandez', 'Sophia', 11, '11LGB'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lopez', 'Zachary', 10, '10RFQ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Wilson', 'Liam', 9, '9XJL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Thomas', 'Megan', 13, '13BNL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Roberts', 'Ava', 12, '12GSW'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Jackson', 'Nathan', 11, '11PMN'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lee', 'Aidan', 10, '10SHQ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Green', 'Olivia', 9, '9UKP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Adams', 'Benjamin', 13, '13PSG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Evans', 'James', 12, '12WTQ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Carter', 'Isabella', 11, '11RFT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Morris', 'Aidan', 10, '10GTW'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Walker', 'Emma', 9, '9LZX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Parker', 'Lucas', 13, '13JKN'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Allen', 'Maya', 12, '12PCV'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Scott', 'Zoe', 11, '11BSH'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Young', 'Benjamin', 10, '10DFV'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('King', 'Lily', 9, '9SCL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Allen', 'Ava', 13, '13GMC'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Baker', 'Sophia', 12, '12TXL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Carter', 'Daniel', 11, '11ZSH'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Evans', 'Zoe', 10, '10VXL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Mitchell', 'Olivia', 9, '9WPQ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Taylor', 'Charlotte', 13, '13VDX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Robinson', 'Liam', 12, '12WZT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Harris', 'Emily', 11, '11VCR'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Martinez', 'William', 10, '10LFX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Thompson', 'Grace', 9, '9PBN'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Phillips', 'Madeline', 13, '13DXR'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Young', 'Olivia', 12, '12NRB'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Jackson', 'Jacob', 11, '11FBQ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Davis', 'Ava', 10, '10GYS'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('King', 'Ethan', 9, '9JQN'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Wilson', 'David', 13, '13SDT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Martinez', 'Grace', 12, '12VCP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Miller', 'Zachary', 11, '11PHL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('White', 'Benjamin', 10, '10XRY'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Reed', 'Charlotte', 9, '9JFW'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Hughes', 'Lily', 13, '13FTX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Allen', 'Zachary', 12, '12KLV'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Taylor', 'Isabella', 11, '11PJN'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Gonzalez', 'Amelia', 10, '10FVP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Clark', 'Aidan', 9, '9BKS'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Morris', 'Liam', 13, '13DML'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Green', 'David', 12, '12KWT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lee', 'Sophie', 11, '11MFB'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Johnson', 'Madeline', 10, '10NVF'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('King', 'Jacob', 9, '9WTZ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Taylor', 'Olivia', 13, '13CJL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Walker', 'Lucas', 12, '12PTG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lopez', 'Grace', 11, '11DBK'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Roberts', 'Benjamin', 10, '10FYB'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Garcia', 'Emily', 9, '9DWY'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Rodriguez', 'William', 13, '13MPQ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Miller', 'Maya', 12, '12TJL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Wilson', 'Isabella', 11, '11BVS'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Parker', 'Aidan', 10, '10LMZ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Taylor', 'Sophia', 9, '9LWX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Johnson', 'Mason', 13, '13KLD'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Davis', 'Grace', 12, '12SGL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Hernandez', 'Daniel', 11, '11KTJ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Adams', 'Emily', 10, '10ZNP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Morris', 'Lily', 9, '9HBG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Martin', 'Lucas', 13, '13FWS'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Baker', 'Aiden', 12, '12RTK'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Martinez', 'Isabella', 11, '11ZDK'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Evans', 'Benjamin', 10, '10JQX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Hughes', 'Olivia', 9, '9FGS'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lewis', 'Charlotte', 13, '13DLT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Clark', 'Ava', 12, '12HDN'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Parker', 'Liam', 11, '11FVC'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Anderson', 'Olivia', 10, '10PSG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Mitchell', 'Emily', 9, '9HZW'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Robinson', 'Madeline', 13, '13LWX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Jackson', 'Sophia', 9, '9MGR'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Taylor', 'Zoe', 12, '12QWG'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Lee', 'Benjamin', 11, '11AWX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Wilson', 'Isabella', 10, '10LFZ'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Brown', 'Emily', 9, '9PBX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Martinez', 'Sophia', 13, '13JXP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Harris', 'Liam', 12, '12SBF'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Clark', 'Grace', 11, '11QLR'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Roberts', 'Mason', 10, '10HSP'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Miller', 'Ava', 9, '9DJX'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Carter', 'Lucas', 13, '13JNT'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Gonzalez', 'Zoe', 12, '12XWB'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Walker', 'Madeline', 11, '11KYL'); 

INSERT INTO StudentInvolvement.students (lastName, firstName, yearLevel, homeroom) VALUES ('Wilson', 'Olivia', 10, '10RYK'); 

 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Indian Polyfest Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Chinese Polyfest Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Vietnamese Polyfest Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Kapa Haka'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Japanese Polyfest Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Samoan Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Tongan Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Choir'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Contemporary Dance Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Film Club'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Innovation Club'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Photography Club'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Art Club'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Creative Writers'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Orchestra'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Book Club'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Debating'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Rainbow Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Environmental Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Yoga Club'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('School Show'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('ShowQuest'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Shakespeare Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Science Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Chess'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Robotics'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Korean Polyfest Group'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Fashion Design'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Tai Chi'); 

INSERT INTO GroupManagement.groups (groupName) VALUES ('Gardening Club');	 

 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (1, 2, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (1, 3, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (2, 1, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (2, 4, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (3, 5, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (3, 2, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (4, 6, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (4, 3, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (5, 7, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (5, 8, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (6, 9, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (6, 4, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (7, 10, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (7, 11, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (8, 12, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (8, 5, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (9, 13, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (9, 6, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (10, 14, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (10, 7, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (11, 15, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (11, 8, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (12, 16, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (12, 9, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (13, 17, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (13, 10, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (14, 18, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (14, 11, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (15, 19, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (15, 12, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (16, 20, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (16, 13, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (17, 21, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (17, 14, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (18, 22, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (18, 15, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (19, 23, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (19, 16, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (20, 24, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (20, 17, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (21, 25, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (21, 18, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (22, 26, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (22, 19, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (23, 27, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (23, 20, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (24, 28, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (24, 21, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (25, 29, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (25, 22, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (26, 30, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (26, 23, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (27, 1, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (27, 24, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (28, 2, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (28, 25, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (29, 3, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (29, 26, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (30, 4, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (30, 27, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (31, 5, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (31, 28, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (32, 6, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (32, 29, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (33, 7, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (33, 30, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (34, 8, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (34, 1, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (35, 9, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (35, 2, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (36, 10, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (36, 3, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (37, 11, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (37, 4, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (38, 12, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (38, 5, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (39, 13, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (39, 6, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (40, 14, 1); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (40, 7, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (41, 1, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (42, 2, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (43, 3, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (44, 4, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (45, 5, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (46, 6, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (47, 7, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (48, 8, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (49, 9, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (50, 10, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (51, 11, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (52, 12, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (53, 13, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (54, 14, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (55, 15, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (56, 16, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (57, 17, 0); 

INSERT INTO StudentInvolvement.studentGroups (studentID, groupID, leader) VALUES (58, 18, 0); 

 

 

 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Suggest a Book', 2, 1); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Poster', 5, 2); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Blog Post', 3, 3); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a T-shirt', 4, 4); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Research a Topic', 6, 5); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Meeting', 10, 6); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Survey', 8, 7); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Social Media Campaign', 5, 8); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Workshop', 9, 9); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Prepare a Presentation', 6, 10); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Fundraiser', 15, 11); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design an Invitation', 4, 12); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Coordinate an Event', 12, 13); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Proposal', 7, 14); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Video', 10, 15); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Plan an Excursion', 14, 16); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Game Night', 3, 17); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Record a Podcast', 5, 18); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Website', 8, 19); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create an Infographic', 6, 20); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Webinar', 11, 21); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Debate', 7, 22); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Script', 6, 23); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Charity Event', 13, 24); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create an Art Piece', 5, 25); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Talent Show', 9, 26); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Newsletter', 7, 27); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Prepare a Budget', 4, 28); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Poem', 2, 29); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Picnic', 6, 30); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Brochure', 4, 1); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Dance Party', 12, 2); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Quiz', 5, 3); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Speech', 6, 4); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Coordinate a Photo Shoot', 8, 5); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Logo', 7, 6); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Prepare an Agenda', 3, 7); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Potluck', 4, 8); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Promotional Video', 10, 9); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Review', 3, 10); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Coordinate a Contest', 5, 11); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Prepare a Newsletter', 7, 12); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Website Layout', 9, 13); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Letter', 3, 14); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Q&A Session', 8, 15); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Flyer', 5, 16); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Plan a Trip', 12, 17); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write an Article', 6, 18); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Digital Poster', 7, 19); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Virtual Event', 10, 20); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Greeting Card', 4, 21); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Script', 5, 22); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Cooking Class', 14, 23); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Poll', 2, 24); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Poster', 5, 25); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Thank You Note', 3, 26); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Podcast', 8, 27); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Prepare an Invitation', 6, 28); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Workshop', 11, 29); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Social Media Post', 5, 30); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Yoga Session', 7, 1); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Banner', 5, 2); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Book Club', 10, 3); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Sketch', 4, 4); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write an Essay', 6, 5); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Marathon', 12, 6); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create an Animated Short', 15, 7); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Prepare an Event Script', 6, 8); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Menu', 5, 9); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Debate', 7, 10); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Creative Story', 4, 11); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Comedy Show', 10, 12); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a PowerPoint', 6, 13); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Talent Contest', 8, 14); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Research Paper', 10, 15); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Design a Coupon', 4, 16); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Sketchbook', 5, 17); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Host a Charity Run', 13, 18); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Organize a Dance Show', 9, 19); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Create a Custom Badge', 4, 20); 

INSERT INTO groupManagement.tasks (taskName, pointsValue, groupID) VALUES ('Write a Short Story', 5, 21); 

 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (1, 5, 24); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (2, 18, 16); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (3, 25, 28); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (4, 32, 36); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (5, 47, 55); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (6, 3, 20); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (7, 11, 44); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (8, 19, 12); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (9, 42, 62); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (10, 9, 33); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (11, 14, 40); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (12, 5, 60); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (13, 3, 21); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (14, 26, 70); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (15, 15, 23); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (16, 2, 58); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (17, 22, 50); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (18, 7, 43); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (19, 10, 66); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (20, 8, 25); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (21, 27, 53); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (22, 1, 75); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (23, 41, 47); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (24, 30, 22); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (25, 31, 79); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (26, 29, 29); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (27, 6, 38); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (28, 13, 24); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (29, 39, 80); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (30, 44, 14); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (31, 28, 57); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (32, 16, 51); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (33, 35, 35); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (34, 12, 42); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (35, 33, 73); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (36, 4, 46); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (37, 43, 58); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (38, 17, 56); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (39, 45, 70); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (40, 23, 48); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (41, 48, 27); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (42, 20, 34); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (43, 24, 61); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (44, 11, 26); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (45, 37, 62); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (46, 50, 63); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (47, 54, 75); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (48, 9, 68); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (49, 18, 21); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (50, 10, 80); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (51, 26, 13); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (52, 33, 29); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (53, 15, 56); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (54, 22, 69); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (55, 38, 52); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (56, 42, 48); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (57, 43, 31); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (58, 25, 67); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (59, 17, 70); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (60, 21, 79); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (61, 8, 45); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (62, 34, 60); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (63, 39, 77); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (64, 50, 64); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (65, 31, 53); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (66, 44, 35); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (67, 24, 57); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (68, 41, 40); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (69, 37, 12); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (70, 32, 25); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (71, 47, 80); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (72, 3, 71); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (73, 41, 34); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (74, 11, 42); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (75, 26, 48); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (76, 39, 66); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (77, 50, 60); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (78, 5, 75); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (79, 27, 60); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (80, 28, 47); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (12, 45, 29); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (50, 33, 78); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (50, 19, 32); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (37, 14, 77); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (66, 2, 45); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (77, 43, 43); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (52, 18, 62); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (33, 50, 54); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (10, 9, 51); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (30, 5, 27); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (30, 25, 81); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (55, 33, 72); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (24, 14, 29); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (42, 48, 37); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (17, 42, 50); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (74, 20, 68); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (15, 31, 45); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (21, 27, 22); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (65, 9, 60); 

INSERT INTO StudentInvolvement.studentTaskPoints (studentGroupID, taskID, points) VALUES (45, 41, 49); 

 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Gold', 'Leadership'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Silver', 'Service'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Bronze', 'Creativity'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Gold', 'Community'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Silver', 'Academic Excellence'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Bronze', 'Teamwork'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Gold', 'Innovation'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Silver', 'Leadership'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Bronze', 'Service'); 

INSERT INTO GroupManagement.Badges (badgeLevel, badgeName) VALUES ('Gold', 'Service'); 

 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (1, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (2, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (3, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (4, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (5, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (6, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (7, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (8, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (9, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (10, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (11, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (12, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (13, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (14, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (15, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (16, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (17, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (18, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (19, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (20, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (21, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (22, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (23, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (24, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (25, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (26, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (27, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (28, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (29, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (30, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (31, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (32, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (33, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (34, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (35, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (36, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (37, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (38, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (39, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (40, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (41, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (42, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (43, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (44, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (45, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (46, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (47, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (48, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (49, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (50, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (51, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (52, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (53, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (54, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (55, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (56, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (57, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (58, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (59, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (60, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (61, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (62, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (63, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (64, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (65, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (66, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (67, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (68, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (69, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (70, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (71, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (72, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (73, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (74, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (75, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (76, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (77, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (78, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (79, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (80, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (81, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (82, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (83, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (84, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (85, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (86, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (87, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (88, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (89, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (90, 10); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (91, 3); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (92, 7); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (93, 5); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (94, 2); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (95, 9); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (96, 1); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (97, 6); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (98, 8); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (99, 4); 

INSERT INTO StudentInvolvement.studentBadges (studentGroupID, badgeID) VALUES (100, 10); 

 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Green', 'Hailey'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Smith', 'John'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Brown', 'Alice'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Williams', 'Michael'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Jones', 'Emma'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Taylor', 'David'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Anderson', 'Sophia'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Thomas', 'Daniel'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Jackson', 'Olivia'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('White', 'James'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Harris', 'Isabella'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Martin', 'Liam'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Thompson', 'Charlotte'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Garcia', 'Ethan'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Martinez', 'Amelia'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Roberts', 'Mason'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Lopez', 'Harper'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Walker', 'Benjamin'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Perez', 'Ella'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Young', 'Alexander'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('King', 'Scarlett'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Scott', 'William'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Adams', 'Grace'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Baker', 'Jack'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Gonzalez', 'Avery'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Nelson', 'Zoe'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Carter', 'Lucas'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Mitchell', 'Mia'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Robinson', 'Jackson'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Clark', 'Chloe'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Rodriguez', 'Max'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Lewis', 'Sophie'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Lee', 'Henry'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Walker', 'Amos'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Hall', 'Sophia'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Allen', 'Eli'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Sanchez', 'Hazel'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Wright', 'Theo'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Hill', 'Chloe'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Bennett', 'Aaron'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Gomez', 'Oliver'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Diaz', 'Harper'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Martin', 'Aiden'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Morris', 'Lily'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Rogers', 'Jayden'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Perez', 'Maya'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Hughes', 'Mackenzie'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Cole', 'Elijah'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Ross', 'Caden'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Flores', 'Isla'); 

INSERT INTO Staff.teachers (lastName, firstName) VALUES ('Howard', 'Nora'); 

 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (30, 7); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (10, 2); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (45, 18); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (25, 5); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (12, 9); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (38, 12); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (50, 14); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (20, 3); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (8, 15); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (22, 17); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (4, 6); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (16, 8); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (41, 20); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (35, 21); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (28, 10); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (2, 1); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (18, 22); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (3, 13); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (44, 25); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (14, 19); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (29, 24); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (13, 27); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (40, 4); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (19, 29); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (33, 30); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (1, 26); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (36, 11); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (7, 16); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (23, 28); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (31, 23); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (9, 12); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (32, 3); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (37, 8); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (24, 7); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (42, 19); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (48, 5); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (46, 21); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (26, 2); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (34, 20); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (47, 18); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (11, 4); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (5, 9); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (15, 17); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (43, 23); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (6, 25); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (39, 14); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (21, 6); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (17, 10); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (49, 13); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (50, 15); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (10, 22); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (33, 4); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (16, 8); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (12, 29); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (18, 30); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (2, 5); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (21, 24); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (29, 16); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (4, 10); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (15, 28); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (8, 2); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (1, 18); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (9, 3); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (30, 12); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (48, 14); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (5, 19); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (20, 25); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (17, 6); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (33, 8); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (39, 27); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (26, 22); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (41, 19); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (7, 28); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (44, 15); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (13, 4); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (25, 29); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (6, 20); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (27, 12); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (11, 7); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (42, 5); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (50, 24); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (32, 3); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (38, 21); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (4, 11); 

INSERT INTO Staff.teacherGroups (teacherID, groupID) VALUES (30, 13); 