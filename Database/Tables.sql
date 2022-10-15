CREATE TABLE "Employee"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "LastName" VARCHAR(100) NOT NULL CHECK ("LastName" ~ '[а-яА-Я]+'),
    "FirstName" VARCHAR(100) NOT NULL CHECK ("FirstName" ~ '[а-яА-Я]+'),
    "Login" VARCHAR(250) NOT NULL UNIQUE,
    "Password" VARCHAR(18) NOT NULL
);

CREATE TABLE "Position"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL CHECK ("Name" ~ '[а-яА-Я ]+'),
    "Salary" DECIMAL(38,2) NULL CHECK ("Salary" >= 0.0) DEFAULT (0.0)
);

CREATE TABLE "EmployeePosition"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "DateOfHire" DATE NOT NULL,
    "PositionId" INTEGER NOT NULL REFERENCES "Position" ("Id"),
    "EmployeeId" INTEGER NOT NULL REFERENCES "Employee" ("Id")
);

CREATE TABLE "Employer"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
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
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "Name" VARCHAR(100) NOT NULL UNIQUE CHECK ("Name" ~ '[а-яА-Я]+')
);

CREATE TABLE "Vacancy"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "Seniority" INTEGER NOT NULL,
    "Salary" DECIMAL(38,2) NULL CHECK ("Salary" >= 0.0) DEFAULT (0.0),
    "EmployerId" INTEGER NOT NULL REFERENCES "Employer" ("Id"),
    "ProfessionId" INTEGER NOT NULL REFERENCES "Profession" ("Id")
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
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "ProfessionId" INTEGER NOT NULL REFERENCES "Profession" ("Id"),
    "EducationId" INTEGER NOT NULL REFERENCES "Education" ("Id")
);

CREATE TABLE "Employed"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "LastName" VARCHAR(100) NOT NULL CHECK ("LastName" ~ '[а-яА-Я]+'),
    "FirstName" VARCHAR(100) NOT NULL CHECK ("FirstName" ~ '[а-яА-Я]+'),
    "Patronymic" VARCHAR(100) NULL CHECK ("Patronymic" ~ '[а-яА-Я]+'),
    "Email" VARCHAR(250) NOT NULL UNIQUE CHECK ("Email" SIMILAR TO '%@%.%'),
    "Phone" VARCHAR(20) NOT NULL UNIQUE
        CHECK ("Phone" ~ '^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$'),
    "SexId" CHAR NOT NULL REFERENCES "Sex" ("Id")
);

CREATE TABLE "EmployedEducation"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "EmployedId" INTEGER NOT NULL REFERENCES "Employed" ("Id"),
    "EducationId" INTEGER NOT NULL REFERENCES "Education" ("Id")
);

CREATE TABLE "JobApplication"(
    "Id" SERIAL NOT NULL PRIMARY KEY,
    "VacancyId" INTEGER NOT NULL REFERENCES "Vacancy" ("Id"),
    "EmployedId" INTEGER NOT NULL REFERENCES "Employed" ("Id"),
    "EmployeeId" INTEGER NOT NULL REFERENCES "Employee" ("Id")
);