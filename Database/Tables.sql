CREATE TABLE "Employee"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "LastName" VARCHAR(100) NOT NULL CHECK ("LastName" ~ '[а-яА-Я]+'),
    "FirstName" VARCHAR(100) NOT NULL CHECK ("FirstName" ~ '[а-яА-Я]+'),
    "Login" VARCHAR(250) NOT NULL UNIQUE,
    "Password" VARCHAR(18) NOT NULL
);

CREATE TABLE "Position"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL CHECK ("Name" ~ '[а-яА-Я ]+'),
    "Salary" DECIMAL(38,2) NULL CHECK ("Salary" >= 0.0) DEFAULT (0.0)
);

CREATE TABLE "EmployeePosition"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "PositionId" UUID NOT NULL REFERENCES "Position" ("Id"),
    "EmployeeId" UUID NOT NULL REFERENCES "Employee" ("Id")
);

CREATE TABLE "Employer"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "LastName" VARCHAR(100) NOT NULL CHECK ("LastName" ~ '[а-яА-Я]+'),
    "FirstName" VARCHAR(100) NOT NULL CHECK ("FirstName" ~ '[а-яА-Я]+'),
    "Position" VARCHAR(250) NOT NULL,
    "PersonalPhone" VARCHAR(20) NOT NULL UNIQUE
        CHECK ("PersonalPhone" ~ '^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$'),
    "PersonalEmail" VARCHAR(250) NOT NULL UNIQUE CHECK ("PersonalEmail" SIMILAR TO '%@%.%'),
    "OrganizationName" VARCHAR(250),
    "SupportNumber" VARCHAR(20) NOT NULL UNIQUE
        CHECK ("SupportNumber" ~ '^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$'),
    "SupportEmail" VARCHAR(250) NOT NULL UNIQUE CHECK ("SupportEmail" SIMILAR TO '%@%.%'),
    "RegistrationAddressOfOrganization" VARCHAR(250) NOT NULL
);

CREATE TABLE "Profession"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL UNIQUE CHECK ("Name" ~ '[а-яА-Я]+')
);

CREATE TABLE "Vacancy"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "Seniority" INT NOT NULL,
    "Salary" DECIMAL(38,2) NULL CHECK ("Salary" >= 0.0) DEFAULT (0.0),
    "EmployerId" UUID NOT NULL REFERENCES "Employer" ("Id"),
    "ProfessionId" UUID NOT NULL REFERENCES "Profession" ("Id")
);

CREATE TABLE "Sex"(
    "Id" CHAR NOT NULL PRIMARY KEY CHECK ("Id" ~ '(M|F)'),
    "Name" VARCHAR(100) NOT NULL UNIQUE CHECK ("Name" ~ '[а-яА-Я]+')
);

CREATE TABLE "Education"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "Name" VARCHAR NOT NULL UNIQUE CHECK ("Name" ~ '[а-яА-Я ]+')
);

CREATE TABLE "EducationForProfession"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "ProfessionId" UUID NOT NULL REFERENCES "Profession" ("Id"),
    "EducationId" INT NOT NULL REFERENCES "Education" ("Id")
);

CREATE TABLE "Employed"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "LastName" VARCHAR(100) NOT NULL CHECK ("LastName" ~ '[а-яА-Я]+'),
    "FirstName" VARCHAR(100) NOT NULL CHECK ("FirstName" ~ '[а-яА-Я]+'),
    "Patronymic" VARCHAR(100) NULL CHECK ("Patronymic" ~ '[а-яА-Я]+'),
    "Email" VARCHAR(250) NOT NULL UNIQUE CHECK ("Email" SIMILAR TO '%@%.%'),
    "Phone" VARCHAR(20) NOT NULL UNIQUE
        CHECK ("Phone" ~ '^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$'),
    "SexId" CHAR NOT NULL REFERENCES "Sex" ("Id")
);

CREATE TABLE "EmployedEducation"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "EmployedId" UUID NOT NULL REFERENCES "Employed" ("Id"),
    "EducationId" INT NOT NULL REFERENCES "Education" ("Id")
);

CREATE TABLE "JobApplication"(
    "Id" UUID NOT NULL PRIMARY KEY,
    "VacancyId" UUID NOT NULL REFERENCES "Vacancy" ("Id"),
    "EmployedId" UUID NOT NULL REFERENCES "Employed" ("Id"),
    "EmployeeId" UUID NOT NULL REFERENCES "Employee" ("Id")
);