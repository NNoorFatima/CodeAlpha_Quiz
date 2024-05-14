create database quiz;
use quiz;

CREATE TABLE MEMBERS
(
	
	USERNAME VARCHAR(100),
	PASSWORD VARCHAR(100),
	DOB DATETIME,
	EMAIL VARCHAR(100)
);

CREATE TABLE questions (
    question_id INT PRIMARY KEY,
    question_text TEXT NOT NULL,
	ansid int,
    FOREIGN KEY (ansid) REFERENCES quizzes(ansid) ON DELETE CASCADE
);

create table answer
(
	ansid int primary key,
	ans_text text not null,

);