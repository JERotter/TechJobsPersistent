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

SELECT techjobs.Skills.Name, techjobs.Skills.Description
FROM techjobs.Skills
JOIN techjobs.JobSkills ON techjobs.Skill.Id = techjobs.JobSkills.SkillId
ORDER BY Name;