-- STATIC

INSERT INTO "Sex" ("Id", "Name")
    VALUES ('M', 'мужчина'),
           ('F', 'женщина');

INSERT INTO "Education" ("Name")
    VALUES ('начальное общее'),
           ('основное общее'),
           ('среднее общее'),
           ('среднее профессиональное'),
           ('бакалавриат'),
           ('специалитет'),
           ('магистратура');

-- SPECIAL FOR ADMINISTRATOR

INSERT INTO "Position" ("Name", "Salary")
    VALUES ('консультант', 30000.23),
           ('регистратор вакансий', 70000.23),
           ('аналитик', 90000.23),
           ('кадровик', 40000.23);

-- DYNAMIC (EXAMPLES OF DATA)

INSERT INTO "Employee" ("LastName", "FirstName", "Login", "Password")
    VALUES ('иванов', 'иван', 'iivanov', '1123'),
           ('петров', 'петр', 'ppetrov', '2123'),
           ('артемов', 'артем', 'aartemov', '3123'),
           ('сергеев', 'сергей', 'ssergeev', '4123');

INSERT INTO "EmployeePosition" ("DateOfHire", "PositionId", "EmployeeId")
    VALUES ('2020-09-23'::date, 1, 1),
           ('2021-09-23'::date, 2, 1),
           ('2020-09-23'::date, 3, 1),
           ('2021-09-23'::date, 2, 2),
           ('2020-09-23'::date, 3, 3);

INSERT INTO "Employer" ("LastName", "FirstName", "Position", "PersonalPhone", "PersonalEmail", "OrganizationName",
                        "SupportNumber", "SupportEmail", "RegistrationAddressOfOrganization")
    VALUES ('кирилов', 'кирил', 'заместитель администратора', '8(909)666-45-35', 'kkirilov@mail.ru',
            'NAZVANIE ORGANIZATSII 1', '8(495)666-45-35', 'NO1@MAIL.RU', 'lenina, 5'),
        ('данилов', 'данил', 'администратор', '8(909)666-45-55', 'ddanilov@mail.ru',
            'NAZVANIE ORGANIZATSII 2', '8(495)666-45-55', 'NO2@MAIL.RU', 'chehova, 7');

INSERT INTO "Profession" ("Name")
    VALUES ('работник склада'), ('электрик'), ('мерчендайзер');

INSERT INTO "Vacancy" ("Seniority", "EmployerId", "ProfessionId")
    VALUES (2, 1, 2), (0, 2, 1), (0, 2, 2);

INSERT INTO "Employed" ("LastName", "FirstName", "Patronymic", "Email", "Phone", "SexId")
    VALUES ('игорев', 'игорь', 'игоревич', 'iigorev@gmail.com', '8(999)666-22-22', 'M'),
           ('маринова', 'марина', 'мариновна', 'mmarinova@gmail.com', '8(999)666-33-33', 'F');

INSERT INTO "EducationForProfession" ("ProfessionId", "EducationId")
   VALUES (1, 1), (1, 2), (1, 3), (1, 4), (2, 1), (2, 2), (2, 3), (2, 5), (2, 6);

INSERT INTO "EmployedEducation" ("EmployedId", "EducationId")
    VALUES (1, 1), (1, 2), (1, 3), (1, 4), (2, 1), (2, 2), (2, 3), (2, 5), (2, 6);

INSERT INTO "JobApplication" ("VacancyId", "EmployedId", "EmployeeId")
    VALUES (1, 1, 1), (2, 2, 2);