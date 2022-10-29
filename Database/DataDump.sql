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

INSERT INTO "Position" ("Id", "Name", "Salary")
    VALUES ('1bf420ef-0de5-4edf-ad4b-64504f396dfc', 'консультант', 30000.23),
           ('73392b58-228a-4667-a7ce-cbf27a60f44a', 'регистратор вакансий', 70000.23),
           ('551f6bdf-8883-4ae8-b2dd-16a24e09a659', 'аналитик', 90000.23),
           ('94d9196e-71e5-4b0d-8b58-66a687258305', 'кадровик', 40000.23);

-- DYNAMIC (EXAMPLES OF DATA)

INSERT INTO "Employee" ("Id", "LastName", "FirstName", "Login", "Password")
    VALUES ('f1d6ec8b-7486-49a2-98d7-c7d5f746a71e', 'иванов', 'иван', 'iivanov', '1123'),
           ('1cd4b72e-9f24-40c1-939b-b961950e7f2d', 'петров', 'петр', 'ppetrov', '2123'),
           ('a9f6f81d-198f-4201-9769-ccb99bbe1beb', 'артемов', 'артем', 'aartemov', '3123'),
           ('32c53c33-ba8d-4e2b-b732-15afb7093e91', 'сергеев', 'сергей', 'ssergeev', '4123');

INSERT INTO "EmployeePosition" ("Id", "PositionId", "EmployeeId")
    VALUES (uuid_generate_v4(), '1bf420ef-0de5-4edf-ad4b-64504f396dfc', 'f1d6ec8b-7486-49a2-98d7-c7d5f746a71e'),
           (uuid_generate_v4(), '73392b58-228a-4667-a7ce-cbf27a60f44a', '1cd4b72e-9f24-40c1-939b-b961950e7f2d'),
           (uuid_generate_v4(), '551f6bdf-8883-4ae8-b2dd-16a24e09a659', '1cd4b72e-9f24-40c1-939b-b961950e7f2d'),
           (uuid_generate_v4(), '94d9196e-71e5-4b0d-8b58-66a687258305', 'a9f6f81d-198f-4201-9769-ccb99bbe1beb'),
           (uuid_generate_v4(), '94d9196e-71e5-4b0d-8b58-66a687258305', '32c53c33-ba8d-4e2b-b732-15afb7093e91');

INSERT INTO "Employer" ("Id", "LastName", "FirstName", "Position", "PersonalPhone", "PersonalEmail", "OrganizationName",
                        "SupportNumber", "SupportEmail", "RegistrationAddressOfOrganization")
    VALUES ('a50fe936-0406-4deb-a6bb-6da2008677d3', 'кирилов', 'кирил', 'заместитель администратора', '8(909)666-45-35',
            'kkirilov@mail.ru',  'NAZVANIE ORGANIZATSII 1', '8(495)666-45-35', 'NO1@MAIL.RU', 'lenina, 5'),
        ('bfd73f6f-0e19-4608-980a-6d6e9bf6b44a', 'данилов', 'данил', 'администратор', '8(909)666-45-55',
         'ddanilov@mail.ru', 'NAZVANIE ORGANIZATSII 2', '8(495)666-45-55', 'NO2@MAIL.RU', 'chehova, 7');

INSERT INTO "Profession" ("Id", "Name")
    VALUES ('4515069f-a7ae-4b0f-bfb4-bfed6d40eaf2', 'работник склада'),
           ('c9d4a2ee-7cb7-42e9-9368-8f8f62941523', 'электрик'),
           ('49e0c898-0ee9-4d4d-a8be-39c6df1329bb', 'мерчендайзер');

INSERT INTO "Vacancy" ("Id", "Seniority", "EmployerId", "ProfessionId")
    VALUES ('f3d4edf5-cab6-4318-b497-84a5d344972f', 2, 'a50fe936-0406-4deb-a6bb-6da2008677d3',
            'c9d4a2ee-7cb7-42e9-9368-8f8f62941523'),
           ('63fde70a-b722-48bf-ab58-c41fd5448255', 0, 'bfd73f6f-0e19-4608-980a-6d6e9bf6b44a',
            '4515069f-a7ae-4b0f-bfb4-bfed6d40eaf2'),
           ('b2435289-21ea-4d72-a481-3ebd320e1ebe', 0, 'bfd73f6f-0e19-4608-980a-6d6e9bf6b44a',
            'c9d4a2ee-7cb7-42e9-9368-8f8f62941523');

INSERT INTO "Employed" ("Id", "LastName", "FirstName", "Patronymic", "Email", "Phone", "SexId")
    VALUES ('6895dd5f-5f82-4802-8ef3-b4549ca003b4', 'игорев', 'игорь', 'игоревич',
            'iigorev@gmail.com', '8(999)666-22-22', 'M'),
           ('9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', 'маринова', 'марина', 'мариновна',
            'mmarinova@gmail.com', '8(999)666-33-33', 'F');

INSERT INTO "EducationForProfession" ("Id", "ProfessionId", "EducationId")
   VALUES (uuid_generate_v4(), '4515069f-a7ae-4b0f-bfb4-bfed6d40eaf2', 1),
          (uuid_generate_v4(), '4515069f-a7ae-4b0f-bfb4-bfed6d40eaf2', 2),
          (uuid_generate_v4(), '4515069f-a7ae-4b0f-bfb4-bfed6d40eaf2', 3),
          (uuid_generate_v4(), '4515069f-a7ae-4b0f-bfb4-bfed6d40eaf2', 4),
          (uuid_generate_v4(), 'c9d4a2ee-7cb7-42e9-9368-8f8f62941523', 1),
          (uuid_generate_v4(), 'c9d4a2ee-7cb7-42e9-9368-8f8f62941523', 2),
          (uuid_generate_v4(), 'c9d4a2ee-7cb7-42e9-9368-8f8f62941523', 3),
          (uuid_generate_v4(), 'c9d4a2ee-7cb7-42e9-9368-8f8f62941523', 5),
          (uuid_generate_v4(), 'c9d4a2ee-7cb7-42e9-9368-8f8f62941523', 6);

INSERT INTO "EmployedEducation" ("Id", "EmployedId", "EducationId")
    VALUES (uuid_generate_v4(), '6895dd5f-5f82-4802-8ef3-b4549ca003b4', 1),
           (uuid_generate_v4(), '6895dd5f-5f82-4802-8ef3-b4549ca003b4', 2),
           (uuid_generate_v4(), '6895dd5f-5f82-4802-8ef3-b4549ca003b4', 3),
           (uuid_generate_v4(), '6895dd5f-5f82-4802-8ef3-b4549ca003b4', 4),
           (uuid_generate_v4(), '9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', 1),
           (uuid_generate_v4(), '9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', 2),
           (uuid_generate_v4(), '9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', 3),
           (uuid_generate_v4(), '9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', 5),
           (uuid_generate_v4(), '9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', 6);

INSERT INTO "JobApplication" ("Id", "VacancyId", "EmployedId", "EmployeeId")
    VALUES (uuid_generate_v4(), 'f3d4edf5-cab6-4318-b497-84a5d344972f',
            '6895dd5f-5f82-4802-8ef3-b4549ca003b4', 'f1d6ec8b-7486-49a2-98d7-c7d5f746a71e'),
           (uuid_generate_v4(), '63fde70a-b722-48bf-ab58-c41fd5448255',
            '9d4b3ef1-fd5a-4323-9a16-5af9a1e4263f', '1cd4b72e-9f24-40c1-939b-b961950e7f2d');