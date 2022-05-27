--Part 1

Table: Jobs
Columns:
Id int AI PK
Name longtext
EmployerId int

--Part 2

SELECT Name 
FROM techjobs.Employers
WHERE (Location = "St. Louis");


--Part 3

SELECT DISTINCT techjobs.Skills.Name, techjobs.Skills.Description
FROM techjobs.Skills
JOIN techjobs.JobSkills ON techjobs.Skills.Id = techjobs.JobSkills.SkillId
WHERE techjobs.JobSkills.JobId is not null
ORDER BY Name;